using PlannerClient.Model.Plan;
using System.Windows.Forms;

namespace PlannerClient.Forms
{
    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();
        }

        internal TaskModel TaskInfo { get; set; }

        private void TaskForm_Load(object sender, System.EventArgs e)
        {
            this.title.DataBindings.Add(this.title.Name, this.TaskInfo, this.title.Name);

            this.assignedTo.DataBindings.Add(this.assignedTo.Name, this.TaskInfo, this.assignedTo.Name);
            this.startDate.DataBindings.Add(this.startDate.Name, this.TaskInfo, this.startDate.Name);
            this.dueDate.DataBindings.Add(this.dueDate.Name, this.TaskInfo, this.dueDate.Name);
            this.previewType.DataBindings.Add(this.previewType.Name, this.TaskInfo, this.previewType.Name);
            this.assigneePriority.DataBindings.Add(this.assigneePriority.Name, this.TaskInfo, this.assigneePriority.Name);
        }
    }
}
