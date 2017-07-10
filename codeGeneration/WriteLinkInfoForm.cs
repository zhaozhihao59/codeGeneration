using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace codeGeneration
{
    public partial class WriteLinkInfoForm : Form
    {
        public WriteLinkInfoForm()
        {
            InitializeComponent();
        }
        private MainForm mainForm;
        public WriteLinkInfoForm(MainForm main)
        {
            mainForm = main;
            InitializeComponent();
        }
        public DataModel getDataModel() {
            DataModel result = new DataModel();
            result.DbName = this.txt_dbName.Text;
            if(result.DbName.Trim() == ""){
                MessageBox.Show("数据库名不能为空");
                return null;
            }
            result.DbType = this.comboBox1.SelectedItem.ToString();
            if (result.DbType.Trim() == "")
            {
                MessageBox.Show("数据库名不能为空");
                return null;
            }
            result.Host = this.txt_host.Text;
            if (result.Host.Trim() == "")
            {
                MessageBox.Show("IP/域名不能为空");
                return null;
            }
            result.Huihua = this.txt_huihua.Text;
            if (result.Huihua.Trim() == "")
            {
                MessageBox.Show("会话名不能为空");
                return null;
            }
            result.Password = this.txt_password.Text;
            if (result.Password.Trim() == "")
            {
                MessageBox.Show("密码不能为空");
                return null;
            }
            result.Port = this.txt_port.Text;
            if (result.Port.Trim() == "")
            {
                MessageBox.Show("端口号不能为空");
                return null;
            }
            result.UserName = this.txt_userName.Text;
            if (result.DbName.Trim() == "")
            {
                MessageBox.Show("用户名不能为空");
                return null;
            }
            result.ShowText = this.txt_huihua.Text + " -- " + this.txt_host.Text + "(" + this.txt_dbName.Text + ")";
            return result;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DataModel data = getDataModel();
            if(data == null){
                return;
            }
            MainForm.dataList.Add(data);
            this.dgv_dataList.DataSource = null;
            this.dgv_dataList.DataSource = MainForm.dataList;
            mainForm.cbb_huihuaList.Items.Add(data);
            ClearData();
        }

        //清理数据
        public void ClearData() {
            this.txt_huihua.Clear();
            this.txt_dbName.Clear();
            this.txt_host.Clear();
            this.txt_password.Clear();
            this.txt_port.Clear();
            this.txt_userName.Clear();
            this.comboBox1.SelectedIndex = 0;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
           if(this.dgv_dataList.SelectedRows == null || this.dgv_dataList.SelectedRows.Count == 0){
               MessageBox.Show("请选择一个要删除的行");
               return;
           }
           DataGridViewRow selectDataRow = this.dgv_dataList.SelectedRows[0];
          
           if((MessageBox.Show("确定删除么?", "删除不可恢复", MessageBoxButtons.OKCancel) == DialogResult.OK)){
               foreach (DataModel data in MainForm.dataList) {
                   if (data.Huihua == (string)selectDataRow.Cells[0].Value && data.DbName == (string)selectDataRow.Cells[1].Value && data.Host == (string)selectDataRow.Cells[2].Value)
                   {
                       MainForm.dataList.Remove(data);
                       this.dgv_dataList.DataSource = null;
                       mainForm.cbb_huihuaList.Items.Remove(data);
                       this.dgv_dataList.DataSource = MainForm.dataList;
                       ClearData();
                       break;
                   }
               };
           }
           
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_testLink_Click(object sender, EventArgs e)
        {
            DataModel data = getDataModel();
            if(data == null){
                return;
            }
            //GetIp ip = new GetIp();
            //if (ip.list.Contains(ip.getLocalNetInfo()[1]))
            //{
                string result = DBHelper.testLink(data);
                if (result == "success")
                {
                    MessageBox.Show("连接成功");
                }
                else
                {
                    MessageBox.Show(result);
                };
            //}
            //else
            //{
            //    MessageBox.Show("连接失败，请稍后重试。。。。");
            //}
           
        }

        private void WriteLinkInfoForm_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
           
            this.dgv_dataList.AutoGenerateColumns = false;
            this.dgv_dataList.DataSource = MainForm.dataList;
            
        }

        private void dgv_dataList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dgv_dataList.SelectedRows == null || this.dgv_dataList.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一个要删除的行");
                return;
            }
            DataGridViewRow selectDataRow = this.dgv_dataList.SelectedRows[0];
            this.txt_dbName.Text = (string)selectDataRow.Cells["DbName"].Value;
            this.comboBox1.SelectedText = (string)selectDataRow.Cells["DbType"].Value;
            this.txt_host.Text = (string)selectDataRow.Cells["Host"].Value;
            this.txt_huihua.Text = (string)selectDataRow.Cells["Huihua"].Value; ;
            this.txt_password.Text = (string)selectDataRow.Cells["Password"].Value; ;
            this.txt_port.Text = (string)selectDataRow.Cells["Port"].Value; ;
            this.txt_userName.Text = (string)selectDataRow.Cells["UserName"].Value; ;
        }

        
    }
}
