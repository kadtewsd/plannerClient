using PlannerClient.Forms;
using PlannerClient.Model.Plan;
using PlannerClient.ClientRequest;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using PlannerClient.Model;

namespace PlannerClient.Service
{
    public class TaskCollectionService : AbstractServices<TaskModel>, ITaskCollectionService
    {
        public TaskCollectionService(O365ServiceForm form) : base(form)
        {
        }
        private AbstractClientRequest<TaskModel> taskReq = new TaskCollectRequest();
        protected override AzureADFormatModel<TaskModel> ExecuteRequestInternal()
        {

            PlannerDisplayData display = Form.GetDisplayData();
            this.requestInfo.planId = display.GetCurrentSubData().id;
            this.requestInfo.bucketId = display.GetCurrentSubData().GetCurrentSubData().id;

            AzureADFormatModel<TaskModel> tasks = this.taskReq.DoRequest(this.requestInfo).Result;
            return tasks;
        }
    }
}
