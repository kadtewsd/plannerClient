using PlannerClient.ClientRequest;
using PlannerClient.Forms;
using PlannerClient.Model;
using PlannerClient.Model.User;

namespace PlannerClient.Service
{
    public class UsersCollectionService : AbstractServices<UserModel>, IUserCollectionService
    {
        public UsersCollectionService(O365ServiceForm form) : base(form)
        {
        }

        protected override AzureADFormatModel<UserModel> ExecuteRequestInternal()
        {
            AbstractClientRequest<UserModel> user = new UsersCollectionRequest();
            var result = user.DoRequest(this.requestInfo).Result;
            this.Form.GridUser.DataSource = result.value; 
            return result;       
        }

    }
}
