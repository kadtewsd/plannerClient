using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PlannerClient.Model.Plan
{
    [DataContract]
    public class PlanModel : AbstractBaseModel, ITitleValueModel, IDataListModel<BucketModel>
    {
        [DataMember()]
        public string title { get; set; }
        [DataMember()]
        public string id { get; set; }

        [DataMember()]
        public string owner { get; set; }

        [DataMember()]
        public string createdBy { get; set; }

        public string groupOwner { get; set; }

        public IList<BucketModel> BucketList { get; set; }

        private int _currentIdx = -1;

        public int CurrentChildListIndex
        {
            get
            {
                return _currentIdx;
            }

            set
            {
                _currentIdx = value;
            }
        }

        public BucketModel GetCurrentSubData()
        {
                if (BucketList == null || BucketList.ToList() == null || BucketList.ToList().Count == 0)
                {
                    return null;
                }
                return BucketList.ToList()[CurrentChildListIndex];
        }

        public IList<BucketModel> GetSubDataList()
        {
            throw new NotImplementedException();
        }

        public IList<TaskModel> TaskList
        {
            get
            {
                if (GetCurrentSubData() == null)
                {
                    return null;
                }
                return GetCurrentSubData().TaskList;
            }
            set
            {
                GetCurrentSubData().TaskList = value;
            }
        }

        public string TaskCount
        {
            get
            {
                return TaskList == null ? null : TaskList.Count().ToString();
            }
        }

        public ITitleValueModel Self
        {
            get
            {
                return this;
            }
        }
    }
}
