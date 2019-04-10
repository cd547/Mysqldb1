using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace 电网数据
{
    public class 项目
    {
        public int Id { get; set; }
        public string 项目名称 { get; set; }
        public string 工令 { get; set; }
        public string 合同号 { get; set; }
        public string 买方名称 { get; set; }
        public decimal 金额 { get; set; }
        public string 签订日期 { get; set; }
        public string 交货日期 { get; set; }
        public DateTime 创建日期 { get; set; }
        public DateTime 修改日期 { get; set; }
        public string 备注 { get; set; }
        Mysql_db mysql_Db;
        public 项目(Mysql_db mysql_Db) {
            this.mysql_Db = mysql_Db;
        }

        public int Add(string 项目名称, string 工令, string 合同号, string 买方名称, decimal 金额, string 签订日期, string 交货日期, DateTime 创建日期, DateTime 修改日期, string 备注) {

            string sql = string.Format("INSERT INTO 项目" +
            " values(null,\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\");", 
            项目名称 ,工令,合同号 ,买方名称 ,金额 ,签订日期 ,交货日期 ,创建日期 , 修改日期,备注);
           return mysql_Db.Run_SQL(sql);
            //return sql;
        }
        public int Delete(string type,string value)
        {
            string sql = string.Format("DELETE FROM 项目 WHERE " + type+"=\"{0}\";",value);
            return mysql_Db.Run_SQL(sql);
            //return sql;
        }

        public bool HasCode(string 工令) {
            var table = mysql_Db.Get_DataTable("SELECT * FROM 项目 WHERE 工令='" + 工令.Trim() + "';", "项目");
            if (table.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    
    }
   
}
