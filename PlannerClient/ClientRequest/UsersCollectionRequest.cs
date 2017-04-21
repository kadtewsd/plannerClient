using PlannerClient.Model.User;
using System.Net.Http;
using System;

namespace PlannerClient.ClientRequest
{
    public class UsersCollectionRequest : AbstractClientRequest<UserModel>
    {
        //protected override string GetEndPoint(UserModel model)
        //{
        //    return "https://graph.microsoft.com/v1.0/users";
        //}


        protected override string GetEndPoint(object model)
        {
            return "https://graph.microsoft.com/v1.0/users";
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
