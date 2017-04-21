using PlannerClient.Model.Plan;
using System.Net.Http;

namespace PlannerClient.ClientRequest
{
    public class TaskCollectRequest : AbstractClientRequest<TaskModel>
    {
        protected override HttpMethod HttpMethod
        {
            get
            {
                return HttpMethod.Get;
            }
        }
        //protected override string GetEndPoint(TaskModel form)
        //{
        //    // bucket Id
        //    return "https://graph.microsoft.com/beta/plans/" + form.planId + "/tasks";
        //}


        protected override string GetEndPoint(object form)
        {
            TaskModel task = (TaskModel)form;
            // bucket Id
            return "https://graph.microsoft.com/beta/plans/" + task.planId + "/tasks";
        }

    }
}
