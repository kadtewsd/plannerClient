using System.Collections.Generic;

namespace PlannerClient.Model
{
    //データアクセス結果
    public abstract class AbstractDisplayData<T> where T : AbstractBaseModel
    {

        private RequestResultModel httpResult = null;
        public AbstractDisplayData(RequestResultModel model)
        {
            httpResult = model;
        }

        public RequestResultModel HttpResult
        {
            get
            {
                return httpResult;
            }
        }

        public abstract IList<T> RequestResult { get; set; }
    }
}
