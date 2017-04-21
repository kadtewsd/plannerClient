using PlannerClient.Model.Plan;
using System.Net.Http;
using System;
using PlannerClient.Model.Group;

namespace PlannerClient.ClientRequest
{
    public class GroupsCollectionRequest : AbstractClientRequest<GroupModel>
    {
        //protected override string GetEndPoint(GroupModel model)
        //{
        //    return "https://graph.microsoft.com/v1.0/groups";
        //}


        protected override string GetEndPoint(object model)
        {
            return "https://graph.microsoft.com/v1.0/groups";
        }


        protected override HttpMethod HttpMethod
        {
            get
            {
                return HttpMethod.Get;
            }
        }
    }
}
