using PlannerClient.Model.Plan;
using PlannerClient.Util.Form;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PlannerClient.Forms.GridAction
{
    public class TaskSelectedGridAction : AbstractGridAction
    {
        O365ServiceForm form = null;
        public TaskSelectedGridAction(O365ServiceForm argForm) :base(argForm)
        {
        }

        public override bool CanExecute(DataGridViewCell cell)
        {
            // いったんタスクは何もしない。
            return false;
        }

        public override bool ExecuteServiceRequest(DataGridViewCellEventArgs e)
        {
            return true; 
        }


        public override void EditCell()
        {
            PlannerDisplayData display = O365Form.GetDisplayData();
            PlanModel plan = display.GetCurrentSubData();
            string taskId = plan.GetCurrentSubData().GetCurrentSubData().GetCurrentSubData().id;
            string bucketId = display.GetCurrentSubData().GetCurrentSubData().id;
            //cnt.Value = EntityMapper.DetaultTaskInsertCount;

        }


        public override void SetCurrentIndex(DataGridViewComboBoxEditingControl e)
        {
            PlannerDisplayData data = form.GetDisplayData();
            TaskModel task = data.GetCurrentSubData().GetCurrentSubData().GetCurrentSubData();
            task.CurrentChildListIndex = e.SelectedIndex;
        }
    }
}
