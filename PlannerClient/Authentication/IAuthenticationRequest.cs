using PlannerClient.Model.Plan;
using PlannerClient.Model.User;
using System.Threading.Tasks;

namespace PlannerClient.Authentication
{
    interface IAuthenticationRequest
    {
          Task<SignInModel> DoAuth();
    }
}
