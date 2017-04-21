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
            //string clientId = "cd898122-b3e3-4df7-af28-d2d24d6b3db5";
            //const string clientId = "85e5ebc0-b31f-4cd7-b8a4-fc55602ecfcd"; //Web App for kasakaid。マルチテナントアプリは、Web Apps にしないといけない。マルチテナントアプリでないと同意は現れない。
            //string clientSecret = "lF98J/T3ZKbhwTR/l9ylfzKjw7PqTvWHxQZ6/f1ZtAw=";
            //string clientId = "184e570f-cb22-4987-bad4-2a6d559bcd77";// Native アプリ。Native アプリは同意がない。ただし、そのテナントでないと使えない。
            //UserAssertion user = new UserAssertion();
            //ClientAssertionCertificate clientAssertion = new ClientAssertionCertificate(;
            //ClientCredential cred = new ClientCredential(clientId, clientSecret);

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
