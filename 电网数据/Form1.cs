using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace 电网数据
{

   

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            this.textBox6.Text = this.dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            this.textBox7.Text = this.dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

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
            if (!isfind) { AddForm fm = new AddForm(); fm.Show(); }
        }
    }
}
