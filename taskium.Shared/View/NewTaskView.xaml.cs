using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

using microhobby.Utils;
using taskium;

using System.Timers;

namespace taskium
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewTaskView : Page
    {
        public NewTaskView()
        {
            this.InitializeComponent();
        }

        public async void PageLoaded (object sender, RoutedEventArgs ev)
        {
            var id = this.Frame.GetNavigationState();

            // if we have an id we fill the inputs
            if (!string.IsNullOrEmpty(id)) {
                var task = await Server.Calls.TaskIdGetAsync(int.Parse(id));

                InputName.Text = task.Name;
                InputRepo.Text = task.Repo;
                InputBranch.Text = task.Branch;
                InputTaskLabel.Text = task.TaskLabel;

                this.Frame.SetNavigationState("");
            }
        }

        private void validateInputs(TextBox input) 
        {
            if (string.IsNullOrEmpty(input.Text)) {
                input.Background = "#6E3836";
                throw new Exception("Text cannot be empty");
            } else {
                input.Background = "#14222B";
            }
        }

        public async void ButtonSubmitClick(object sender, RoutedEventArgs env)
        {
            validateInputs(InputName);
            validateInputs(InputRepo);
            validateInputs(InputBranch);
            validateInputs(InputTaskLabel);

            // all ok
            var task = new TaskiumRestAPI.Model.Task();
            task.Name = InputName.Text;
            task.Repo = InputRepo.Text;
            task.Branch = InputBranch.Text;
            task.TaskLabel = InputTaskLabel.Text;

            // record the new task
            await Server.Calls.TaskPostAsync(task);

            // clean up
            InputName.Text = "";
            InputRepo.Text = "";
            InputBranch.Text = "";
            InputTaskLabel.Text = "";

            // navigate
            this.Frame.Navigate(typeof(TasksView));
        }
    }
}
