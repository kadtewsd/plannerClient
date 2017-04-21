using System;
using System.Collections.Generic;

namespace PlannerClient.Model.User
{
    public class UserDisplayData :AbstractDisplayData<UserModel>
    {

        public UserDisplayData(RequestResultModel model) : base (model)
        {

        }

        public override IList<UserModel> RequestResult
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
