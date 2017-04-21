using PlannerClient.Forms;
using PlannerClient.Model.Plan;
using PlannerClient.ClientRequest;
using PlannerClient.Model;

namespace PlannerClient.Service
{
    public class BucketAnsTaskCollectionService : AbstractServices<PlanModel>, IBucketAnsTaskCollectionService
    {

        public BucketAnsTaskCollectionService(O365ServiceForm form) : base(form)
        {
        }

        private AbstractClientRequest<BucketModel> bucketReq = new BucketCollectRequest();
        protected override AzureADFormatModel<PlanModel> ExecuteRequestInternal()
        {
            PlannerDisplayData data = Form.GetDisplayData();
            PlanModel planOnView = data.GetCurrentSubData();
            requestInfo.id = planOnView.id;
            AzureADFormatModel<BucketModel> buckets = bucketReq.DoRequest(requestInfo).Result;

            //if (!HandlerError(buckets))
            if (!buckets.HttpResult.IsSuccess)
            {
                return CreateRequestFailure(buckets.HttpResult, planOnView, "バケットの取得に失敗しました。");
            }
            planOnView.RequestResult = buckets.HttpResult;
            planOnView.BucketList = buckets.value;
            planOnView.CurrentChildListIndex = 0;



            TaskCollectRequest taskReq = new TaskCollectRequest();
            //Plan 取得時に全タスクを取得するとパフォーマンスの問題が生じるので、バケットを取得するときに該当のプランのタスクを取得する動作にします。

            TaskModel task = new TaskModel();
            string planId = data.GetCurrentSubData().id;
            task.planId = planId;
            task.AccessToken = Form.AuthenticationInfo.access_token;
            AzureADFormatModel<TaskModel> tasks = taskReq.DoRequest(task).Result;
            //if (!HandlerError(tasks))
            if (!tasks.HttpResult.IsSuccess)
            {
                return CreateRequestFailure(tasks.HttpResult, planOnView, "タスクの取得に失敗しました。");
            }

            planOnView.RequestResult = tasks.HttpResult;
            planOnView.GetCurrentSubData().TaskList = tasks.value;

            //Form.GridPlan.BeginEdit(false);
            // //Form.GridPlan.DataSource = bs;
            //Form.GridPlan.NotifyCurrentCellDirty(false);
            return CreateResult(planOnView);
        }


        /// <summary>
        /// リクエストはされませんでした。既存のデータでデータを設定します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name=""></param>
        //private void SetTaskInfo(DataGridViewRow row, PlanModel model)
        //{

        //    DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)row.Cells[EntityMapper.DropDownBucketColumnName];
        //    ITitleValueModeListl bucket = (ITitleValueModel)cell.Items[Form.SelectedPlanRow.Index];

        //    IEnumerable<TaskModel> tasks = from n in model.TaskList
        //                                   where n.bucketId == bucket.Value
        //                                   select n;

        //}
    }
}
