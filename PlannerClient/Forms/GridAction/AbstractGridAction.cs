using PlannerClient.Model;
using PlannerClient.Util.Form;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace PlannerClient.Forms.GridAction
{
    // 型制約を付けると、Java でいうところの ? が表現できなくなるので、制約は取り払う。
    // メソッドでちょろっとジェネリクスしたいだけで、クラスに影響を及ぼすような実装ではないため。
    // T はメソッドで分かっておればよい。
    public abstract class AbstractGridAction//<T> //where T : AbstractBaseModel
    {
        private O365ServiceForm _form = null;

        public AbstractGridAction(O365ServiceForm argForm)
        {
            _form = argForm;
        }

        public O365ServiceForm O365Form
        {
            get
            {
                return _form;
            }
        }

        // 制約があると実装クラスで型を指定しろ、と言われる能勢指定しない。Planner でもこんな実装してる：。
        //IList<AzureADFormatModel<T>> Execute<T>(DataGridViewCellEventArgs e) /* where T : AbstractBaseModel */;

        // 戻り値を採用すると呼び出し元で型を指定しなければならない。
        // 呼び出し元での推論が可能であれば問題はないが、AzureADFormat<T> の T は動的に変わるため、
        // このクラスの中で値をセットしてしまい、値は Form クラスに戻さないことにする。
        public abstract bool ExecuteServiceRequest(DataGridViewCellEventArgs e) /* where T : AbstractBaseModel */;

        public abstract bool CanExecute(DataGridViewCell cell);
        /// <summary>
        /// Graph を実行しなかった場合のグリッドの変更によって影響がある操作を実施します：。
        /// 具体的にはセルの値を変更します。
        /// </summary>
        public abstract void EditCell();

        public abstract void SetCurrentIndex(DataGridViewComboBoxEditingControl e);


        internal void ClearComboBoxCell(string primaryKey)
        {
            IFormMapperDto dto = O365Form.Mapper.GetCellInfo(primaryKey);
            ClearComboBoxCellItems(dto.ColumnName);
            DataGridViewRow row = O365Form.DisplayList.Rows[O365Form.DisplayList.CurrentRow.Index];
            DataGridViewComboBoxCell dropDown = (DataGridViewComboBoxCell)row.Cells[dto.ColumnName];
            IList<ITitleValueModel> unassigned = new List<ITitleValueModel>();
            Type type = dto.ColumnType;

            ITitleValueModel model = O365Form.Helper.CreateUnAssignedValue(type);
            unassigned.Add(model);
            dropDown.DataSource = unassigned;

        }

        private void ClearComboBoxCellItems(string colName)
        {
            DataGridViewRow row = O365Form.DisplayList.Rows[O365Form.DisplayList.CurrentRow.Index];
            DataGridViewComboBoxCell dropDown = (DataGridViewComboBoxCell)row.Cells[colName];
            // 一度 DataSource を Null にしないとエラーが出る。
            // データソース プロパティを設定したときに Items コレクションを変更することはできません。
            dropDown.DataSource = null;
            dropDown.Items.Clear();
        }

        internal void SetComboBox<ListType>(string colName, IList<ListType> list) where ListType : ITitleValueModel
        {
            ClearComboBoxCellItems(colName);
            O365Form.DisplayList.BeginEdit(false);
            //Form.GridPlan.DataSource = bs;
            //Form.GridPlan.BeginEdit(false);
            //dropDown.ValueType = typeof(ITitleValueModel);
            if (list == null)
            {
                return;
            }

            DataGridViewRow row = O365Form.DisplayList.Rows[O365Form.DisplayList.CurrentRow.Index];
            DataGridViewComboBoxCell dropDown = (DataGridViewComboBoxCell)row.Cells[colName];
            //DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dropDown;
            DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)dropDown.OwningColumn;
            Debug.WriteLine(col.Name);
            //List<ITitleValueModel> l = (List<ITitleValueModel>)col.DataSource;
            //IList<ITitleValueModel> combo = new List<ITitleValueModel>();
            foreach (ListType dto in list)
            {
                // これでやると値を変えた時に値が何も選択されていない。SelectedValue 的なものが存在しない。
                //dropDown.Items.Add(new ITitleValueModel { Display = dto.title, Value = dto.id });
                ITitleValueModel model = O365Form.Helper.CreateTitleValueInstance(typeof(ListType), dto.id, dto.title);
                //dropDown.Items.Add(model);
                //かといってこれでやるとドロップダウンを変えた瞬間に unassigned になる。
                //combo.Add(new ITitleValueModel { Display = bucket.name, Value = bucket.id });
                //l.Add (new ITitleValueModel { Display = dto.title, Value = dto.id });
            }
            //dropDown.DataSource = list;
            //Form.GridPlan.EndEdit();
            //Form.GridPlan.EndEdit(DataGridViewDataErrorContexts.Commit);
            dropDown.DataSource = list;
            //Form.GridPlan.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //Form.GridPlan.NotifyCurrentCellDirty(false);
            O365Form.DisplayList.Update();
        }

        protected void SelectFistListItem()
        {

            //((DataGridViewComboBoxColumn) dropDown.OwningColumn ).DataSource = dropDown.Items;
            //dropDown.Value = dropDown.Items;
            // 値をいれたので編集モードにして先頭行を選択
            O365Form.DisplayList.BeginEdit(false);
            DataGridViewComboBoxEditingControl edit = (DataGridViewComboBoxEditingControl)O365Form.DisplayList.EditingControl;
            edit.DroppedDown = true;
            edit.SelectedIndex = 0;

            // true のままにすると editingControlShowing がうごかない。
            edit.DroppedDown = false;
        }

    }
}