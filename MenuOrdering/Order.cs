using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuOrdering
{
    public class Order
    {
        public int id;
        public int user_id;
        public string address;
        public string phoneNumber;
        public string comments;
        public string name;
        public double totalPrice;
        public List<MenuItem> menuItems;
        public DateTime orderDate;

        public Order(int theId, int theUserId, string theAddress, string thePhoneNumber, string theComments, string theName, double thePrice, DateTime theOrderDate, List<MenuItem> theMenuItems)
        {
            id = theId;
            user_id = theUserId;
            address = theAddress;
            phoneNumber = thePhoneNumber;
            comments = theComments;
            name = theName;
            totalPrice = thePrice;
            menuItems = theMenuItems;
            orderDate = theOrderDate;
        }
    }
}