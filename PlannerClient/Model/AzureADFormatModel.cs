using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PlannerClient.Model
{
    [DataContract]
    public class AzureADFormatModel<T> :  AbstractRequestModel<T> where T : AbstractBaseModel 
    {

        public AzureADFormatModel() : base ()
        {
                
        }

        public AzureADFormatModel(RequestResultModel model) : base(model)
        {

        }


        [DataMember]
        public IList<T> value { get; set; }

    }
}