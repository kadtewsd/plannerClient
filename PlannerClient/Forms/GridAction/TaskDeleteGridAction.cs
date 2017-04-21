using System.Windows.Forms;
using System;

namespace PlannerClient.Forms.GridAction
{
    public class TaskDeleteGridAction : AbstractGridAction
    {
        O365ServiceForm form = null;
        public TaskDeleteGridAction(O365ServiceForm argForm) : base(argForm)
        {
        }

        public override bool CanExecute(DataGridViewCell cell)
        {
            int cnt = int.Parse(form.GetDisplayData().GetCurrentSubData().TaskCount); 
            if (cnt == 0)
            {
                MessageBox.Show("入力された削除件数は0件です。");
                return false;
            }

            return cell != null;
        }

        public override bool ExecuteServiceRequest(DataGridViewCellEventArgs e) //where T : TaskModel
        {
            return form.taskDelete.ExecuteRequest();
        }

        public override void EditCell()
        {
            return;
        }

        public bool HasKeySelected()
        {
            return true ;
        }

        public override void SetCurrentIndex(DataGridViewComboBoxEditingControl e)
        {
            throw new NotImplementedException();
        }
    }
}
