using PlannerClient.Forms;
using PlannerClient.Model;
using PlannerClient.Model.Plan;
using PlannerClient.Util.Form;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PlannerClient.Service
{
    public abstract class AbstractServices<T> : IService<T> where T : AbstractBaseModel
    {

        protected T requestInfo = null;

        internal const string NotExecute = "N/A";

        public AbstractServices(O365ServiceForm form)
        {
            this.Form = form;
            requestInfo = Activator.CreateInstance<T>();

        }
        private int currentCnt = 1;
        public int CurrentCount
        {
            get
            {
                return this.currentCnt;
            }
            set
            {
                this.currentCnt = value;
            }

        }

        protected O365ServiceForm Form { get; private set; }

        public bool ExecuteRequest()
        {
            this.Form.DisableFormState(this.GetType().Name);
            Form.Helper.ClearErrorInfo();

            requestInfo.AccessToken = this.Form.AuthenticationInfo.access_token;
            var response = this.ExecuteRequestInternal();
            bool ret = true;
            if (!response.HttpResult.IsSuccess)
            {
                this.HandlerError(response, this.CurrentCount);
                ret = false;
            }

            this.ObserveIfEnableFormState();
            return ret;
        }

        protected bool HandlerError<ModelType>(AzureADFormatModel<ModelType> response, int i = 1) where ModelType : AbstractBaseModel
        {
            bool ret = true;

            //foreach (ModelType result in response.value)
            //{

            //}
            if (!response.HttpResult.IsSuccess)
            {
                //Tuple<string, string> com = new Tuple<string, string>(x.id, x.id);
                //cmbBuckets.Items.Add(x.id);
                //cmbBuckets.Items.Add(com);
                //source.Add(com);
                Form.Helper.HandleError(response, CurrentCount);
                ret = false;
            }
            return ret;
        }
        protected AzureADFormatModel<T> CreateRequestFailure(RequestResultModel source, T dest, string message) //where SourceType  : AbstractBaseModel //where DestType : AbstractBaseModel
        {
            dest.RequestResult = source;
            dest.RequestResult.ExtraMessage = message;
            AzureADFormatModel<T> result = Activator.CreateInstance<AzureADFormatModel<T>>();
            result.value = new List<T>()
            {
                dest
            };
            return result;
        }
        protected AzureADFormatModel<T> CreateResult(T model)
        {

            AzureADFormatModel<T> result = Activator.CreateInstance<AzureADFormatModel<T>>();
            result.HttpResult = model.RequestResult;
            result.value = new List<T>()
            {
                 model
            };

            return result;
        }
        protected abstract AzureADFormatModel<T> ExecuteRequestInternal();

        protected virtual void ObserveIfEnableFormState()
        {
            this.Form.EnableFormState(this.GetType().Name);
        }

        //protected PlanModel SelectedPlanModel()
        //{
        //    IEnumerable<PlanModel> plans = (IEnumerable<PlanModel>)Form.GridPlan.DataSource;
        //    string planId = (string)this.Form.SelectedPlanRow.Cells[EntityMapper.PlanId].Value;
        //    PlanModel ret = (from n in plans
        //                     where n.id == planId
        //                     select n).First();

        //    return ret;
        //}

        protected void AddErrorInfo(Exception e, AzureADFormatModel<T> resultList)
        {
            T result = (T)Activator.CreateInstance(typeof(T));
            result.RequestResult = new RequestResultModel();
            result.RequestResult.IsSuccess = false;
            result.RequestResult.StackTrace = e.StackTrace;
            result.RequestResult.ExceptionMessage = e.Message;
            resultList.value.ToList().Add(result);
        }


        protected void AddModel(AzureADFormatModel<T> source, AzureADFormatModel<T> dest)
        {
            AddModel(source.value, dest.value);
        }

        protected void AddModel(IEnumerable<T> source, IEnumerable<T> dest)
        {
            source.ToList().ForEach(x =>
              dest.ToList().Add(x)

            );
        }

        protected AzureADFormatModel<T> CreateResultList()
        {
            AzureADFormatModel<T> resultList = Activator.CreateInstance<AzureADFormatModel<T>>();
            resultList.value = Activator.CreateInstance<List<T>>();
            return resultList;
        }

    }
}
