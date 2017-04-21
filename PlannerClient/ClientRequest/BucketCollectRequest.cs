using PlannerClient.Model.Plan;
using System.Net.Http;

namespace PlannerClient.ClientRequest
{
    public class BucketCollectRequest : AbstractClientRequest<BucketModel>
    {
        protected override HttpMethod HttpMethod
        {
            get
            {
                return HttpMethod.Get;
            }
        }

        //protected override string GetEndPoint(BucketModel form)
        //{
        //    // bucket Id
        //    //return "https://graph.microsoft.com/beta/buckets/" + form.id;

        //    return "https://graph.microsoft.com/beta/plans/" + form.planId +  "/buckets";
        //}

        protected override string GetEndPoint(object form)
        {
            PlanModel plan = (PlanModel)form;
            return "https://graph.microsoft.com/beta/plans/" + plan.id +  "/buckets";
        }
    }
}
