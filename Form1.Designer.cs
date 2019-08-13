namespace IQIYI.PlayList
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnGetUrl = new System.Windows.Forms.Button();
            this.btnDowload = new System.Windows.Forms.Button();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "播单地址";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(70, 6);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(708, 21);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "http://www.iqiyi.com/playlist557766302.html";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Title,
            this.Url,
            this.State});
            this.listView1.Location = new System.Drawing.Point(15, 41);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(763, 480);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // btnGetUrl
            // 
            this.btnGetUrl.Location = new System.Drawing.Point(784, 4);
            this.btnGetUrl.Name = "btnGetUrl";
            this.btnGetUrl.Size = new System.Drawing.Size(75, 23);
            this.btnGetUrl.TabIndex = 3;
            this.btnGetUrl.Text = "获取地址";
            this.btnGetUrl.UseVisualStyleBackColor = true;
            this.btnGetUrl.Click += new System.EventHandler(this.btnGetUrl_Click);
            // 
            // btnDowload
            // 
            this.btnDowload.Location = new System.Drawing.Point(784, 33);
            this.btnDowload.Name = "btnDowload";
            this.btnDowload.Size = new System.Drawing.Size(75, 23);
            this.btnDowload.TabIndex = 4;
            this.btnDowload.Text = "开始下载";
            this.btnDowload.UseVisualStyleBackColor = true;
            this.btnDowload.Click += new System.EventHandler(this.btnDowload_Click);
            // 
            // Title
            // 
            this.Title.Text = "标题";
            this.Title.Width = 300;
            // 
            // Url
            // 
            this.Url.Text = "地址";
            this.Url.Width = 300;
            // 
            // State
            // 
            this.State.Text = "状态";
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.Red;
            this.lblHint.Location = new System.Drawing.Point(15, 526);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(0, 12);
            this.lblHint.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 545);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnDowload);
            this.Controls.Add(this.btnGetUrl);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnGetUrl;
        private System.Windows.Forms.Button btnDowload;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Url;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.Label lblHint;
    }
}

