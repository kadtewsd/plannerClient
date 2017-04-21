using System.Runtime.Serialization;

namespace PlannerClient.Model.User
{

    [DataContract]
    public class UserModel : AbstractBaseModel
    {
        [DataMember()]
        public string id { get; set; }
        [DataMember()]
        public string[] businessPhones { get; set; }
        [DataMember()]
        public string displayName { get; set; }
        [DataMember()]
        public string givenName { get; set; }
        [DataMember()]
        public string jobTitle { get; set; }
        [DataMember()]
        public string mail { get; set; }
        [DataMember()]
        public string mobilePhone { get; set; }
        [DataMember()]
        public string officeLocation { get; set; }
        [DataMember()]
        public string preferredLanguage { get; set; }
        [DataMember()]
        public string surname { get; set; }
        [DataMember()]
        public string userPrincipalName { get; set; }
    }
}
