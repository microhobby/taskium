using TaskiumRestAPI.Api;

namespace taskium
{
    public class TaskModel : TaskiumRestAPI.Model.Task
    {
        public TaskModel(TaskiumRestAPI.Model.Task task) 
        {
            // convert the base
            this.Branch = task.Branch;
            this.Description = task.Description;
            this.Id = task.Id;
            this.IsComplete = task.IsComplete;
            this.IsStarted = task.IsStarted;
            this.Name = task.Name;
            this.Repo = task.Repo;
            this.ReturnCode = task.ReturnCode;
            this.StdErr = task.StdErr;
            this.StdOut = task.StdOut;
            this.TaskLabel = task.TaskLabel;

            if (this.Description == null) this.Description = ""; 
            if (this.StdErr == null) this.StdErr = "waiting for the runner ...";
            if (this.StdOut == null) this.StdOut = "waiting for the runner ...";
        }
    }
}
