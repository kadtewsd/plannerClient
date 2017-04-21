using System;
using System.Windows.Forms;

namespace PlannerClient.Util.Form
{
    public class DropDownCellMapperDto : CellMapperDto
    {
        public DropDownCellMapperDto(string primaryKey, string columnName, string headerName, Type type) : base(columnName, headerName, type)
        {
            PrimaryKey = primaryKey;
        }

        public override string PrimaryKey { get; set; }


        public override DataGridViewColumn CreateDataColumn()
        {
            return new DataGridViewComboBoxColumn();
        }

    }
}
