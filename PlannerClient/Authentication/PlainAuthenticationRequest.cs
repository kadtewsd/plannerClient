using PlannerClient.Forms;
using PlannerClient.Model.User;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Configuration;

namespace PlannerClient.Authentication
{
    public class PlainAuthenticationRequest : IAuthenticationRequest
    {

        private O365ServiceForm form = null;

        public PlainAuthenticationRequest(O365ServiceForm argForm)
        {
            form = argForm;
        }

        public async Task<SignInModel> DoAuth()
        {
            string authrityUri = this.CreateAuthorityUri();

            SignInModel result = new SignInModel();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, authrityUri))
                {
                    request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"grant_type","password"},
                        {"client_id", ConfigurationManager.AppSettings["ClientId"] },
                        {"resource",ConfigurationManager.AppSettings["ResourceUri"] },
                        //{"resource","https%3A%2F%2Flocalhost%2FClientApps" },
                        {"redirect_uri","https://localhost:44300"},
                        {"username",this.form.UserName},
                        {"password",this.form.Password}
                    });
                   
                    using (HttpResponseMessage response = httpClient.SendAsync(request).Result)
                    {
                        var stream = await response.Content.ReadAsStreamAsync();

                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(SignInModel));
                        try
                        {
                            // プロパティがシリアライズする型と合わないと、
                            // End element 'groupTypes' from namespace '' expected. Found element 'item' from namespace ''.
                            // というメッセージが出ます。大体配列なのに配列のプロパティではない、という場合です。
                            result = (SignInModel) serializer.ReadObject(stream);
                        }
                        catch (Exception e)
                        {
                            Console.Write("request is failed..." + e.Message);
                        }
                    }
                }
            }
            return result;
        }

        private string CreateAuthorityUri()
        {
            //return AuthenticationConst.Authority + "/common/oauth2/authorize?" +
            //        "response_type=code" +
            //        "&client_id=" + AuthenticationConst.ClientId +
            //        "&resource=https%3A%2F%2Fgraph.microsoft.com" +
            //        "&redirect_uri=https%3A%2F%2Flocalhost%3A44300";
            return ConfigurationManager.AppSettings["LoginUri"] + "/common/oauth2/token";
        }

    }
}
