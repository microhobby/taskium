using System;
using TaskiumRestAPI.Api;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace taskium
{
    public class TaskViewModel : TaskModel, INotifyPropertyChanged
    {
        private int _valueCompleted = 0;
        public int ValueCompleteded { 
            get { return _valueCompleted; } 
            set
            {
                if (_valueCompleted != value) {
                    Console.WriteLine("_valueCompleted Changed");
                    _valueCompleted = value;
                    PropertyChanged?.Invoke(
                        this, 
                        new PropertyChangedEventArgs(nameof(ValueCompleteded))
                    );
                }
            } 
        }

        private string _progressForeground = "#00A0C8";
        public string ProgressForeground { 
            get { return _progressForeground; }
            set
            {
                if (_progressForeground != value) {
                    Console.WriteLine($"_progressForeground Changed");
                    _progressForeground = value;
                    PropertyChanged?.Invoke(
                        this, 
                        new PropertyChangedEventArgs(nameof(ProgressForeground))
                    );
                }
            }
        }
        
        private bool _isRunning = false;
        public bool IsRunning { 
            get { return _isRunning; } 
            set
            {
                if (_isRunning != value) {
                    Console.WriteLine("_isRunning Changed");
                    _isRunning = value;
                    PropertyChanged?.Invoke(
                        this, 
                        new PropertyChangedEventArgs(nameof(IsRunning))
                    );
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TaskViewModel(TaskiumRestAPI.Model.Task task) : base(task) 
        {
            this._valueCompleted = 
                this.IsComplete
                ? 100
                : 0;

            this._progressForeground =
                this.ReturnCode != 0
                ? "#F54242"
                : "#42F56F";

            this._isRunning = (this.IsStarted && !this.IsComplete);

            if (this._isRunning) {
                this._progressForeground = "#00A0C8";
            }
        }

        public static void UpdateCollection(
            ObservableCollection<TaskViewModel> lBase, List<TaskViewModel> lNew)
        {
            // update also the items
            if (lNew.Count > lBase.Count) {
                lBase.Insert(0, lNew[0]);
            }

            // update
            for(var i = 0; i < lBase.Count; i++) {
                lBase[i].IsRunning = lNew[i].IsRunning;
                lBase[i].ProgressForeground = lNew[i].ProgressForeground;
                lBase[i].ValueCompleteded = lNew[i].ValueCompleteded;
                lBase[i].StdOut = lNew[i].StdOut;
                lBase[i].ReturnCode = lNew[i].ReturnCode;
            }
        }
    }
}
