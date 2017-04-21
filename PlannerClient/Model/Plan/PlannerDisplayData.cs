using System;
using System.Collections.Generic;
using System.Linq;

namespace PlannerClient.Model.Plan
{
    public class PlannerDisplayData : AbstractDisplayData<PlanModel>, IDataListModel<PlanModel>
    {
        public PlannerDisplayData(RequestResultModel httpResult) : base(httpResult)
        {

        }
        private int _current = -1;

        public int CurrentChildListIndex
        {
            get
            {
                return _current;
            }

            set
            {
                _current = value;
            }
        }

        public PlanModel GetCurrentSubData()
        {
                return RequestResult.ToList()[CurrentChildListIndex];
        }

        public IList<PlanModel> GetSubDataList()
        {
            return RequestResult.ToList();
        }

        public override IList<PlanModel> RequestResult { get; set; }

        //public IList<BucketModel> BucketList
        //{
        //    get
        //    {
        //        return CurrentRowModel.BucketList;
        //    }
        //    set
        //    {
        //        CurrentRowModel.BucketList = value;
        //    }
        //}

        //public IList<TaskModel> TaskList
        //{
        //    get
        //    {
        //        return CurrentRowModel.CurrentRowModel.TaskList;
        //    }
        //    set
        //    {
        //        CurrentRowModel.CurrentRowModel.TaskList = value;
        //    }

        //}
    }
}