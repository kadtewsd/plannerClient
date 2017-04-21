using System.Net.Http;
using PlannerClient.Model.User;

namespace PlannerClient.ClientRequest
{
    public class LogOut : AbstractClientRequest<UserModel>
    {
        //protected override string GetEndPoint(UserModel model)
        //{
        //    return "https://login.microsoftonline.com/common/oauth2/logout?post_logout_redirect_uri=https://localhost:44300/"; 
        //}


        protected override string GetEndPoint(object model)
        {
            return "https://login.microsoftonline.com/common/oauth2/logout?post_logout_redirect_uri=https://localhost:44300/";
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
