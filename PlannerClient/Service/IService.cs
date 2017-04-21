using PlannerClient.Model;

namespace PlannerClient.Service
{
    public interface IService<T> where T : AbstractBaseModel
    {
        bool ExecuteRequest();

        int CurrentCount { get; set; }
    }
}
