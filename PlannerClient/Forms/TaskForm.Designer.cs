namespace PlannerClient.Forms
{
    partial class TaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.assignedTo = new System.Windows.Forms.ComboBox();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.dueDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.PrevType = new System.Windows.Forms.Label();
            this.previewType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.percentComplete = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.assigneePriority = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(60, 22);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(528, 20);
            this.title.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "タイトル";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "割当先";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "開始日";
            // 
            // assignedTo
            // 
            this.assignedTo.FormattingEnabled = true;
            this.assignedTo.Location = new System.Drawing.Point(61, 56);
            this.assignedTo.Name = "assignedTo";
            this.assignedTo.Size = new System.Drawing.Size(121, 21);
            this.assignedTo.TabIndex = 6;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(62, 89);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(200, 20);
            this.startDate.TabIndex = 7;
            // 
            // dueDate
            // 
            this.dueDate.Location = new System.Drawing.Point(62, 117);
            this.dueDate.Name = "dueDate";
            this.dueDate.Size = new System.Drawing.Size(200, 20);
            this.dueDate.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "終了日";
            // 
            // PrevType
            // 
            this.PrevType.AutoSize = true;
            this.PrevType.Location = new System.Drawing.Point(3, 156);
            this.PrevType.Name = "PrevType";
            this.PrevType.Size = new System.Drawing.Size(53, 13);
            this.PrevType.TabIndex = 11;
            this.PrevType.Text = "PrevType";
            // 
            // previewType
            // 
            this.previewType.Location = new System.Drawing.Point(62, 153);
            this.previewType.Name = "previewType";
            this.previewType.Size = new System.Drawing.Size(517, 20);
            this.previewType.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "達成率";
            // 
            // percentComplete
            // 
            this.percentComplete.Location = new System.Drawing.Point(62, 189);
            this.percentComplete.Name = "percentComplete";
            this.percentComplete.Size = new System.Drawing.Size(517, 20);
            this.percentComplete.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "優先度";
            // 
            // assigneePriority
            // 
            this.assigneePriority.Location = new System.Drawing.Point(62, 221);
            this.assigneePriority.Name = "assigneePriority";
            this.assigneePriority.Size = new System.Drawing.Size(517, 20);
            this.assigneePriority.TabIndex = 14;
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 533);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.assigneePriority);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.percentComplete);
            this.Controls.Add(this.PrevType);
            this.Controls.Add(this.previewType);
            this.Controls.Add(this.dueDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.assignedTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Name = "TaskForm";
            this.Text = "TaskForm";
            this.Load += new System.EventHandler(this.TaskForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox assignedTo;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DateTimePicker dueDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label PrevType;
        private System.Windows.Forms.TextBox previewType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox percentComplete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox assigneePriority;
    }
}