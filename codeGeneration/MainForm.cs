using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace codeGeneration
{
    public partial class MainForm : Form
    {
        public static List<DataModel> dataList = new List<DataModel>();
        public MainForm()
        {
            InitializeComponent();
        }
        DataSourceDLL dsDll = new DataSourceDLL();

       
        private void Main_Load(object sender, EventArgs e)
        {
            DataTypeMapping.initDataMap();
            String path = @"dataList.txt";

            dataList = Read(path);
            
           
            foreach (DataModel data in dataList) {
                this.cbb_huihuaList.Items.Add(data);
            }

            this.cbb_huihuaList.DisplayMember = "ShowText";
            this.cbb_huihuaList.ValueMember = "Item";
            this.dgv_column_info.AutoGenerateColumns = false;
            this.dgv_tables_info.AutoGenerateColumns = false;
            this.dgv_tables_info.Columns[0].ReadOnly = true;
            this.dgv_column_info.Columns[0].ReadOnly = true;

        }
        public List<DataModel> Read(string path)
        {
            FileStream fs = null;
            List<DataModel> modelList = new List<DataModel>();
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器
                if(fs.Length != 0){
                    modelList = (List<DataModel>)binFormat.Deserialize(fs);
                    fs.Close();
                }
               
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            
            return modelList;
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            String path = @"dataList.txt";
            Write(path,dataList);
        }

        public void Write(string path,List<DataModel> obj)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            //StreamWriter sw = new StreamWriter(fs);
            //开始写入
            BinaryFormatter binformat = new BinaryFormatter();
            binformat.Serialize(fs, obj);
            //清空缓冲区
            //sw.Flush();
            //关闭流
            //sw.Close();
            fs.Close();
        }


        private void btn_selected_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                this.txtBox_filePath.Text = foldPath;
            }

        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            WriteLinkInfoForm form = new WriteLinkInfoForm(this);
            form.ShowDialog();
           

        }

        private void btn_linked_Click(object sender, EventArgs e)
        {
            if(this.cbb_huihuaList.SelectedIndex != 0){
                DataModel data = (DataModel)this.cbb_huihuaList.SelectedItem;
                //GetIp ip = new GetIp();
                //string defaultIp = ip.getLocalNetInfo()[1];
                //if (ip.list.Contains(defaultIp))
                //{
                    string linkResult = DBHelper.testLink(data);
                    if (linkResult == "success")
                    {
                        DataTable dt = dsDll.getTablesInfo(data);
                        this.dgv_tables_info.DataSource = dt;

                    }
                    else
                    {
                        MessageBox.Show(linkResult);
                    }
                //}
                //else
                //{
                //    MessageBox.Show("连接失败，请稍后重试。。。。");
                //}
            }
            
        }

        private void dgv_tables_info_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dgv_tables_info.SelectedRows == null || this.dgv_tables_info.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一个要删除的行");
                return;
            }
            DataGridViewRow selectDataRow = this.dgv_tables_info.SelectedRows[0];
            DataTable dt = dsDll.getTableFeildInfo(selectDataRow.Cells["tableName"].Value.ToString(),selectDataRow.Cells["dbName"].Value.ToString());
            this.dgv_column_info.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtBox_filePath.Text.Trim() == "")
            {
                MessageBox.Show("请选择生成路径");
            }
            else 
            {
                if (this.dgv_tables_info.SelectedRows.Count > 1)
                {
                    CodeGenerationFactory.javaCodeFactory(this.txtBox_filePath.Text,this.txt_pakage.Text,this.dgv_tables_info.SelectedRows);
                }
                else 
                {
                    CodeGenerationFactory.javaCodeFactory(this.txtBox_filePath.Text,this.txt_pakage.Text,this.dgv_tables_info.SelectedRows[0],this.dgv_column_info.Rows);
                }
            }
            MessageBox.Show("文件生成完成");
        }

    }
}
