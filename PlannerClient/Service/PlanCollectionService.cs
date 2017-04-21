using PlannerClient.Model.Plan;
using PlannerClient.ClientRequest;
using PlannerClient.Util.Resolver;
using System.Collections.Generic;
using System.Linq;
using PlannerClient.Forms;
using System;
using PlannerClient.Model;
using System.Windows.Forms;

namespace PlannerClient.Service
{
    public class PlanCollectionService : AbstractServices<PlanModel>, IPlanCollectionService
    {
        private AbstractClientRequest<PlanModel> planReq = new PlanCollectionRequest();

        private AbstractClientRequest<BucketModel> bucketReq = new BucketCollectRequest();

        private AbstractClientRequest<TaskModel> taskReq = new TaskCollectRequest();

        public PlanCollectionService(O365ServiceForm form) : base(form)
        {
        }

        protected override  AzureADFormatModel<PlanModel> ExecuteRequestInternal()
        {
            AzureADFormatModel<PlanModel> plans = planReq.DoRequest(this.requestInfo).Result;

            if (!base.HandlerError(plans))
            {
                return plans;
            }

            //タスクを取得します
            //this.SetBucketsAndTasks(plans);

            //バケットを取得してタスクも取得します。
            //foreach (PlanModel plan in plans.value)
            //{
            //    BucketModel paramBucket = new BucketModel();
            //    paramBucket.planId = plan.id;
            //    AzureADFormatModel<BucketModel> bucketResult =  this.bucketReq.DoRequest(paramBucket).Result;
            //    plan.BucketList = bucketResult;
            //    this.SetTasksFromBucketList(plan);

            bool result = SetOwnerDisplayName(plans.value, this.Form.UserList, new UserResolver());

            if (!result)
            {
                SetOwnerDisplayName(plans.value, this.Form.GroupList, new GroupResolver());
            }
            //Form にデータソースもセットしてします。
            Form.SetDisplayData(plans);
            return plans;
        }


        private bool SetOwnerDisplayName<T2>(IEnumerable<PlanModel> plans, IList<T2> fromList, Util.Resolver.IIDResolver<T2> resolver) where T2 : AbstractBaseModel
        {
            if (fromList == null)
            {
                return false;
            }

            bool exists = false;
            foreach (PlanModel plan in plans)
            {
                var ret = (from user in fromList
                           where plan.owner == resolver.GetID(user)
                           select resolver.GetDisplayName(user)
                             );
                if (ret.Count() == 0)
                {
                    continue;
                }
                plan.groupOwner = ret.First<string>();
                exists = true;
            }
            return exists;
        }

        [Obsolete()]
        private void SetBucketsAndTasks(AzureADFormatModel<PlanModel> plans)
        {

            //バケット取得
            foreach (PlanModel model in plans.value)
            {

                BucketModel bucket = new BucketModel();
                bucket.planId = model.id;
                bucket.AccessToken = Form.AuthenticationInfo.access_token;

                AzureADFormatModel<BucketModel> buckets = bucketReq.DoRequest(bucket).Result;
                //model.BucketList = buckets;
                this.SetTasksFromBucketList(model);
            }

        }
        [Obsolete()]
        private void SetTasksFromBucketList(PlanModel plan)
        {

            if (plan.BucketList.Count() == 0)
            {
                return;
            }

            foreach (BucketModel bucket in plan.BucketList)
            {
                TaskModel task = new TaskModel();
                task.bucketId = bucket.id;
                task.AccessToken = Form.AuthenticationInfo.access_token;

                AzureADFormatModel<TaskModel> buckets = taskReq.DoRequest(task).Result;
                //bucket.Tasks = buckets;
            }
        }


        [Obsolete()]
        private void SetBucketInfoFromTask(AzureADFormatModel<PlanModel> plans)
        {
            IList<TaskModel> taskList = new List<TaskModel>();

            //バケット取得
            foreach (PlanModel model in plans.value)
            {
                TaskModel taskInfo = new TaskModel();

                taskInfo.planId = model.id;
                taskInfo.AccessToken = Form.AuthenticationInfo.access_token;
                AzureADFormatModel<TaskModel> tasks = taskReq.DoRequest(taskInfo).Result;

                tasks.value.ToList().ForEach(x => taskList.Add(x));
                if (tasks.value != null && tasks.value.Count() != 0)
                {
                    break;
                }
            }

            //JoinPlanAndTasks(plans, taskList);
        }

        //[Obsolete()]
        //private static void JoinPlanAndTasks(AzureADFormatModel<PlanModel> plans, IList<TaskModel> taskList)
        //{
        //    foreach (PlanModel model in plans.value)
        //    {
        //        model.BucketList = new AzureADFormatModel<BucketModel>
        //        {
        //            value = new List<BucketModel>(),
        //        };
        //        IEnumerable<TaskModel> taskInfo = taskList.Where(x =>
        //        {
        //            if (model.id == x.planId)
        //            {
        //                return true;
        //            }
        //            return false;

        //        });

        //        BucketModel bucket = new BucketModel
        //        {
        //            //Tasks = new List<TaskModel>()
        //            Tasks = new AzureADFormatModel<TaskModel>()
        //        };
        //        // タスクがないプラン？
        //        if (taskInfo.Count() == 0)
        //        {
        //            continue;
        //        }

        //        bucket.Tasks.value = new List<TaskModel>();
        //        // バケット設定
        //        bucket.id = taskInfo.First().bucketId;
        //        taskInfo.ToList().ForEach(x => bucket.Tasks.value.ToList().Add(x));
        //        List<BucketModel> bucketList = model.BucketList.value.ToList();
        //        // これでは Add でやっています。
        //        //model.BucketList.value.ToList().Add(bucket);
        //        bucketList.Add(bucket);
        //        model.BucketList.value = bucketList;
        //    }
        //}
    }
}
