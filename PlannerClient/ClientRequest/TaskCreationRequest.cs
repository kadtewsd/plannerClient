using PlannerClient.Model.Plan;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace PlannerClient.ClientRequest
{
    public class TaskCreationRequest : AbstractClientRequest<TaskModel>
    {

        public TaskCreationRequest() : base() { }

        //protected override string GetEndPoint(TaskModel model)
        //{
        //    //return "https://graph.microsoft.com/beta/me/tasks";
        //    return "https://graph.microsoft.com/beta/tasks";
        //}


        protected override string GetEndPoint(object model)
        {
            //return "https://graph.microsoft.com/beta/me/tasks";
            return "https://graph.microsoft.com/beta/tasks";
        }


        protected override HttpMethod HttpMethod
        {
            get
            {
                return HttpMethod.Post;
            }
        }

        //protected override void CreateParameter(HttpRequestMessage request, TaskModel form)
        //{
        //    request.Content= new FormUrlEncodedContent(new Dictionary<string, string>
        //            {
        //                {"assignedTo",form.assignedTo},
        //                {"planId",form.planId},
        //                {"bucketId", form.bucketId },
        //                //{"resource","https%3A%2F%2Flocalhost%2FClientApps" },
        //                {"title", form.title},
        //                {"orderHint", form.orderHint},
        //            });

        //}


        protected override void CreateParameter(HttpRequestMessage request, object form)
        {

            TaskModel task = (TaskModel)form;

            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"assignedTo",task.assignedTo},
                        {"planId",task.planId},
                        {"bucketId", task.bucketId },
                        //{"resource","https%3A%2F%2Flocalhost%2FClientApps" },
                        {"title", task.title},
                        {"orderHint", task.orderHint},
                    });

        }

    }
}
