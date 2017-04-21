using System.Runtime.Serialization;

namespace PlannerClient.Model.User
{
    [DataContract]
    public class SignInModel : AbstractBaseModel
    {
        [DataMember()]
        public string access_token { get; set; }
        [DataMember()]
        public string expires_in { get; set; }
        [DataMember()]
        public string expires_on { get; set; }
        [DataMember()]
        public string ext_expires_in { get; set; }
        [DataMember()]
        public string not_before { get; set; }
        [DataMember()]
        public string refresh_token { get; set; }
        [DataMember()]
        public string resource { get; set; }
        [DataMember()]
        public string scope { get; set; }
        [DataMember()]
        public string token_type { get; set; }

    }
}
