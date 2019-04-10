using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace 电网数据
{
    public partial class AddForm : Form
    {
        Mysql_db mysql_Db;
        public AddForm(string server,string uid, string pwd, string db)
        {
            InitializeComponent();
            mysql_Db = new Mysql_db(server, uid, pwd, db);
        }

        public bool Money(string money)
        {
            string regexp = @"^([+-]?[1-9]\d{0,9}|0)([.]?|(\.\d{1,2})?)$";
            return Regex.IsMatch(money,regexp);
        }
        
        private void AddForm_Load(object sender, EventArgs e)
        {
            if (mysql_Db.Test_Conn() == "Open")
            {
                //  testans = "连接成功！";
                this.label2.ForeColor = Color.Green;
                this.label2.Text = "连接成功!";
            }
            else
            {
                //  testans = "连接失败！";
                this.label2.ForeColor = Color.Red;
                this.label2.Text = "连接失败!";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            //验证
            if (this.textBox1.Text.Trim() == "")//项目名称
            {
                MessageBox.Show("项目名称不能为空");
                return; }
            string 项目名称 = this.textBox1.Text.Trim();
             
            if (this.textBox3.Text.Trim() == "")//合同号
            {
                MessageBox.Show("合同号不能为空");
                return;
            }
             string 合同号 = this.textBox3.Text.Trim();
            
            if (this.textBox4.Text.Trim() == "")//买方名称
            {
                MessageBox.Show("买方名称不能为空");
                return;
            }
            string 买方名称 = this.textBox4.Text.Trim();
             
            if (this.textBox5.Text.Trim() == "")//金额
            {
                MessageBox.Show("金额不能为空");
                return;
            }
            else {

                if (!Money(this.textBox5.Text.Trim()))
                {
                    MessageBox.Show("金额格式不对");
                    return;
                }
            }
            decimal 金额 = Convert.ToDecimal(this.textBox5.Text.Trim());
            string 签订日期 = this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            string 交货日期 = this.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd");
            DateTime 创建日期 = DateTime.Now;
            DateTime 修改日期 = DateTime.Now;
            string 备注 = this.textBox6.Text.Trim();

            if (this.textBox2.Text.Trim() == "")//工令
            {
                MessageBox.Show("工令不能为空");
                return;
            }
            else
            {
                项目 p = new 项目(mysql_Db);
                if (p.HasCode(this.textBox2.Text.Trim()))
                {
                    MessageBox.Show("工令已存在");
                    return;
                }
                string 工令 = this.textBox2.Text.Trim();
                //都通过了
                int rownum=p.Add(项目名称, 工令, 合同号, 买方名称, 金额, 签订日期, 交货日期, 创建日期, 修改日期,备注);
                //this.textBox7.Text = rownum;
                if (rownum > 0)
                {
                    MessageBox.Show("添加成功！");
                    Form1.frm1.RefreshForm();
                    //清空
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                    this.textBox4.Text = "";
                    this.textBox5.Text = "0.00";
                    this.textBox6.Text = "";
                    this.textBox7.Text = "";
                    this.dateTimePicker1.Value= DateTime.Now;
                    this.dateTimePicker2.Value = DateTime.Now;
                }
               
            }


            // MessageBox.Show(this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")+" "+ this.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd"));
        }
    }
}
