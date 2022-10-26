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
    public sealed partial class TasksView : Page
    {
        private ObservableCollection<TaskViewModel> taskses = new();
        private Timer pollingTimer = new();
        private int selectedId = 0;

        public TasksView()
        {
            this.InitializeComponent();
        }

        ~TasksView()
        {
            pollingTimer.Enabled = false;
        }

        public async void PageLoaded (object sender, RoutedEventArgs ev)
        {
            var tasks = await Server.Calls.TasksGetAsync();

            foreach(var task in tasks) {
                taskses.Add(new TaskViewModel(task));
            }

            ListTasks.ItemsSource = taskses;

            // like the old Aztecs
            pollingTimer.Interval = 5000;
            pollingTimer.Elapsed += async (sender, ev) => {
                Console.WriteLine("TICK START");
                
                // check if we need to update the list
                var tasks = await Server.Calls.TasksGetAsync();
                var tasksPlus = new List<TaskViewModel>();

                foreach(var task in tasks) {
                    tasksPlus.Add(new TaskViewModel(task));
                }

                TaskViewModel.UpdateCollection(
                    taskses,
                    tasksPlus
                );

                if (selectedId != 0) {
                    var elem = taskses.First(e => e.Id == selectedId);
                    TextStdOutput.Text = elem.StdOut;
                    var retCode = elem.ReturnCode == -69 ? 0 : elem.ReturnCode;
                    TextTaskReturnCode.Text = $"Return code: {retCode.ToString()}";
                    
                    if (elem.IsComplete) {
                        selectedId = 0;
                    }
                }

                Console.WriteLine("TICK END");
            };
            pollingTimer.Enabled = true;
        }

        public void PageUnload (object sender, RoutedEventArgs ev)
        {
            pollingTimer.Enabled = false;
        }

        public async void ButtonLogsClick(object sender, RoutedEventArgs env)
        {
            var id = (sender as Button).Tag.ToString();
            selectedId = int.Parse(id);
            var task = await Server.Calls.TaskIdGetAsync(selectedId);
            var retCode = task.ReturnCode == -69 ? 0 : task.ReturnCode;

            TextStdOutput.Text = task.StdOut;
            TextTaskName.Text = $"Task: {task.Name}";
            TextTaskReturnCode.Text = $"Return code: {retCode.ToString()}";
        }

        public void ButtonCopy(object sender, RoutedEventArgs env)
        {
            var id = (sender as Button).Tag.ToString();
            this.Frame.SetNavigationState(id);
            this.Frame.Navigate(typeof(NewTaskView));
        }

        // get from stack overflow
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            var grid = (Grid)VisualTreeHelper.GetChild((TextBox)sender, 0);
            for (var i = 0; i <= VisualTreeHelper.GetChildrenCount(grid) - 1; i++)
            {
                object obj = VisualTreeHelper.GetChild(grid, i);
                if (!(obj is ScrollViewer)) continue;
                ((ScrollViewer)obj).ChangeView(0.0f, ((ScrollViewer)obj).ExtentHeight, 1.0f);
                break;
            }
        }
    }
}
