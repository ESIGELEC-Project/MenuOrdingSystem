using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenuOrdering
{
    public partial class MenuPage : System.Web.UI.Page
    {
        String input_name;
        String input_phone;
        String input_address;
        String input_comment;
        public List<MenuItem> ordered_main;
        public List<MenuItem> ordered_drink;
        public List<MenuItem> ordered_dessert;

        double total_price = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if it is not loged in
            if (Session["username"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            ordered_main = new List<MenuItem>();
            ordered_drink = new List<MenuItem>();
            ordered_dessert = new List<MenuItem>();
            //if it is the first time loading the page
            if (!IsPostBack)
            {
                name.Text = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();
                phone.Text = Session["Phone"].ToString();
                get_main();
                get_drink();
                get_dessert();
            }
        }



        protected void submit_Click(object sender, EventArgs e)
        {
            //if the user did not choose any item
            if (ordered_main.Count() == 0 && ordered_drink.Count() == 0 && ordered_dessert.Count() == 0)
            {
                error_message.Text = "You should at least choose one item for the order!";
            }
            else
            {
                //save to database
                List<MenuItem> total_order = new List<MenuItem>();
                total_order.AddRange(ordered_main);
                total_order.AddRange(ordered_drink);
                total_order.AddRange(ordered_dessert);
                total_price = get_total_price();

                Order o = new Order(-1, Int32.Parse(Session["Id"].ToString()) , address.Text, phone.Text,
                                comment.Text, name.Text, total_price, new DateTime(),
                                total_order);

                DBManager.SubmitOrder(o);
                Response.Redirect("Index.aspx");
            }

        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }






        protected void main_course_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = 0;
            foreach (ListItem i in main_course.Items)
            {
                if (i.Selected)
                {   
                        List<MenuItem> temp = DBManager.GetMeals();
                        MenuItem seleted_element = temp.ElementAt(index++);
                        ordered_main.Add(seleted_element);
                }
            }
        }

        protected void drink_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            foreach (ListItem i in drink.Items)
            {
                if (i.Selected)
                {   
                        IList<MenuItem> temp = DBManager.GetDrinks();
                        MenuItem seleted_element = temp.ElementAt(index++);
                        ordered_drink.Add(seleted_element);
                }
                
            }
        }

        protected void dessert_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            foreach (ListItem i in dessert.Items)
            {
                if (i.Selected)
                {   
                        IList<MenuItem> temp = DBManager.GetDesserts();
                        MenuItem seleted_element = temp.ElementAt(index++);
                        ordered_dessert.Add(seleted_element);
                }
            }

        }



        protected void get_main()
        {
            foreach (MenuItem i in DBManager.GetMeals())
            {
                main_course.Items.Add(i.description + " Price: " + i.price);
            }
        }

        protected void get_drink()
        {
            foreach (MenuItem i in DBManager.GetDrinks())
            {
                drink.Items.Add(i.description + " Price: " + i.price);
            }
        }

        protected void get_dessert()
        {
            foreach (MenuItem i in DBManager.GetDesserts())
            {
                dessert.Items.Add(i.description + " Price: " + i.price);
            }
        }




        private double get_total_price()
        {
            double price = 0;
            //retrieving the price of main course
            foreach (MenuItem i in ordered_main)
            {
                price += i.price;
            }

            //retrieving the price of drink
            foreach (MenuItem i in ordered_drink)
            {
                price += i.price;
            }

            //retriving the price of dessert
            foreach (MenuItem i in ordered_dessert)
            {
                price += i.price;
            }

            return price;
        }






    }
}