using PlannerClient.Model.Plan;

namespace PlannerClient.Service
{
    interface ITaskCreationService  : IService<TaskModel>
    {
        TaskModel RequestInfo { get; }
    }
}
