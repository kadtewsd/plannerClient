using System;
using System.Windows.Forms;

namespace PlannerClient.Util.Form
{
    public interface IFormMapperDto
    {
         string PrimaryKey { get; set; }

         string HeaderValue { get; set; }

         string ColumnName { get; set; }

         Type ColumnType { get; set; }

        DataGridViewColumn CreateDataColumn();

        DataGridViewColumn CreatedColumn { get; set; }
    }
}
