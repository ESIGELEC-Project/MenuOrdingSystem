using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace MenuOrdering
{
    public static class DBManager
    {
        public static void RegisterUser(string u, string p, string f, string l, string n)
        {
            string hashedPassword = HashPassword(p);

            //SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"X:\\New folder\\MenuOrdering\\App_Data\\Database.mdf\";Integrated Security=True");
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=X:\\menu_order_websit\\MenuOrdering\\MenuOrdering\\App_Data\\Database.mdf;Integrated Security=True");
            connection.Open();

            string sql =  "INSERT INTO Users(username,password,firstname,lastname,phone) VALUES(@username,@password,@firstname,@lastname,@phone)";
            SqlCommand cmd = new SqlCommand(sql,connection);
            cmd.Parameters.AddWithValue("@username", u);
            cmd.Parameters.AddWithValue("@firstname", f);
            cmd.Parameters.AddWithValue("@lastname", l);
            cmd.Parameters.AddWithValue("@password", hashedPassword);
            cmd.Parameters.AddWithValue("@phone", n);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public static bool ValidateUser(string username, string password, HttpSessionState Session)
        {
            //SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"X:\\New folder\\MenuOrdering\\App_Data\\Database.mdf\";Integrated Security=True");
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=X:\\menu_order_websit\\MenuOrdering\\MenuOrdering\\App_Data\\Database.mdf;Integrated Security=True");
            connection.Open();

            string sql = "SELECT Id, username, firstname, lastname, phone FROM Users WHERE username = @username AND password = @password";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", HashPassword(password));
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //If Valid
                    Session["Username"] = reader.GetString(1);
                    Session["FirstName"] = reader.GetString(2);
                    Session["LastName"] = reader.GetString(3);
                    Session["Phone"] = reader.GetString(4);
                    Session["Id"] = reader.GetInt32(0);

                    return true;
                }
            }

            connection.Close();

            return false;
        }

        public static List<MenuItem> GetDrinks() 
        {
            List<MenuItem> items = new List<MenuItem>();

            //SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"X:\\New folder\\MenuOrdering\\App_Data\\Database.mdf\";Integrated Security=True");
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=X:\\menu_order_websit\\MenuOrdering\\MenuOrdering\\App_Data\\Database.mdf;Integrated Security=True");
            connection.Open();

            string sql = "SELECT id, description, price FROM Drinks";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    items.Add(new MenuItem(MenuItem.ItemType.Drink, reader.GetInt32(0), reader.GetString(1), (double)reader.GetDecimal(2)));
                }
            }

            connection.Close();

            return items;
        }

        public static List<MenuItem> GetDesserts()
        {
            List<MenuItem> items = new List<MenuItem>();

            //SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"X:\\New folder\\MenuOrdering\\App_Data\\Database.mdf\";Integrated Security=True");
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=X:\\menu_order_websit\\MenuOrdering\\MenuOrdering\\App_Data\\Database.mdf;Integrated Security=True");
            connection.Open();

            string sql = "SELECT id, description, price FROM Desserts";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    items.Add(new MenuItem(MenuItem.ItemType.Dessert, reader.GetInt32(0), reader.GetString(1), (double)reader.GetDecimal(2)));
                }
            }

            connection.Close();

            return items;
        }

        public static List<MenuItem> GetMeals()
        {
            List<MenuItem> items = new List<MenuItem>();

            //SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"X:\\New folder\\MenuOrdering\\App_Data\\Database.mdf\";Integrated Security=True");
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=X:\\menu_order_websit\\MenuOrdering\\MenuOrdering\\App_Data\\Database.mdf;Integrated Security=True");
            connection.Open();

            string sql = "SELECT id, description, price FROM Meals";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    items.Add(new MenuItem(MenuItem.ItemType.Meal, reader.GetInt32(0), reader.GetString(1), (double)reader.GetDecimal(2)));
                }
            }

            connection.Close();

            return items;
        }

        public static void SubmitOrder(Order theOrder)
        {
            //SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"X:\\New folder\\MenuOrdering\\App_Data\\Database.mdf\";Integrated Security=True");
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=X:\\menu_order_websit\\MenuOrdering\\MenuOrdering\\App_Data\\Database.mdf;Integrated Security=True");
            connection.Open();

            string sql = "INSERT INTO OrdersTable(user_id, address, phoneNumber, comments, name, totalPrice) VALUES(@user_id,@address,@phoneNumber,@comments,@name,@totalPrice)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@user_id", theOrder.user_id);
            cmd.Parameters.AddWithValue("@address", theOrder.address);
            cmd.Parameters.AddWithValue("@phoneNumber", theOrder.phoneNumber);
            cmd.Parameters.AddWithValue("@comments", theOrder.comments);
            cmd.Parameters.AddWithValue("@name", theOrder.name);
            cmd.Parameters.AddWithValue("@totalPrice", theOrder.totalPrice);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            cmd.CommandText = "Select @@Identity";
            int orderID = (int)(decimal)cmd.ExecuteScalar();

            foreach (MenuItem item in theOrder.menuItems)
            {
                string sql2 = "INSERT INTO OrderedItems(drink_id, meal_id, dessert_id, order_id) VALUES(@drink_id, @meal_id, @dessert_id, @order_id)";
                SqlCommand cmd2 = new SqlCommand(sql2, connection);
                if (item.type == MenuItem.ItemType.Drink) { cmd2.Parameters.AddWithValue("@drink_id", item.id); }
                else { cmd2.Parameters.AddWithValue("@drink_id", DBNull.Value); }
                if (item.type == MenuItem.ItemType.Meal) { cmd2.Parameters.AddWithValue("@meal_id", item.id); }
                else { cmd2.Parameters.AddWithValue("@meal_id", DBNull.Value); }
                if (item.type == MenuItem.ItemType.Dessert) { cmd2.Parameters.AddWithValue("@dessert_id", item.id); }
                else { cmd2.Parameters.AddWithValue("@dessert_id", DBNull.Value); }
                cmd2.Parameters.AddWithValue("@order_id", orderID);
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();
            }

            connection.Close();
        }

        public static List<Order> GetOrderHistory(int theUserId)
        {
            List<Order> items = new List<Order>();

            //SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"X:\\New folder\\MenuOrdering\\App_Data\\Database.mdf\";Integrated Security=True");
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=X:\\menu_order_websit\\MenuOrdering\\MenuOrdering\\App_Data\\Database.mdf;Integrated Security=True");
            connection.Open();

            string sql = "SELECT id, user_id, address, phoneNumber, comments, name, totalPrice, orderDate FROM OrdersTable WHERE user_id = @user_id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@user_id", theUserId);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int orderID = reader.GetInt32(0);
                    int userID = reader.GetInt32(1);
                    string address= reader.GetString(2);
                    string phoneNumber = reader.GetString(3);
                    string comments = reader.GetString(4);
                    string name = reader.GetString(5);
                    double totalPrice = (double)reader.GetDecimal(6);
                    DateTime orderDate = reader.GetDateTime(7);

                    items.Add(new Order(orderID,
                        userID,
                        address, 
                        phoneNumber, 
                        comments,
                        name, 
                        totalPrice,
                        orderDate,
                        GetItemsOrdered(orderID)));
                }
            }

            connection.Close();

            return items;
        }

        public static List<MenuItem> GetItemsOrdered(int theOrderId)
        {
            List<MenuItem> items = new List<MenuItem>();

            //SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"X:\\New folder\\MenuOrdering\\App_Data\\Database.mdf\";Integrated Security=True");
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=X:\\menu_order_websit\\MenuOrdering\\MenuOrdering\\App_Data\\Database.mdf;Integrated Security=True");
            connection.Open();

            string sql = "SELECT id, drink_id, meal_id, dessert_id, order_id FROM OrderedItems WHERE order_id = @order_id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@order_id", theOrderId);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = -1;
                    MenuItem.ItemType type = MenuItem.ItemType.Dessert;

                    if (reader.IsDBNull(1) == false)
                    {
                        id = reader.GetInt32(1);
                        type = MenuItem.ItemType.Drink;
                    }

                    if (reader.IsDBNull(2) == false)
                    {
                        id = reader.GetInt32(2);
                        type = MenuItem.ItemType.Meal;
                    }

                    if (reader.IsDBNull(3) == false)
                    {
                        id = reader.GetInt32(3);
                        type = MenuItem.ItemType.Dessert;
                    }

                    items.Add(GetMenuItemForIdAndType(id, type));
                }
            }

            connection.Close();

            return items;
        }

        public static MenuItem GetMenuItemForIdAndType(int id, MenuItem.ItemType type)
        {
            MenuItem item = null;

            if (id != -1)
            {
                //SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"X:\\New folder\\MenuOrdering\\App_Data\\Database.mdf\";Integrated Security=True");
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=X:\\menu_order_websit\\MenuOrdering\\MenuOrdering\\App_Data\\Database.mdf;Integrated Security=True");
                connection.Open();
                string TABLE = type == MenuItem.ItemType.Dessert ? "Desserts" : type == MenuItem.ItemType.Drink ? "Drinks" : "Meals";
                string sql = "SELECT id, description, price FROM "+TABLE+" WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        item = new MenuItem(type, reader.GetInt32(0), reader.GetString(1), (double)reader.GetDecimal(2));
                    }
                }
            }

            return item;
        }

        private static string HashPassword(string password)
        {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

    }
}