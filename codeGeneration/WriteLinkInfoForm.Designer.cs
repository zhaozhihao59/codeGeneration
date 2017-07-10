namespace codeGeneration
{
    partial class WriteLinkInfoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_dataList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_testLink = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_dbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_host = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_huihua = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Huihua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Host = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DbType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dataList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_dataList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 415);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "会话列表";
            // 
            // dgv_dataList
            // 
            this.dgv_dataList.AllowUserToAddRows = false;
            this.dgv_dataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_dataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Huihua,
            this.DbName,
            this.Host,
            this.DbType,
            this.UserName,
            this.Password,
            this.Port});
            this.dgv_dataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_dataList.Location = new System.Drawing.Point(3, 17);
            this.dgv_dataList.MultiSelect = false;
            this.dgv_dataList.Name = "dgv_dataList";
            this.dgv_dataList.ReadOnly = true;
            this.dgv_dataList.RowHeadersVisible = false;
            this.dgv_dataList.RowTemplate.Height = 23;
            this.dgv_dataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_dataList.Size = new System.Drawing.Size(348, 395);
            this.dgv_dataList.TabIndex = 0;
            this.dgv_dataList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_dataList_CellMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.btn_clear);
            this.groupBox2.Controls.Add(this.btn_close);
            this.groupBox2.Controls.Add(this.btn_delete);
            this.groupBox2.Controls.Add(this.btn_testLink);
            this.groupBox2.Controls.Add(this.btn_save);
            this.groupBox2.Controls.Add(this.txt_dbName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_password);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_userName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_port);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_host);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_huihua);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(392, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 415);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "会话设置";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Mysql",
            "Oracle",
            "SqlSever"});
            this.comboBox1.Location = new System.Drawing.Point(87, 72);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(194, 340);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 10;
            this.btn_clear.Text = "清空";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(111, 374);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 12;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(30, 374);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 11;
            this.btn_delete.Text = "删除";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_testLink
            // 
            this.btn_testLink.Location = new System.Drawing.Point(111, 340);
            this.btn_testLink.Name = "btn_testLink";
            this.btn_testLink.Size = new System.Drawing.Size(75, 23);
            this.btn_testLink.TabIndex = 9;
            this.btn_testLink.Text = "测试";
            this.btn_testLink.UseVisualStyleBackColor = true;
            this.btn_testLink.Click += new System.EventHandler(this.btn_testLink_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(30, 340);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_dbName
            // 
            this.txt_dbName.Location = new System.Drawing.Point(87, 291);
            this.txt_dbName.Name = "txt_dbName";
            this.txt_dbName.Size = new System.Drawing.Size(182, 21);
            this.txt_dbName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "数据库";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(87, 247);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(182, 21);
            this.txt_password.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "密码";
            // 
            // txt_userName
            // 
            this.txt_userName.Location = new System.Drawing.Point(87, 203);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(182, 21);
            this.txt_userName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "用户名";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(87, 159);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(99, 21);
            this.txt_port.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "端口号";
            // 
            // txt_host
            // 
            this.txt_host.Location = new System.Drawing.Point(87, 115);
            this.txt_host.Name = "txt_host";
            this.txt_host.Size = new System.Drawing.Size(182, 21);
            this.txt_host.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "域名/IP地址";
            // 
            // txt_huihua
            // 
            this.txt_huihua.Location = new System.Drawing.Point(87, 28);
            this.txt_huihua.Name = "txt_huihua";
            this.txt_huihua.Size = new System.Drawing.Size(182, 21);
            this.txt_huihua.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "数据库类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "会话名称";
            // 
            // Huihua
            // 
            this.Huihua.DataPropertyName = "Huihua";
            this.Huihua.HeaderText = "会话名称";
            this.Huihua.Name = "Huihua";
            this.Huihua.ReadOnly = true;
            // 
            // DbName
            // 
            this.DbName.DataPropertyName = "DbName";
            this.DbName.HeaderText = "数据库名称";
            this.DbName.Name = "DbName";
            this.DbName.ReadOnly = true;
            // 
            // Host
            // 
            this.Host.DataPropertyName = "Host";
            this.Host.HeaderText = "ip/域名";
            this.Host.Name = "Host";
            this.Host.ReadOnly = true;
            // 
            // DbType
            // 
            this.DbType.DataPropertyName = "DbType";
            this.DbType.HeaderText = "数据库类型";
            this.DbType.Name = "DbType";
            this.DbType.ReadOnly = true;
            this.DbType.Visible = false;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "用户名";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Visible = false;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "密码";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Visible = false;
            // 
            // Port
            // 
            this.Port.DataPropertyName = "Port";
            this.Port.HeaderText = "端口号";
            this.Port.Name = "Port";
            this.Port.ReadOnly = true;
            this.Port.Visible = false;
            // 
            // WriteLinkInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 439);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "WriteLinkInfoForm";
            this.Text = "WriteLinkInfo";
            this.Load += new System.EventHandler(this.WriteLinkInfoForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dataList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_dataList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_testLink;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_dbName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_userName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_host;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_huihua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Huihua;
        private System.Windows.Forms.DataGridViewTextBoxColumn DbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Host;
        private System.Windows.Forms.DataGridViewTextBoxColumn DbType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
    }
}