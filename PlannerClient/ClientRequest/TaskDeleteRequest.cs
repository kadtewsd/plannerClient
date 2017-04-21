using PlannerClient.Model.Plan;
using System.Net.Http;

namespace PlannerClient.ClientRequest
{
    public class TaskDeleteRequest : AbstractClientRequest<TaskModel>
    {
        protected override HttpMethod HttpMethod
        {
            get
            {
                return HttpMethod.Delete;
            }
        }

        //protected override string GetEndPoint(TaskModel form)
        //{
        //    return "https://graph.microsoft.com/beta/tasks/" + form.id;
        //}
        
        protected override string GetEndPoint(object form)
        {
            TaskModel task = (TaskModel)form;
            return "https://graph.microsoft.com/beta/tasks/" + task.id;
        }


        //protected override void CreateParameter(HttpRequestMessage request, TaskModel form)
        //{
        //    //エラー
        //    //request.Headers.Add("If-Match",  "*");
        //    //request.Headers.Add("If-Match", "W/\"" + form.etag );
        //    request.Headers.Add("If-Match", form.etag);
        //}


        protected override void CreateParameter(HttpRequestMessage request, object  form)
        {
            TaskModel task = (TaskModel)form;
            request.Headers.Add("If-Match", task.etag);
        }

    }
}
