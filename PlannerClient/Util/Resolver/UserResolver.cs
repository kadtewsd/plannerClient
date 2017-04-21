using PlannerClient.Model.User;

namespace PlannerClient.Util.Resolver
{
    public class UserResolver : IIDResolver<UserModel>
    {
        public string GetDisplayName(UserModel model)
        {
            return model.displayName;
        }

        public string GetID(UserModel model)
        {
            return model.id;
        }
    }
}
