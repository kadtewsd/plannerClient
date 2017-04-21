using System;
using System.Windows.Forms;

namespace PlannerClient.Forms.GridAction
{
    public class TaskCreateGridAction : AbstractGridAction
    {
        O365ServiceForm form = null;
        public TaskCreateGridAction(O365ServiceForm argForm)   :base (argForm)
        {
        }

        public override bool CanExecute(DataGridViewCell cell)
        {

            int cnt = int.Parse(form.GetDisplayData().GetCurrentSubData().TaskCount); 
            if (cnt == 0)
            {
                MessageBox.Show("入力された登録件数は0件です。");
                return false;
            }

            return cell.Value != null;
        }

        public override bool ExecuteServiceRequest(DataGridViewCellEventArgs e)
        {
            // DataGridViewComboBoxCell cel = (DataGridViewComboBoxCell)form.SelectedPlanRow.Cells[FormHelper.DropDownBucketColumnName];
            return form.taskCreation.ExecuteRequest();
        }

        public bool HasKeySelected()
        {
            return true ;
        }

        public override void EditCell()
        {
            return;
        }

        public override void SetCurrentIndex(DataGridViewComboBoxEditingControl e)
        {
            throw new NotImplementedException();
        }
    }
}