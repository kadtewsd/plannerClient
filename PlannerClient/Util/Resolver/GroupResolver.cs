using PlannerClient.Model.Group;
using PlannerClient.Model.Plan;

namespace PlannerClient.Util.Resolver
{
    public class GroupResolver : IIDResolver<GroupModel>
    {
        public string GetDisplayName(GroupModel model)
        {
            return model.displayName;
        }

        public string GetID(GroupModel model)
        {
            return model.id;
        }
    }
}
