using PlannerClient.Forms;
using PlannerClient.Model.Plan;
using PlannerClient.ClientRequest;
using System.Collections.Generic;
using System.Linq;
using PlannerClient.Model;

namespace PlannerClient.Service
{
    public class TaskDeleteService : AbstractServices<TaskModel>, ITaskDeleteService
    {
        public TaskDeleteService(O365ServiceForm form) : base(form)
        {
        }

        public TaskModel RequestInfo
        {
            get
            {
                return this.requestInfo;
            }
        }

        protected override AzureADFormatModel<TaskModel> ExecuteRequestInternal()
        {
            AzureADFormatModel<TaskModel> resultList = new AzureADFormatModel<TaskModel>();
            //IEnumerable<BucketModel> buckets = form.SelectedPlanBucketList;
            IEnumerable<TaskModel> tasks = Form.GetDisplayData().GetCurrentSubData().TaskList;

            TaskDeleteRequest service = new TaskDeleteRequest();

            if (tasks == null)
            {
                return null;
            }
            for (int i = 0; i < tasks.ToList().Count(); i++)
            {
                TaskModel task = tasks.ToList()[i];
                this.RequestInfo.id = task.id;
                this.RequestInfo.etag = task.etag;
                this.CurrentCount = i;
                AzureADFormatModel<TaskModel> result = service.DoRequest(this.requestInfo).Result;
                base.AddModel(result.value, resultList.value);
            }

            //キャストしないとコンパイル エラーになる;
            //return (IList<AzureADFormatModel<T>>)list;
            //return ret;

            return resultList;
        }
    }
}
