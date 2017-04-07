using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenuOrdering
{
    public partial class History_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the user is not logged in 
            if (Session["username"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                int userID = Int32.Parse(Session["Id"].ToString());
                List<Order> order_list = DBManager.GetOrderHistory(userID);

                foreach (Order o in order_list)
                {
                    // Total number of rows.
                    int rowCnt = order_list.Count();
                    // Current row count.
                    int rowCtr;
                    // Current cell counter
                    int cellCtr;
                    // Total number of cells per row (columns).
                    int cellCnt = 6;

                   
                        // Create new row and add it to the table.
                        TableRow tRow = new TableRow();
                        Table1.Rows.Add(tRow);
                        for (cellCtr = 1; cellCtr <= cellCnt; cellCtr++)
                        {
                            // Create a new cell and add it to the row.
                            TableCell tCell = new TableCell();
                            if (cellCtr == 1)
                            {
                                string completeString = "";

                                foreach (MenuItem item in o.menuItems)
                                {
                                    completeString += item.description + "<br />";
                                }

                                tCell.Text = completeString;
                            }
                            else if (cellCtr == 2)
                            {
                                tCell.Text = o.totalPrice.ToString();
                            }
                            else if (cellCtr == 3)
                            {
                                tCell.Text = o.phoneNumber;
                            }
                            else if (cellCtr == 4)
                            {
                                tCell.Text = o.address;
                            }
                            else if (cellCtr == 5)
                            {
                                tCell.Text = o.comments;
                            }
                            else if (cellCtr == 6)
                            {
                                tCell.Text = o.orderDate.ToString();
                            }

                            tRow.Cells.Add(tCell);
                        }
                    }
                

            }
        }
    }
}