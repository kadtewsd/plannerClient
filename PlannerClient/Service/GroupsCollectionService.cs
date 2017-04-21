using PlannerClient.ClientRequest;
using PlannerClient.Forms;
using PlannerClient.Model.Group;
using PlannerClient.Model;

namespace PlannerClient.Service
{
    public class GroupsCollectionService : AbstractServices<GroupModel>, IGroupCollectionService
    {

        public GroupsCollectionService(O365ServiceForm form) : base(form) { }

        private AbstractClientRequest<GroupModel> group = new GroupsCollectionRequest();

        protected override AzureADFormatModel<GroupModel> ExecuteRequestInternal()
        {
            var ret = group.DoRequest(this.requestInfo).Result;
            this.Form.GridGroups.DataSource = ret.value;
            return ret;
        }

    }
}
