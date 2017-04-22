using Microsoft.IdentityModel.Clients.ActiveDirectory;
using PlannerClient.Forms;
using PlannerClient.Model.User;
using System;
using System.Threading.Tasks;
using System.Configuration;

namespace PlannerClient.Authentication
{
    public class ADALAuthenticationRequest : IAuthenticationRequest
    {

        private O365ServiceForm form = null;

         public ADALAuthenticationRequest(O365ServiceForm argForm)
         {
            this.form = argForm;
         }

        public async Task<SignInModel> DoAuth()
        {
            AuthenticationContext ac = new AuthenticationContext(ConfigurationManager.AppSettings["LoginUri"] + "/common");
            //AuthenticationResult ar = await ac.AcquireTokenAsync(ResourceUri, cred);
            UserIdentifier identity = new UserIdentifier(form.UserName, UserIdentifierType.RequiredDisplayableId);
            AuthenticationResult ar = ac.AcquireToken(
                ConfigurationManager.AppSettings["ResourceUri"],
                ConfigurationManager.AppSettings["ClientId"],
                new Uri("https://localhost:44300/")
                , PromptBehavior.Auto // prompt behavior
               // , UserIdentifier.AnyUser // user identifier
               , identity
            );

            //var result = ac.AcquireToken(ResourceUri, cred, assertion);
            //var result = ac.AcquireToken(ResourceUri, assertion, userAssertion);

            SignInModel model = new SignInModel();
            model.access_token = ar.AccessToken;
            
            //model.AccessToken = result.AccessToken;
            return model;
        }
    }
}
