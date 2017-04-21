using System;
using System.Windows.Forms;

namespace PlannerClient.Util.Form
{
    public class CellMapperDto : IFormMapperDto
    {
        public CellMapperDto(string columnName, string headerName, Type type)
        {
            ColumnName = columnName;
            HeaderValue = headerName;
            ColumnType = type;
        }

        public CellMapperDto(string columnName, string headerName) : this(columnName, headerName, null)
        {
        }

        public virtual string PrimaryKey
        {
            get
            {
                return this.ColumnName;
            }
            set
            {
                ColumnName = value;
            }
        }
        public string HeaderValue { get; set; }

        public string ColumnName { get; set; }

        private Type _type = null;
        public Type ColumnType
        {
            get
            {
                //三項演算子省略タイプ。Null ならstring
                return _type ?? typeof(string);
            }
            set
            {
                _type = value;
            }
        }
        /// <summary>
        /// 型の指定がなければボタン。あればテキスト
        /// </summary>
        /// <returns></returns>
        public virtual DataGridViewColumn CreateDataColumn()
        {
            DataGridViewColumn col = null;
            if (_type == null)
            {
                col = new DataGridViewButtonColumn();
            }
            else
            {
                col = new DataGridViewTextBoxColumn();
            }
            return col;
        }

        private DataGridViewColumn _col = null;
        public DataGridViewColumn CreatedColumn
        {
            get
            {
                return _col;
            }
            set
            {
                _col = value;
            }
        }
    }
}
