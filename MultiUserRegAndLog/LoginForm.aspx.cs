using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiUserRegAndLog
{
    public partial class LoginForm : System.Web.UI.Page
    {
        ConnectionCls objc = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(Reg_Id) from Login where Username = '" + TextBox1.Text + "' and Password = '" + TextBox2.Text + "'";
            string cid = objc.Fun_Scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if(cid1 == 1)
            {
                string str1 = "select Reg_Id from Login where Username = '" + TextBox1.Text + "' and Password = '" + TextBox2.Text + "'";
                string regid = objc.Fun_Scalar(str1);
                Session["uid"] = Convert.ToInt32(regid);
                string str2 = "select Log_Type from Login where  Username = '" + TextBox1.Text + "' and Password = '" + TextBox2.Text + "'";
                string logtype = objc.Fun_Scalar(str2);
                if(logtype == "admin")
                {
                    Label1.Visible = true;
                    Label1.Text = "Admin";
                }
                else if (logtype == "user")
                {
                    Label1.Visible = true;
                    Label1.Text = "User";
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Invalid Credentials";
            }
        }
    }
}