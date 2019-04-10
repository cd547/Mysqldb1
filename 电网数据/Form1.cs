using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace 电网数据
{

   

    public partial class Form1 : Form
    {
        public static Form1 frm1;
        public Form1()
        {

            InitializeComponent();
            frm1 = this;
        }

        Mysql_db mysql_Db;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (test())
            {
                this.TestConnect_label.Text = "连接成功！";
                DataTable dt = mysql_Db.Get_DataTable("SELECT * FROM 项目", "项目");
                this.dataGridView1.DataSource = dt;
            }
            else
            {
                this.TestConnect_label.Text = "连接失败！";
            }

        }

        public bool test()
        {
            mysql_Db = new Mysql_db(this.Server_TxtBox.Text, this.Uid_TxtBox.Text, this.PWD_TxtBox.Text, "db");
            string testans = mysql_Db.Test_Conn();
            if (testans != "Open")
            {
              //  testans = "连接失败！";
                this.TestConnect_label.ForeColor = Color.Red;
                return false;
            }
            else
            {
              //  testans = "连接成功！";
                this.TestConnect_label.ForeColor = Color.Green;
                return true;
            }
        }

        public void RefreshForm()
        {
            //测试连接
            if (test())
            {
                this.TestConnect_label.Text = "连接成功！";
                DataTable dt = (DataTable)dataGridView1.DataSource;
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        dt.Rows.Clear();
                        dataGridView1.DataSource = dt;
                    }
                }

                dt = mysql_Db.Get_DataTable("SELECT * FROM 项目", "项目");
                this.dataGridView1.DataSource = dt;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.dateTimePicker1.Value = DateTime.Now;
                this.dateTimePicker2.Value = DateTime.Now;
                this.textBox8.Text = "";
                this.Id_Label.Text = null;
                this.Create_label.Text = null;
                this.Chang_label.Text = null;

            }
            else
            {
                this.TestConnect_label.Text = "连接失败！";
            }

        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            //测试连接
            if (test())
            {
                this.TestConnect_label.Text = "连接成功！";
                DataTable dt = (DataTable)dataGridView1.DataSource;
                if (dt != null)
                {
                    if(dt.Rows.Count>0)
                    {
                        dt.Rows.Clear();
                        dataGridView1.DataSource = dt;
                    }
                }
               
                
                dt = mysql_Db.Get_DataTable("SELECT * FROM 项目", "项目");
                this.dataGridView1.DataSource = dt;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.dateTimePicker1.Value = DateTime.Now;
                this.dateTimePicker2.Value = DateTime.Now;
                this.textBox8.Text = "";
                this.Id_Label.Text = null;
                this.Create_label.Text = null;
                this.Chang_label.Text = null;
            }
            else
            {
                this.TestConnect_label.Text = "连接失败！";
            }
            
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            this.Id_Label.Text=this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.textBox1.Text= this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.textBox2.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.textBox3.Text = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            this.textBox4.Text = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            this.textBox5.Text = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            this.dateTimePicker1.Value = Convert.ToDateTime(this.dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(), dtFormat);
            this.dateTimePicker2.Value = Convert.ToDateTime(this.dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(), dtFormat);
            this.Create_label.Text = this.dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            this.Chang_label.Text = this.dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            this.textBox8.Text = this.dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
        }
        //添加
        private void Button1_Click(object sender, EventArgs e)
        {
            bool isfind = false;
            foreach (Form fm in Application.OpenForms)
            {
                //判断Form2是否存在，如果在激活并给予焦点
                if (fm.Name == "AddForm")
                {
                    fm.WindowState = FormWindowState.Maximized;
                    fm.WindowState = FormWindowState.Normal;
                    fm.Activate();
                    return;
                }
            }
            //如果窗口不存在，打开窗口
            if (!isfind) {
                AddForm fm = new AddForm(this.Server_TxtBox.Text, this.Uid_TxtBox.Text, this.PWD_TxtBox.Text, "db");
                
                fm.Show();

            }
        }
        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Id_Label.Text == null|| this.Id_Label.Text =="0")
            { return; }
            DialogResult result = MessageBox.Show("是否要删除ID号"+this.Id_Label.Text+"？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                项目 p = new 项目(mysql_Db);
                int rownum=p.Delete("Id", this.Id_Label.Text);
                if (rownum > 0)
                {
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
                
            }
            else
            {
                return;
            }
        }
    }
}
