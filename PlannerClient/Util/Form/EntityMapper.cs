using PlannerClient.Forms;
using PlannerClient.Forms.GridAction;
using PlannerClient.Model.Plan;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PlannerClient.Util.Form
{
    public class EntityMapper
    {
        public EntityMapper(O365ServiceForm model)
        {
            BuildCellEvents(model);
            BuildCellMap();
        }

        public const string RequestResultPropName = "RequestResult";

        public const string DeleteTaskBtnName = "btnDelTask";
        public const string DropDownPlanColumnName = "id";

        public const string CreateTaskBtn = "createTaskBtn";
        public const string PlanId = "id";
        public const string BucketList = "BucketList";
        public const string BucketListTitle = "バケットリスト";
        public const string DropDownBucketColumnName = "dropBucketList";
        public const string TaskList = "TaskList";
        public const string TaskListTitle = "タスクリスト";
        public const string DropDownTaskColumnName = "dropTaskList";

        //public const int DetaultTaskInsertCount = 300;
        public const string TaskCount = "CountColumn";

        public const string TaskColumnName = "TasksColumn";
        public static IDictionary<string, Type> HideList = new Dictionary<string, Type>()
        {
            {BucketList, typeof(IEnumerable<PlanModel>)},
            {TaskList, typeof(IEnumerable<TaskModel>)},
            { "AccessToken", typeof(string) },
            { "etag", typeof(string) },
            { "RequestResult", typeof(string) },
            { "CurrentChildListIndex", typeof(string) },
            { "CurrentRowModel", typeof(string) },
            { "Self", typeof(string) },
            { "TaskCount", typeof(string) },

        };

        private void BuildCellMap()
        {
            cellInfo.Add(new CellMapperDto(DeleteTaskBtnName, "タスク作成"));
            cellInfo.Add(new CellMapperDto(CreateTaskBtn, "タスク削除"));
            cellInfo.Add(new CellMapperDto(TaskCount, "タスク投入/削除件数", typeof(int)));
            cellInfo.Add(new DropDownCellMapperDto(BucketList, DropDownBucketColumnName, BucketListTitle, typeof(PlanModel)));
            cellInfo.Add(new DropDownCellMapperDto(TaskList, DropDownTaskColumnName, TaskListTitle, typeof(PlanModel)));
        }
        private static IList<IFormMapperDto> cellInfo = new List<IFormMapperDto>()
        {
        };

        public IFormMapperDto GetCellInfo(string primaryKey)
        {
            IFormMapperDto ret = null;
            var infoList = cellInfo;
            foreach (IFormMapperDto val in infoList)
            {
                if (primaryKey.Equals(val.PrimaryKey))
                {
                    ret = val;
                    break;
                }
            }
            return ret;
        }

        private static IDictionary<string, AbstractGridAction> cellClick = null; // new Dictionary<string, IGridAction>();
        private static IDictionary<string, AbstractGridAction> editCellEvents = null;
        private void BuildCellEvents(O365ServiceForm model) //where T : AbstractBaseModel
        {
            editCellEvents = new Dictionary<string, AbstractGridAction>();
            editCellEvents.Add(DropDownBucketColumnName, new BucketCollectionGridAction(model));
            cellClick = new Dictionary<string, AbstractGridAction>();
            //IGridAction<TaskModel> task = new TaskCreateGridAction(model);
            //IGridAction<T> task = (IGridAction<T>) Activator.CreateInstance(typeof(TaskCreateGridAction),  model );
            //IGridAction<TaskModel> task = new TaskCreateGridAction(model);

            cellClick.Add(CreateTaskBtn, new TaskCreateGridAction(model));
            cellClick.Add(DeleteTaskBtnName, new TaskDeleteGridAction(model));

            foreach (KeyValuePair<string, AbstractGridAction> kv in editCellEvents)
            {
                cellClick.Add(kv);
            }

            Console.Write("Success");

        }

        public AbstractGridAction GetCellClickEvent(DataGridViewColumn col)
        {
            AbstractGridAction action = null;
            cellClick.TryGetValue(col.Name, out action);
            return action;
        }

        public AbstractGridAction GetCellEditEvent(string colName)
        {
            AbstractGridAction action = null;
            editCellEvents.TryGetValue(colName, out action);
            return action;
        }

        // plan を表示するためのヘッダー/Prop名です。
        public static IDictionary<string, string> DisplayList = new Dictionary<string, string>
        {
                { "title", "プラン名" },
                { "owner", "所有者" },
                { "createdBy", "作成者" },
                { "groupOwner", "グループ所有者" },
        };

    }
}
