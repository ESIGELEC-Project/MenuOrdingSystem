using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenuOrdering
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;
            string passwordConfirm = PasswordConfirm.Text;
            string firstName = First.Text;
            string lastName = Last.Text;
            string phoneNumber = Phone.Text;

            if (username.Length > 0 &&
                password == passwordConfirm &&
                password.Length > 0 &&
                firstName.Length > 0 &&
                lastName.Length > 0 &&
                phoneNumber.Length > 0)
            {
                DBManager.RegisterUser(username, password, firstName, lastName, phoneNumber);
                Response.Redirect("Index.aspx");
            }
        }



        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}