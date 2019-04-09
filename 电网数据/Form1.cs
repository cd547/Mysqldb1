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


        private void Form1_Load(object sender, EventArgs e)
        {
            //测试连接
            Mysql_db mysql_Db = new Mysql_db("127.0.0.1", "root","5454794547","db");
            string testans= mysql_Db.Test_Conn();
            if (testans != "Open")
            {
                testans = "连接失败！";
                this.label1.ForeColor = Color.Red;
            }
            else
            {
                testans = "连接成功！";
                this.label1.ForeColor = Color.Green;
            }
            this.label1.Text = testans;
            DataTable dt= mysql_Db.Get_DataTable("SELECT * FROM 项目", "项目");
            this.dataGridView1.DataSource = dt;
        }
    }
}
