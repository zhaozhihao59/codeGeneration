namespace codeGeneration
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_huihuaList = new System.Windows.Forms.ComboBox();
            this.btn_linked = new System.Windows.Forms.Button();
            this.btn_setting = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_tables_info = new System.Windows.Forms.DataGridView();
            this.tableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.className = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_column_info = new System.Windows.Forms.DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtBox_filePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_pakage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_selected = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tables_info)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_column_info)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("隶书", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择会话";
            // 
            // cbb_huihuaList
            // 
            this.cbb_huihuaList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_huihuaList.FormattingEnabled = true;
            this.cbb_huihuaList.Items.AddRange(new object[] {
            "--请选择会话--"});
            this.cbb_huihuaList.Location = new System.Drawing.Point(126, 19);
            this.cbb_huihuaList.Name = "cbb_huihuaList";
            this.cbb_huihuaList.Size = new System.Drawing.Size(167, 20);
            this.cbb_huihuaList.TabIndex = 1;
            // 
            // btn_linked
            // 
            this.btn_linked.Location = new System.Drawing.Point(328, 20);
            this.btn_linked.Name = "btn_linked";
            this.btn_linked.Size = new System.Drawing.Size(75, 23);
            this.btn_linked.TabIndex = 2;
            this.btn_linked.Text = "连接";
            this.btn_linked.UseVisualStyleBackColor = true;
            this.btn_linked.Click += new System.EventHandler(this.btn_linked_Click);
            // 
            // btn_setting
            // 
            this.btn_setting.Location = new System.Drawing.Point(438, 20);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(75, 23);
            this.btn_setting.TabIndex = 2;
            this.btn_setting.Text = "设置";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_tables_info);
            this.groupBox1.Location = new System.Drawing.Point(35, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 192);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表信息";
            // 
            // dgv_tables_info
            // 
            this.dgv_tables_info.AllowUserToAddRows = false;
            this.dgv_tables_info.AllowUserToDeleteRows = false;
            this.dgv_tables_info.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_tables_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tables_info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableName,
            this.tableComment,
            this.className,
            this.dbName});
            this.dgv_tables_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_tables_info.Location = new System.Drawing.Point(3, 17);
            this.dgv_tables_info.Name = "dgv_tables_info";
            this.dgv_tables_info.RowHeadersVisible = false;
            this.dgv_tables_info.RowTemplate.Height = 23;
            this.dgv_tables_info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_tables_info.Size = new System.Drawing.Size(472, 172);
            this.dgv_tables_info.TabIndex = 0;
            this.dgv_tables_info.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_tables_info_CellMouseClick);
            // 
            // tableName
            // 
            this.tableName.DataPropertyName = "tableName";
            this.tableName.HeaderText = "表名称";
            this.tableName.Name = "tableName";
            // 
            // tableComment
            // 
            this.tableComment.DataPropertyName = "tableComment";
            this.tableComment.HeaderText = "注释";
            this.tableComment.Name = "tableComment";
            // 
            // className
            // 
            this.className.DataPropertyName = "className";
            this.className.HeaderText = "类名称";
            this.className.Name = "className";
            // 
            // dbName
            // 
            this.dbName.DataPropertyName = "dbName";
            this.dbName.HeaderText = "数据库名称";
            this.dbName.Name = "dbName";
            this.dbName.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_column_info);
            this.groupBox2.Location = new System.Drawing.Point(35, 273);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 245);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "列信息";
            // 
            // dgv_column_info
            // 
            this.dgv_column_info.AllowUserToAddRows = false;
            this.dgv_column_info.AllowUserToDeleteRows = false;
            this.dgv_column_info.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_column_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_column_info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.comment,
            this.fieldName,
            this.dataType});
            this.dgv_column_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_column_info.Location = new System.Drawing.Point(3, 17);
            this.dgv_column_info.MultiSelect = false;
            this.dgv_column_info.Name = "dgv_column_info";
            this.dgv_column_info.RowHeadersVisible = false;
            this.dgv_column_info.RowTemplate.Height = 23;
            this.dgv_column_info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_column_info.Size = new System.Drawing.Size(472, 225);
            this.dgv_column_info.TabIndex = 0;
            // 
            // columnName
            // 
            this.columnName.DataPropertyName = "columnName";
            this.columnName.HeaderText = "列名称";
            this.columnName.Name = "columnName";
            // 
            // comment
            // 
            this.comment.DataPropertyName = "comment";
            this.comment.HeaderText = "注释";
            this.comment.Name = "comment";
            // 
            // fieldName
            // 
            this.fieldName.DataPropertyName = "fieldName";
            this.fieldName.HeaderText = "属性名";
            this.fieldName.Name = "fieldName";
            // 
            // dataType
            // 
            this.dataType.DataPropertyName = "dataType";
            this.dataType.HeaderText = "数据类型";
            this.dataType.Name = "dataType";
            this.dataType.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(542, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 52);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "持久层";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(24, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "mybatis";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtBox_filePath);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txt_pakage);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btn_selected);
            this.groupBox4.Location = new System.Drawing.Point(542, 301);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(349, 100);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "输出选项";
            // 
            // txtBox_filePath
            // 
            this.txtBox_filePath.Location = new System.Drawing.Point(101, 59);
            this.txtBox_filePath.Name = "txtBox_filePath";
            this.txtBox_filePath.Size = new System.Drawing.Size(165, 21);
            this.txtBox_filePath.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "选择目录";
            // 
            // txt_pakage
            // 
            this.txt_pakage.Location = new System.Drawing.Point(101, 32);
            this.txt_pakage.Name = "txt_pakage";
            this.txt_pakage.Size = new System.Drawing.Size(212, 21);
            this.txt_pakage.TabIndex = 1;
            this.txt_pakage.Text = "com.bilibili";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "基类包名";
            // 
            // btn_selected
            // 
            this.btn_selected.Location = new System.Drawing.Point(274, 57);
            this.btn_selected.Name = "btn_selected";
            this.btn_selected.Size = new System.Drawing.Size(69, 23);
            this.btn_selected.TabIndex = 2;
            this.btn_selected.Text = "选择";
            this.btn_selected.UseVisualStyleBackColor = true;
            this.btn_selected.Click += new System.EventHandler(this.btn_selected_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(542, 470);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(343, 44);
            this.button2.TabIndex = 7;
            this.button2.Text = "生成";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 539);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.btn_linked);
            this.Controls.Add(this.cbb_huihuaList);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "zzhGeneration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tables_info)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_column_info)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_linked;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_tables_info;
        private System.Windows.Forms.DataGridView dgv_column_info;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtBox_filePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_pakage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_selected;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.ComboBox cbb_huihuaList;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn className;
        private System.Windows.Forms.DataGridViewTextBoxColumn dbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataType;
    }
}

