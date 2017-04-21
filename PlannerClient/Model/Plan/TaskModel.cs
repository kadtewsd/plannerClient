using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PlannerClient.Model.Plan
{
    [DataContract]

    public class TaskModel : AbstractBaseModel, ITitleValueModel, IDataListModel<TaskModel>
    {
        [DataMember()]
        public string planId { get; set; }

        [DataMember()]
        public string bucketId { get; set; }

        [DataMember()]
        public string id { get; set; }

        [DataMember()]
        public string title { get; set; }
        [DataMember()]
        public string assignedTo { get; set; }

        [DataMember()]
        public string orderHint { get; set; }

        [DataMember()]
        public string startDate { get; set; }

        [DataMember()]
        public string dueDate { get; set; }

        [DataMember()]
        public string previewType { get; set; }

        [DataMember()]
        public string conversationThreadId { get; set; }

        [DataMember()]
        public string assigneePriority { get; set; }

        [DataMember()]
        public string percentComplete { get; set; }

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

        public ITitleValueModel Self
        {
            get
            {
                return this;
            }
        }

        public TaskModel GetCurrentSubData()
        {
            throw new NotImplementedException();
        }

        public IList<TaskModel> GetSubDataList()
        {
            throw new NotImplementedException();
        }
    }
}
