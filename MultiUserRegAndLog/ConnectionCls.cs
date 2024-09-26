using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MultiUserRegAndLog
{
    public class ConnectionCls
    {
        SqlConnection con;
        SqlCommand cmd;
        public ConnectionCls()
        {
            con = new SqlConnection(@"server=FERIS_LAP07\SQLEXPRESS;database=newdb;Integrated security=true");
        }
        public int Fun_NonQuery(string qry)
        {
            cmd = new SqlCommand(qry, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public string Fun_Scalar(string qry)
        {
            cmd = new SqlCommand(qry, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;
        }
    }
}