using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace MenuOrdering
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;

            if (DBManager.ValidateUser(username, password, Session) == false)
            {
                LoginError.Text = "Login was not successfull try again.";
            }
            else
            {
                LoginError.Text = "";
            }
        }

        protected void MakeOrderButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPage.aspx");
        }

        protected void OrderHistoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistoryPage.aspx");
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session["Username"] = null;
            Session["FirstName"] = null;
            Session["LastName"] = null;
            Session["Phone"] = null;
            Session["Id"] = null;
            Response.Redirect("Index.aspx");
        }
    }
}