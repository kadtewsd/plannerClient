using PlannerClient.Model;
using PlannerClient.Model.Plan;
using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace PlannerClient.ClientRequest
{
    public abstract class AbstractClientRequest<T> where T : AbstractBaseModel
    {
        private HttpRequestMessage request = null;


        public  async Task<AzureADFormatModel<T>> DoRequest(T requestInfo)
        {
            Task<AzureADFormatModel<T>> result =  DoRequest<T>(requestInfo);
            return result.Result;
        }

        public async Task<AzureADFormatModel<T>> DoRequest<InputType>(InputType requestInfo) where InputType : AbstractBaseModel
        {
            string ac = requestInfo.AccessToken;
            AzureADFormatModel<T> result = Activator.CreateInstance<AzureADFormatModel<T>>();

            using (HttpClient httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(this.HttpMethod, this.GetEndPoint(requestInfo)))
                {
                    this.CreateParameter(request, requestInfo);

                    request.Headers.Add("Authorization", string.Format("Bearer {0}", ac));
                    using (HttpResponseMessage response = httpClient.SendAsync(request).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var stream = await response.Content.ReadAsStreamAsync();

                            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AzureADFormatModel<T>));
                            try
                            {
                                // プロパティがシリアライズする型と合わないと、
                                // End element 'groupTypes' from namespace '' expected. Found element 'item' from namespace ''.
                                // というメッセージが出ます。大体配列なのに配列のプロパティではない、という場合です。
                                result = (AzureADFormatModel<T>)serializer.ReadObject(stream);
                                result.HttpResult = new RequestResultModel();
                                result.HttpResult.IsSuccess = true;
                            }
                            catch (Exception e)
                            {
                                Console.Write("request is failed..." + e.Message);
                                result.HttpResult.IsSuccess = false;
                                result.HttpResult.StackTrace = e.StackTrace;
                                result.HttpResult.ExceptionMessage = e.Message;
                            }
                            result.JSON = response.Content.ReadAsStringAsync().Result;
                        }
                        else
                        {
                            result.HttpResult.IsSuccess = false;
                            result.HttpResult.ExceptionMessage = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }

            result.HttpResult.HasExecuted = true;
            return result;
        }

        protected abstract HttpMethod HttpMethod { get; }

        //protected abstract string GetEndPoint(T form);

        //protected virtual void CreateParameter(HttpRequestMessage request, T form)
        //{
        //    return;
        //}
        protected abstract string GetEndPoint(object form);

        protected virtual void CreateParameter(HttpRequestMessage request, object form)
        {
            return;
        }
    }
}
