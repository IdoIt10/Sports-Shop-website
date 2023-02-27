using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Web_Final.App_Code
{
    public class Product
    {
        private string id;
        private int quantity;
        private int price;

        public Product(string id, int quantity, int price)
        {
            this.id = id;
            this.price = price;
            this.quantity = quantity;
        }

        public string GetId()
        {
            return this.id;
        }

        public int GetPrice()
        {
            return this.price;
        }

        public int GetQuantity()
        {
            return this.quantity;
        }

        public void SetId(string NewId)
        {
            this.id = NewId;
        }

        public void SetPrice(int NewPrice)
        {
            this.price = NewPrice;
        }

        public void SetQuantity(int NewQuantity)
        {
            this.quantity = NewQuantity;
        }

        public int SumPrice_Product()
        {
            int SumPrice = this.price * this.quantity;

            return SumPrice;
        }

    }
}