using System.Windows.Forms;
using System;
using PlannerClient.Forms.GridAction;
using System.Text;
using System.Reflection;
using System.Data;
using PlannerClient.Util.Form;
using System.Collections.Generic;
using PlannerClient.Model;

namespace PlannerClient.Forms
{
    internal class FormHelper
    {

        private O365ServiceForm model = null;

        private EntityMapper mapper = null;

        internal const string UnassignedValue = "unassigned";
        public FormHelper(O365ServiceForm argModel)
        {
            model = argModel;
            mapper = new EntityMapper(model);
            BuildGridErrorInfo();
        }

        internal void HideCells()
        {
            DataGridViewColumn column = null;
            for (int i = 0; i < model.DisplayList.Columns.Count; i++)
            {
                column = model.DisplayList.Columns[i];
                foreach (KeyValuePair<string, Type> kv in EntityMapper.HideList)
                {

                    column = model.DisplayList.Columns[kv.Key];
                    if (column == null)
                    {
                        continue;
                    }
                    column.Visible = false;
                }
            }
        }
        private DataTable errorInfo = new DataTable();
        //this.form.GridError.Rows.Clear();


        internal bool FirePlanCellEvent(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return false;
            }
            if (!IsExecuteTargetCell(e))
            {
                return false;
            }
            // イベントが動いてしまうので止めてから Graph を実行して、値を設定し終えたらイベントを設定します：。
            model.DisplayList.EditingControlShowing -= new DataGridViewEditingControlShowingEventHandler(model.grdPlan_EditingControlShowing);
            DataGridViewCell cell = (DataGridViewCell)model.DisplayList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (!CurrentGridAction.CanExecute(cell))
            {

                model.DisplayList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(model.grdPlan_EditingControlShowing);
                return false;
            }
            //FireCellCrickEvent fnc = helper.GetCellClickEvent(cell);
            //IGridAction<T> fnc = helper.GetCellClickEvent(cell);
            bool result = CurrentGridAction.ExecuteServiceRequest(e);
            model.DisplayList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(model.grdPlan_EditingControlShowing);

            return result;
        }

        internal bool CanRegister(DataGridViewEditingControlShowingEventArgs e)
        {
            if (!(e.Control is DataGridViewComboBoxEditingControl))
            {
                return false;
            }
            if (!IsEditTargetCell())
            {
                return false;
            }

            return true;

        }
        // Delegate にすると複雑怪奇なジェネリクスができるのでインターフェースにす：る
        //IDictionary<string, Func<DataGridViewCellEventArgs, IList<AzureADFormatModel<T>>>> list = new Dictionary<string, Func<DataGridViewCellEventArgs, IList<AzureADFormatModel<T>>>>();

        //internal FireCellCrickEvent GetCellClickEvent(DataGridViewCell col)
        //{
        //    return CellEvents[(string)col.OwningColumn.Name];
        //  }
        //internal delegate IList<AzureADFormatModel<T>> FireCellCrickEvent<T>(DataGridViewCellEventArgs e);


        internal bool CollectTasks(DataGridViewCellEventArgs e)
        {

            if (!this.model.taskCollect.ExecuteRequest())
            {
                return false;
            }

            return true;
        }

        public ITitleValueModel CreateTitleValueInstance(Type type, string id, string title)
        {
            ITitleValueModel model = (ITitleValueModel)Activator.CreateInstance(type);
            model.id = id;
            model.title = title;
            return model;
        }
        public ITitleValueModel CreateUnAssignedValue(Type modelType)
        {
            return CreateTitleValueInstance(modelType, FormHelper.UnassignedValue, FormHelper.UnassignedValue);
        }

        internal void CreateCell(string listName)
        {
            GetTargetCell(listName);
        }
        /// <summary>
        /// データをバインドしてもなぜかしらないがコンボボックスの値は自力で書かないといけないらしい。
        /// 非常に面倒くさい。
        /// </summary>
        /// <param name="listName"></param>
        internal void CreateComboBoxCell(string listName)
        {
            IFormMapperDto dto = GetTargetCell(listName);
            DataGridViewComboBoxColumn cellDropDown = (DataGridViewComboBoxColumn)dto.CreatedColumn;
            cellDropDown.DefaultCellStyle.NullValue = FormHelper.UnassignedValue;
            cellDropDown.AutoComplete = true;
            //プロパティの名前を指定するとタスクリストがオブジェクトの名前になる。わけわからん。
            cellDropDown.DataPropertyName = dto.PrimaryKey;
            //DataGridViewにあらかじめ設定したColumnsとDataTableのColumnを
            //cellDropDown.DataPropertyName = dto.HeaderValue;
            //cellDropDown.DataPropertyName = "Self";
            cellDropDown.DataPropertyName = "id";
            cellDropDown.DisplayMember = "title";
            cellDropDown.ValueMember = "id";
            //cellDropDown.ValueMember = "Self";
            //ITitleValueModel dto = new ITitleValueModel { Display = FormHelper.UnassignedValue, Value = FormHelper.UnassignedValue };
            ITitleValueModel unassigned = CreateUnAssignedValue(dto.ColumnType);
            cellDropDown.Items.Add(unassigned);
            //bucketDrop.DisplayIndex = 0;
            cellDropDown.Visible = true;
            //cellDropDown.CellTemplate = new DataGridViewComboBoxCell();
        }
        private IFormMapperDto GetTargetCell(string listName)
        {
            IFormMapperDto dto = mapper.GetCellInfo(listName);
            DataGridViewColumn col = dto.CreateDataColumn();
            col.HeaderText = dto.HeaderValue;
            col.Name = dto.ColumnName;
            col.ValueType = dto.ColumnType;
            model.DisplayList.Columns.Add(col);
            dto.CreatedColumn = col;
            return dto;
        }

        public void HideListColumn(string colName)
        {
            DataGridViewColumn tasks = model.DisplayList.Columns[colName];
            tasks.Visible = false;
        }

        private AbstractGridAction _currentGridAction = null;
        internal AbstractGridAction CurrentGridAction
        {
            private set
            {
                _currentGridAction = value;
            }
            get
            {
                return _currentGridAction;
            }
        }
        internal bool IsExecuteTargetCell(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {
                return false;
            }
            DataGridViewColumn col = model.DisplayList.Columns[e.ColumnIndex];
            //return (col.Name == DelBtnName || col.Name == CreateTaskBtn);
            this._currentGridAction = mapper.GetCellClickEvent(col);
            return _currentGridAction != null;
        }

        internal bool IsEditTargetCell()
        {
            DataGridViewCell col = model.DisplayList.CurrentCell;
            //return (col.Name == DelBtnName || col.Name == CreateTaskBtn);
            string name = col.OwningColumn.Name;
            this._currentGridAction = mapper.GetCellEditEvent(name);
            return _currentGridAction != null;
        }

        internal bool IsSuccess<T>(RequestResultModel result)
        {
            //foreach (var n in result)
            //{
            //    var ret1 = from n1 in n.value
            //}
            return result.IsSuccess;
        }

        public EntityMapper Mapper
        {
            get
            {
                return mapper;
            }
        }
        private void BuildGridErrorInfo()
        {
            //if (i == 1)
            //{
            //this.form.GridError.Columns.Clear();
            //this.form.GridError.Columns.Add(Seq, "#");
            //this.form.GridError.Columns.Add(new DataGridViewColumn("StatusCode", "エラー コード");
            //this.form.GridError.Columns.Add("ExceptionMessage", "エラー メッセージ");
            //this.form.GridError.Columns.Add("StackTrace", "スタックトレース");
            //this.form.GridError.Columns.Add(RequestInfoColumn, "リクエスト情報");
            errorInfo.Rows.Clear();
            model.GridError.Rows.Clear();
            errorInfo.Columns.Clear();
            errorInfo.Columns.Add(Seq);
            errorInfo.Columns.Add(RequestInfoColumn);

            foreach (PropertyInfo propName in (new RequestResultModel()).GetType().GetProperties())
            {
                errorInfo.Columns.Add(propName.Name);
            }
            //}
        }


        const string Seq = "Seq";

        const string RequestInfoColumn = "RequestInfo";

        internal void HandleError<T>(AzureADFormatModel<T> models, int i = 1) where T : AbstractBaseModel
        {

            this.HandleError(models.HttpResult, i);
            if (models.value == null)
            {
                return;
            }
            foreach (T model in models.value)
            {
                int childIdx = 1;
                StringBuilder propInfo = new StringBuilder();
                foreach (PropertyInfo prop in model.GetType().GetProperties())
                {
                    propInfo.Append(prop.Name + " : ");
                    propInfo.Append(prop.GetValue(model));
                }

                DataRow childRow = errorInfo.NewRow();
                //childRow.CreateCells(this.form.GridError);
                childRow[Seq] = i.ToString() + "-" + childIdx.ToString();
                childRow[RequestInfoColumn] = propInfo.ToString();
                errorInfo.Rows.Add(childRow);
                childIdx++;
            }

            model.GridError.DataSource = errorInfo;
        }

        internal void HandleError(RequestResultModel model, int i = 1) //where T : AbstractBaseModel
        {
            //ヘッダー
            DataRow row = errorInfo.NewRow();
            row[Seq] = i.ToString();
            foreach (DataColumn col in errorInfo.Columns)
            {
                if (col.ColumnName == RequestInfoColumn || col.ColumnName == Seq)
                {
                    continue;
                }
                row[col.ColumnName] = model.GetType().GetProperty(col.ColumnName).GetValue(model);
            }
            errorInfo.Rows.Add(row);

            if (this.model.GridError.Rows.Count == 0)
            {
                return;
            }

            this.model.TabResult.SelectedTab = this.model.TabResult.TabPages[this.model.TabError.Name];
        }
        //DataGridView の操作は DataTable の操作と異なりすぎてやりずらい。
        [Obsolete]
        private void SetCells(DataGridView gridView, RequestResultModel model, int idx)
        {

            //DataGridViewRow row = new DataGridViewRow();
            //row.CreateCells(gridView);

            ////form.GridError.Rows.Add(row);
            //row.Cells[0].Value = idx;
            //for (int colCnt = 0; colCnt < gridView.Columns.Count; colCnt++)

            //{
            //    DataGridViewColumn col = gridView.Columns[colCnt];
            //    if (col.Name == RequestInfoColumn || col.Name == Seq)
            //    {
            //        continue;
            //    }
            //    // CellIndex で指定しないと OutOfRange

            //    DataGridViewCell cell = null;
            //    for (int i = 0; i < row.Cells.Count; i++)
            //    {
            //        DataGridViewCell c = row.Cells[i];
            //        if (c.OwningColumn == null)
            //        {
            //            continue;
            //        }
            //        if (c.OwningColumn.Name == col.Name)
            //        {
            //            cell = c;
            //            break;
            //        }
            //    }
            //    if (cell == null)
            //    {
            //        continue;
            //    }
            //    cell.Value = model.GetType().GetProperty(col.Name).GetValue(model);

            //DataTable tbl = (DataTable) gridView.DataSource;



            //値が設定されていないとエラー
            //gridView.Rows.Add(row);
            //    }
        }



        internal void BuildCellButton(DataGridViewRow row)
        {

            //IEnumerable<BucketModel> models = bucketList.value;

            //DataGridViewComboBoxCell cmbBuckets = (DataGridViewComboBoxCell)row.Cells[FormHelper.DropDownBucketColumnName];
            //cmbBuckets.Items.Clear();
            //BindingSource source = new BindingSource();

            //DropDown 設定

            //row.Cells["dropBucketList"].Value = column;
        }

        internal void ClearErrorInfo()
        {
            errorInfo.Rows.Clear();

        }

    }
}
