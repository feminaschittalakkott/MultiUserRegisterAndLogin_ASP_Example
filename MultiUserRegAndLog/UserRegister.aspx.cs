using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiUserRegAndLog
{
    public partial class UserRegister : System.Web.UI.Page
    {
        ConnectionCls objc = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string qry = "select max(Reg_Id) from Login";
            string regid = objc.Fun_Scalar(qry);
            int reg_id = 0;
            if(regid == "")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                reg_id = newregid + 1;
            }
            string ins = "insert into User_Reg values(" + reg_id + ", '" + TextBox1.Text + "', " + TextBox2.Text + ")";
            int i = objc.Fun_NonQuery(ins);
            if(i == 1)
            {
                string inslog = "insert into Login values (" + reg_id + ", '" + TextBox3.Text + "', '" + TextBox4.Text + "', 'user', 'active')";
                int j = objc.Fun_NonQuery(inslog);
            }
        }
    }
}