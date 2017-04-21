using PlannerClient.ClientRequest;
using PlannerClient.Model.User;
using PlannerClient.Forms;
using PlannerClient.Model;

namespace PlannerClient.Service
{
    public class LogOutService : AbstractServices<UserModel> , ILogOutService
    {
        public LogOutService(O365ServiceForm form) : base(form) { }

        private AbstractClientRequest<UserModel> logOut = new LogOut();
        
        protected override AzureADFormatModel<UserModel> ExecuteRequestInternal()
        {
            return this.logOut.DoRequest(this.requestInfo).Result;
        }
    }
}
