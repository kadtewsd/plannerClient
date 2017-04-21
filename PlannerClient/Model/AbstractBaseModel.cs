using System.Runtime.Serialization;

namespace PlannerClient.Model
{
    [DataContract]
    public abstract class AbstractBaseModel
    {

        public AbstractBaseModel()
        {
            RequestResult = new RequestResultModel();
        }
        public string AccessToken { get; set; }

        private string _etag = null;
        //W/\"JzEtMDAwMDAwMDAwMDAwMDAwMi8yMDE3LTAxLTExVDExOjU5OjU1LjY3MzM0MjErMDA6MDAn\"
        [DataMember(Name = "@odata.etag")]
        public string etag
        {
            get
            {
                 return _etag;
                //return _etag.Replace("W/", "").Replace("\"", "").Replace("\\", "");
            }
            set
            {
                _etag = value;
            }
        }

        public RequestResultModel RequestResult { get; set; }
    }   
}
