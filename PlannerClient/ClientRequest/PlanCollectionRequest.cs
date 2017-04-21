using PlannerClient.Model.Plan;
using System.Net.Http;

namespace PlannerClient.ClientRequest
{
    public class PlanCollectionRequest : AbstractClientRequest<PlanModel>
    {

        protected override HttpMethod HttpMethod
        {
            get
            {
                return HttpMethod.Get;
            }
        }

        //protected override string GetEndPoint(PlanModel form)
        //{
        //    return "https://graph.microsoft.com/beta/me/plans";
        //}


        protected override string GetEndPoint(object form)
        {
            return "https://graph.microsoft.com/beta/me/plans";
        }

    }
}
