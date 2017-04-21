namespace PlannerClient.Forms
{
    partial class O365ServiceForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAC = new System.Windows.Forms.Button();
            this.tabResult = new System.Windows.Forms.TabControl();
            this.AccessToken = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.grdUsers = new System.Windows.Forms.DataGridView();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.grdGroups = new System.Windows.Forms.DataGridView();
            this.tabPlans = new System.Windows.Forms.TabPage();
            this.grdPlan = new System.Windows.Forms.DataGridView();
            this.tabError = new System.Windows.Forms.TabPage();
            this.grdError = new System.Windows.Forms.DataGridView();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnPlan = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabResult.SuspendLayout();
            this.AccessToken.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            this.tabGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroups)).BeginInit();
            this.tabPlans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlan)).BeginInit();
            this.tabError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdError)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAC
            // 
            this.btnAC.Location = new System.Drawing.Point(16, 12);
            this.btnAC.Name = "btnAC";
            this.btnAC.Size = new System.Drawing.Size(105, 23);
            this.btnAC.TabIndex = 0;
            this.btnAC.Text = "サインインする";
            this.btnAC.UseVisualStyleBackColor = true;
            this.btnAC.Click += new System.EventHandler(this.btnACClick);
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.AccessToken);
            this.tabResult.Controls.Add(this.tabUsers);
            this.tabResult.Controls.Add(this.tabGroup);
            this.tabResult.Controls.Add(this.tabPlans);
            this.tabResult.Controls.Add(this.tabError);
            this.tabResult.Location = new System.Drawing.Point(12, 63);
            this.tabResult.Name = "tabResult";
            this.tabResult.SelectedIndex = 0;
            this.tabResult.Size = new System.Drawing.Size(891, 383);
            this.tabResult.TabIndex = 2;
            // 
            // AccessToken
            // 
            this.AccessToken.Controls.Add(this.richTextBox1);
            this.AccessToken.Location = new System.Drawing.Point(4, 22);
            this.AccessToken.Name = "AccessToken";
            this.AccessToken.Padding = new System.Windows.Forms.Padding(3);
            this.AccessToken.Size = new System.Drawing.Size(883, 357);
            this.AccessToken.TabIndex = 0;
            this.AccessToken.Text = "AccessToken";
            this.AccessToken.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(877, 348);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.grdUsers);
            this.tabUsers.Location = new System.Drawing.Point(4, 22);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(883, 357);
            this.tabUsers.TabIndex = 1;
            this.tabUsers.Text = "Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // grdUsers
            // 
            this.grdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsers.Location = new System.Drawing.Point(-4, 0);
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.Size = new System.Drawing.Size(840, 359);
            this.grdUsers.TabIndex = 0;
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.grdGroups);
            this.tabGroup.Location = new System.Drawing.Point(4, 22);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Size = new System.Drawing.Size(883, 357);
            this.tabGroup.TabIndex = 3;
            this.tabGroup.Text = "Groups";
            this.tabGroup.UseVisualStyleBackColor = true;
            // 
            // grdGroups
            // 
            this.grdGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGroups.Location = new System.Drawing.Point(-4, 0);
            this.grdGroups.Name = "grdGroups";
            this.grdGroups.Size = new System.Drawing.Size(891, 359);
            this.grdGroups.TabIndex = 0;
            // 
            // tabPlans
            // 
            this.tabPlans.Controls.Add(this.grdPlan);
            this.tabPlans.Location = new System.Drawing.Point(4, 22);
            this.tabPlans.Name = "tabPlans";
            this.tabPlans.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlans.Size = new System.Drawing.Size(883, 357);
            this.tabPlans.TabIndex = 2;
            this.tabPlans.Text = "Plans";
            this.tabPlans.UseVisualStyleBackColor = true;
            // 
            // grdPlan
            // 
            this.grdPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPlan.Location = new System.Drawing.Point(0, 0);
            this.grdPlan.Name = "grdPlan";
            this.grdPlan.Size = new System.Drawing.Size(880, 359);
            this.grdPlan.TabIndex = 0;
            this.grdPlan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPlan_CellClick);
            this.grdPlan.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPlan_CellEndEdit);
            this.grdPlan.CellErrorTextNeeded += new System.Windows.Forms.DataGridViewCellErrorTextNeededEventHandler(this.grdPlan_CellErrorTextNeeded);
            this.grdPlan.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdPlan_EditingControlShowing);
            // 
            // tabError
            // 
            this.tabError.Controls.Add(this.grdError);
            this.tabError.Location = new System.Drawing.Point(4, 22);
            this.tabError.Name = "tabError";
            this.tabError.Padding = new System.Windows.Forms.Padding(3);
            this.tabError.Size = new System.Drawing.Size(883, 357);
            this.tabError.TabIndex = 4;
            this.tabError.Text = "Error";
            this.tabError.UseVisualStyleBackColor = true;
            // 
            // grdError
            // 
            this.grdError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdError.Location = new System.Drawing.Point(3, 3);
            this.grdError.Name = "grdError";
            this.grdError.Size = new System.Drawing.Size(880, 356);
            this.grdError.TabIndex = 0;
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(127, 12);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(91, 23);
            this.btnUser.TabIndex = 3;
            this.btnUser.Text = "ユーザー取得";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnPlan
            // 
            this.btnPlan.Location = new System.Drawing.Point(308, 12);
            this.btnPlan.Name = "btnPlan";
            this.btnPlan.Size = new System.Drawing.Size(72, 23);
            this.btnPlan.TabIndex = 4;
            this.btnPlan.Text = "プラン取得";
            this.btnPlan.UseVisualStyleBackColor = true;
            this.btnPlan.Click += new System.EventHandler(this.btnPlan_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(608, 15);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(235, 19);
            this.txtUserName.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(608, 39);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(235, 19);
            this.txtPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(584, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(549, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(386, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "サインアウト";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(224, 12);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(78, 23);
            this.btnGroup.TabIndex = 9;
            this.btnGroup.Text = "グループ取得";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(333, 45);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 12);
            this.lblStatus.TabIndex = 10;
            // 
            // O365ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 457);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnPlan);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.tabResult);
            this.Controls.Add(this.btnAC);
            this.Name = "O365ServiceForm";
            this.Text = "Form1";
            this.tabResult.ResumeLayout(false);
            this.AccessToken.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            this.tabGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGroups)).EndInit();
            this.tabPlans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPlan)).EndInit();
            this.tabError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAC;
        private System.Windows.Forms.TabControl tabResult;
        private System.Windows.Forms.TabPage AccessToken;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabPlans;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnPlan;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grdUsers;
        private System.Windows.Forms.DataGridView grdPlan;
        private System.Windows.Forms.TabPage tabGroup;
        private System.Windows.Forms.DataGridView grdGroups;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.TabPage tabError;
        private System.Windows.Forms.DataGridView grdError;
        private System.Windows.Forms.Label lblStatus;
    }
}

