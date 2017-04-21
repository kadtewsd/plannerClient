using System.Collections.Generic;

namespace PlannerClient.Model
{
    public interface IDataListModel<SubData> where SubData : AbstractBaseModel
    {
        int CurrentChildListIndex { get; set; }

        SubData GetCurrentSubData(); 

        IList<SubData> GetSubDataList(); 

    }
}
