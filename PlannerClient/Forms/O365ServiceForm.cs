using PlannerClient.Authentication;
using System.Linq;
using PlannerClient.Model.Plan;
using PlannerClient.Model.User;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PlannerClient.Service;
using PlannerClient.Util.Form;
using PlannerClient.Model.Group;
using PlannerClient.Model;
using System.Configuration;

namespace PlannerClient.Forms
{
    /// <summary>
    /// 画面設計をしくりました。タブを使ってことなるサービスをやってるので、インターフェースが微妙です。
    /// </summary>
    public partial class O365ServiceForm : Form, IViewData<PlannerDisplayData, PlanModel>
    {

        private SignInModel model;
        //private SignInService signIn = new SignInService();
        internal IAuthenticationRequest signIn = null;
        internal IPlanCollectionService plan = null;
        internal IUserCollectionService user = null;
        internal IGroupCollectionService group = null;
        internal ILogOutService logOut = null;
        internal ITaskCreationService taskCreation = null;
        internal ITaskDeleteService taskDelete = null;
        internal ITaskCollectionService taskCollect = null;
        internal IBucketAnsTaskCollectionService bucketCollect = null;

        private FormHelper helper = null;

        // プランのデータを格納するデータソース
        private BindingSource planDataSource = null;

        public O365ServiceForm()
        {
            InitializeComponent();
            //this.txtUserName.Text = "admin@kkproj15.onmicrosoft.com";
            this.txtUserName.Text = ConfigurationManager.AppSettings["Username"] + "@" + ConfigurationManager.AppSettings["TenantName"] + ".onmicrosoft.com";
            this.txtPassword.Text = ConfigurationManager.AppSettings["Password"];

            signIn = new PlainAuthenticationRequest(this);
            //signIn = new ADALAuthenticationRequest(this);

            plan = new PlanCollectionService(this);
            user = new UsersCollectionService(this);
            group = new GroupsCollectionService(this);
            logOut = new LogOutService(this);
            taskCreation = new TaskCreationService(this);
            taskDelete = new TaskDeleteService(this);

            taskCollect = new TaskCollectionService(this);
            bucketCollect = new BucketAnsTaskCollectionService(this);
            helper = new FormHelper(this);
            // Grid にさわるごとにがセルの方がへんだとかいうので、もみ消します。
            this.grdPlan.DataError += new DataGridViewDataErrorEventHandler(grdPlan_DataError);
            planDataSource = new BindingSource();
            planDataSource.DataMember = "RequestResult";
            DisplayList.DataSource = planDataSource;
        }

        private async void btnACClick(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            try
            {
                if (model == null || String.IsNullOrEmpty(model.access_token))
                {
                    model = await signIn.DoAuth();
                }
                this.richTextBox1.Text = model.access_token;
            }
            catch (Exception ex)
            {
                this.richTextBox1.Text = ex.Message;
            }

        }

        public SignInModel AuthenticationInfo
        {
            get
            {
                return this.model;
            }
        }

        public string UserName
        {
            get
            {
                return this.txtUserName.Text;
            }
        }

        public string Password
        {
            get
            {
                return this.txtPassword.Text;
            }
        }

        public EntityMapper Mapper
        {
            get
            {
                return this.helper.Mapper;
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            user.ExecuteRequest();
            this.tabResult.SelectedTab = this.tabResult.TabPages[this.tabUsers.Name];
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            this.group.ExecuteRequest();
            this.tabResult.SelectedTab = this.tabResult.TabPages[this.tabGroup.Name];
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            plan.ExecuteRequest();
            this.tabResult.SelectedTab = this.tabResult.TabPages[this.tabPlans.Name];
            if (grdPlan.Columns.Contains(EntityMapper.DropDownBucketColumnName))
            {
                return;
            }

            this.ConsructGridView();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            logOut.ExecuteRequest();
            this.model.access_token = null;
            this.richTextBox1.Text = "";
        }

        internal DataGridView GridUser
        {
            get
            {
                return this.grdUsers;
            }
        }

        internal DataGridView GridGroups
        {
            get
            {
                return this.grdGroups;
            }
        }

        public IList<UserModel> UserList
        {
            get
            {
                return this.grdUsers.DataSource as IList<UserModel>;
            }
        }


        public IList<GroupModel> GroupList
        {
            get
            {
                return this.grdGroups.DataSource as IList<GroupModel>;
            }
        }

        public IList<PlanModel> PlanList
        {
            get
            {
                return this.grdPlan.DataSource as IList<PlanModel>;
            }
        }

        private void ConsructGridView()
        {
            helper.HideCells();
            //DropDown 設定
            helper.CreateComboBoxCell(EntityMapper.BucketList);
            helper.CreateComboBoxCell(EntityMapper.TaskList);

            helper.CreateCell(EntityMapper.CreateTaskBtn);
            helper.CreateCell(EntityMapper.DeleteTaskBtnName);
            helper.CreateCell(EntityMapper.TaskCount);

        }



        internal void DisableFormState(string value)
        {
            this.Enabled = false;
            this.lblStatus.Text = value + "実行中";
            this.Update();
        }

        internal void EnableFormState(string value)
        {
            this.Enabled = true;
            this.lblStatus.Text = value + "完了";
        }

        public DataGridView DisplayList
        {
            get
            {
                return this.grdPlan;
            }
        }

        internal PlanModel GetSelectedPlanModel(int rowIndex)
        {
            //IEnumerator<PlanModel> plans = ((IEnumerable<PlanModel>)this.grdPlan.DataSource).GetEnumerator();
            //PlanModel model = null;
            //int i = 0;
            //while (plans.MoveNext())
            //{
            //    if (i == rowIndex)
            //    {
            //        model = plans.Current;
            //    }
            //    i++;
            //    break;
            //}
            //return model;

            IEnumerable<PlanModel> plans = (IEnumerable<PlanModel>)grdPlan.DataSource;
            return plans.ToList()[rowIndex];
        }

        internal DataGridView GridError
        {
            get
            {
                return this.grdError;
            }
        }

        internal TabControl TabResult
        {
            get
            {
                return this.tabResult;
            }
        }

        internal TabPage TabError
        {
            get
            {
                return this.tabError;
            }
        }

        internal FormHelper Helper
        {
            get
            {
                return this.helper;
            }
        }

        private void grdPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            BindingSource bs = (BindingSource)grdPlan.DataSource;
            PlannerDisplayData data = (PlannerDisplayData)bs.DataSource;
            data.CurrentChildListIndex = e.RowIndex;
            bool ret = helper.FirePlanCellEvent(e);
            if (!ret)
            {
                this.lblStatus.Text = "失敗";
            }
        }


        //イベントの登録
        DataGridViewComboBoxEditingControl ctl = null;
        internal void grdPlan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            bool exec = helper.CanRegister(e);
            if (exec)
            {
                //イベントの登録
                ctl = (DataGridViewComboBoxEditingControl)e.Control;
                ctl.SelectedIndexChanged += new EventHandler(ctl_SelectedIndexChanged);
            }
        }
        private void ctl_SelectedIndexChanged(object sender, EventArgs e)
        {
            helper.CurrentGridAction.SetCurrentIndex(ctl);
            helper.CurrentGridAction.EditCell();
        }
        private void grdPlan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //SelectedIndexChangedイベントハンドラを削除
            if (this.ctl != null)
            {

                this.ctl.SelectedIndexChanged -= new EventHandler(ctl_SelectedIndexChanged);
                this.ctl = null;
            }
        }


        private void grdPlan_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            Console.Write("よくわからないエラーはもみ消しました宇。");
        }

        private void grdPlan_CellErrorTextNeeded(object sender, DataGridViewCellErrorTextNeededEventArgs e)
        {

        }

        public PlannerDisplayData GetDisplayData()
        {
            BindingSource bs = (BindingSource)DisplayList.DataSource;
            PlannerDisplayData data = (PlannerDisplayData)bs.DataSource;
            return data;
        }

        public void SetDisplayData(PlannerDisplayData data)
        {
            BindingSource bs = (BindingSource)DisplayList.DataSource;
            bs.DataSource = data;
        }

        public void SetDisplayData(AzureADFormatModel<PlanModel> data)
        {
            BindingSource bs = (BindingSource)DisplayList.DataSource;
            PlannerDisplayData display = new PlannerDisplayData(data.HttpResult);
            display.CurrentChildListIndex = 0; 
            display.RequestResult = data.value;
            bs.DataSource = display;
        }

    }
}