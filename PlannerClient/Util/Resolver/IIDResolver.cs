using PlannerClient.Model;
using PlannerClient.Model.Plan;

namespace PlannerClient.Util.Resolver
{
    interface IIDResolver<T> where T : AbstractBaseModel
    {
        string GetID(T model);

        string GetDisplayName(T model);
    }
}
