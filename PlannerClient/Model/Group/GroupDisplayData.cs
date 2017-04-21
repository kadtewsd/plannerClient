using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerClient.Model.Group
{
    public class GroupDisplayData : AbstractDisplayData<GroupModel>
    {
        public GroupDisplayData(RequestResultModel model) :base(model)
        {

        }
        public override IList<GroupModel> RequestResult
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
