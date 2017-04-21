using System.Runtime.Serialization;

namespace PlannerClient.Model.Group
{

    [DataContract]
    public class GroupModel : AbstractBaseModel
    {
        [DataMember()]
        public string id { get; set; }
        [DataMember()]
        public string classification { get; set; }
        [DataMember()]
        public string createdDateTime { get; set; }
        [DataMember()]
        public string description { get; set; }
        [DataMember()]
        public string displayName { get; set; }
        [DataMember()]
        public string[] groupTypes { get; set; }
        [DataMember()]
        public string mail { get; set; }
        [DataMember()]
        public string mailEnabled { get; set; }
        [DataMember()]
        public string mailNickname { get; set; }
        [DataMember()]
        public string onPremisesLastSyncDateTime { get; set; }
        [DataMember()]
        public string onPremisesSecurityIdentifier { get; set; }
        [DataMember()]
        public string onPremisesSyncEnabled { get; set; }
        [DataMember()]
        public string[] proxyAddresses { get; set; }
        [DataMember()]
        public string renewedDateTime { get; set; }
        [DataMember()]
        public string securityEnabled { get; set; }
        [DataMember()]
        public string visibility { get; set; }
    }
}
