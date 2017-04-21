using PlannerClient.Model.Plan;

namespace PlannerClient.Service
{
    interface ITaskDeleteService : IService<TaskModel>
    {
        TaskModel RequestInfo { get; }
    }
}
