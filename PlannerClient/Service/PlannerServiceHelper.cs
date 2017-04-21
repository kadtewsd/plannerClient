using PlannerClient.Forms;
using PlannerClient.Model.Plan;
using System.Collections.Generic;

namespace PlannerClient.Service
{
    public class PlannerServiceHelper
    {
        O365ServiceForm _form = null;
        public PlannerServiceHelper(O365ServiceForm form)
        {
            _form = form;
        }

        private PlannerDisplayData DataSource 
        {
            get
            {
                PlannerDisplayData bd = (PlannerDisplayData)_form.DisplayList.DataSource;
                return bd;
                
            }
        }

        public IEnumerable<TaskModel> GetCurrentTaskList()
        {
            return DataSource.GetCurrentSubData().TaskList;
        }
    }
}
