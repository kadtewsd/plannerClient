using PlannerClient.Model;
using System.Windows.Forms;

namespace PlannerClient.Forms
{
    interface IViewData<DisplayData, ViewModel> where DisplayData  : AbstractDisplayData<ViewModel> where ViewModel : AbstractBaseModel
    {
        DisplayData GetDisplayData();

        void SetDisplayData(DisplayData data);

        DataGridView DisplayList { get; }

    }
}
