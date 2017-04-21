using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PlannerClient.Model.Plan
{
    [DataContract]
    public class BucketModel : AbstractBaseModel, ITitleValueModel, IDataListModel<TaskModel>
    {
        [DataMember()]
        public string name { get; set; }
        [DataMember()]
        public string id { get; set; }

        [DataMember()]
        public string planId { get; set; }

        [DataMember()]
        public string orderHint { get; set; }

        public AzureADFormatModel<TaskModel> Tasks { get; set; }

        public string title
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        private int _currentIndex = -1;
        public int CurrentChildListIndex
        {
            get
            {
                return _currentIndex;
            }
            set
            {
                _currentIndex = value;
            }
        }
        public IList<TaskModel> TaskList { get; set; }

        public ITitleValueModel Self
        {
            get
            {
                return this;
            }
        }

        public TaskModel GetCurrentSubData()
        {
            if (TaskList == null)
            {
                return null;
            }


            return TaskList.ToList()[CurrentChildListIndex];
        }

        public IList<TaskModel> GetSubDataList()
        {
            string bucketId = id;
            if (TaskList == null)
            {
                return null;
            }
            IEnumerable<TaskModel> targetTasks = from n in TaskList
                                                 where n.bucketId == bucketId
                                                 select n;
            return targetTasks.ToList();
        }
    }
}
