using PlannerClient.ClientRequest;
using PlannerClient.Forms;
using PlannerClient.Model;
using PlannerClient.Model.Plan;
using System;
using System.Linq;

namespace PlannerClient.Service
{
    public class TaskCreationService : AbstractServices<TaskModel>, ITaskCreationService
    {

        private AbstractClientRequest<TaskModel> req = new TaskCreationRequest();

        public TaskCreationService(O365ServiceForm form) : base(form)
        {
        }

        protected override AzureADFormatModel<TaskModel> ExecuteRequestInternal()
        {
            PlanModel model = Form.GetDisplayData().GetCurrentSubData();
            this.RequestInfo.planId = model.id;
            this.RequestInfo.assignedTo = "admin@kkproj15.onmicrosoft.com";
            this.RequestInfo.bucketId = model.GetCurrentSubData().id;
            this.RequestInfo.orderHint = "78415454545 -";

            AzureADFormatModel<TaskModel> resultList = CreateResultList();

            int cnt = int.Parse(Form.GetDisplayData().GetCurrentSubData().TaskCount);
            AzureADFormatModel<TaskModel> result = null;
            for (int i = 0; i < cnt; i++)
            {
                this.RequestInfo.title = "kasakaidTask" + i.ToString();
                this.CurrentCount = i;
                try
                {
                    result = req.DoRequest(requestInfo).Result;
                    if (result.HttpResult.IsSuccess)
                    {
                        AddModel(result, resultList);
                    }
                }
                catch (Exception e)
                {
                    base.AddErrorInfo(e, resultList);
                }
            }

            return resultList;
        }


        protected override void ObserveIfEnableFormState()
        {
            int cnt = int.Parse(Form.GetDisplayData().GetCurrentSubData().TaskCount);

            if (cnt - 1 == this.CurrentCount)
            {
                base.ObserveIfEnableFormState();
            }
        }

        public TaskModel RequestInfo
        {
            get
            {
                return this.requestInfo;
            }
        }
    }
}
