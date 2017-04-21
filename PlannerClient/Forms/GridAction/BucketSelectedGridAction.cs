using PlannerClient.Model;
using PlannerClient.Model.Plan;
using PlannerClient.Util.Form;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PlannerClient.Forms.GridAction
{
    public class BucketCollectionGridAction : AbstractGridAction
    {
        public BucketCollectionGridAction(O365ServiceForm argForm) : base(argForm)
        {
        }

        public override bool CanExecute(DataGridViewCell cell)
        {
            DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)cell;
            //DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)cell.OwningColumn;
            //ITitleValueModel dto = (ITitleValueModel) combo.Items[0];
            //return dto.Value == FormHelper.UnassignedValue && combo.Items.Count == 1;
            object frm = cell.FormattedValue;
            return frm.ToString() == FormHelper.UnassignedValue && combo.Items.Count == 1;

        }

        public override bool ExecuteServiceRequest(DataGridViewCellEventArgs e)
        {
            bool ret = this.O365Form.bucketCollect.ExecuteRequest();
            //if (!ret)
            //{
            //    return ret;
            //}
            //PlanModel current = (from plan in this.Form.PlanList
            //                     where plan.id == this.Form.SelectedPlanId
            //                     select plan).First();
            //form.GridPlan.UpdateCellValue(e.ColumnIndex, e.RowIndex);

            PlannerDisplayData displayData = O365Form.GetDisplayData();
            PlanModel plan = displayData.GetCurrentSubData();

            SetComboBox(EntityMapper.DropDownBucketColumnName, plan.BucketList);
            SetComboBox(EntityMapper.DropDownTaskColumnName, plan.GetCurrentSubData().TaskList);

            SelectFistListItem();

            DataGridViewButtonCell btn = (DataGridViewButtonCell)O365Form.DisplayList.Rows[O365Form.DisplayList.CurrentRow.Index].Cells[EntityMapper.CreateTaskBtn];
            btn.Value = "タスク作成";

            DataGridViewButtonCell delbtn = (DataGridViewButtonCell)O365Form.DisplayList.Rows[O365Form.DisplayList.CurrentRow.Index].Cells[EntityMapper.DeleteTaskBtnName];
            delbtn.Value = "タスク削除";
            O365Form.DisplayList.CommitEdit(DataGridViewDataErrorContexts.Commit);

            return ret;

        }

        public override void EditCell()
        {
            PlannerDisplayData display = O365Form.GetDisplayData();
            string bucketId = display.GetCurrentSubData().GetCurrentSubData().id;
            //DataGridViewComboBoxCell bucket = (DataGridViewComboBoxCell)O365Form.GetTargetGridViewCell(EntityMapper.DropDownBucketColumnName);
            //DataGridViewComboBoxCell task = (DataGridViewComboBoxCell)O365Form.GetTargetGridViewCell(EntityMapper.DropDownTaskColumnName);

            //IEnumerable<TaskModel> tasks = (IEnumerable<TaskModel>)current.Cells[EntityMapper.TaskList].Value;
            IDataListModel<TaskModel> bucket = display.GetCurrentSubData().GetCurrentSubData();
            IList<TaskModel> targetTasks = bucket.GetSubDataList();
           
            if (targetTasks == null)
            {
                ClearComboBoxCell(EntityMapper.TaskList);
                return;
            }
             SetComboBox(EntityMapper.DropDownTaskColumnName, targetTasks);
            
        }

        public override void SetCurrentIndex(DataGridViewComboBoxEditingControl e)
        {
            PlannerDisplayData data = O365Form.GetDisplayData();
            PlanModel plan = data.GetCurrentSubData();
            data.CurrentChildListIndex = O365Form.DisplayList.CurrentRow.Index;
            plan.CurrentChildListIndex= e.SelectedIndex;
        }
    }
}
