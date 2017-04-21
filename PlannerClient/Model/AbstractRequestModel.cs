using System.Runtime.Serialization;

namespace PlannerClient.Model
{

    [DataContract]
    public abstract class AbstractRequestModel<T>
    {

        public AbstractRequestModel(RequestResultModel model)
        {

            HttpResult = model;
        }

        public AbstractRequestModel()
        {

            HttpResult = new RequestResultModel();
        }

        public RequestResultModel HttpResult { get; set; }

        public string JSON { get; set; }
    }
}
