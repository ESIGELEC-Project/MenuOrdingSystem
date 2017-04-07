using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuOrdering
{
    public class MenuItem
    {
        public enum ItemType { Drink, Dessert, Meal};

        public int id;
        public string description;
        public double price;
        public ItemType type;

        public MenuItem(ItemType theType, int theId, string theDescription, double thePrice)
        {
            id = theId;
            description = theDescription;
            price = thePrice;
            type = theType;
        }
    }
}