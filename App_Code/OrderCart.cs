using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;



namespace Project_Web_Final.App_Code
{
    public class OrderCart
    {
        private string PaymentWay;
        private ArrayList Products;
        private int TotalPrice;
        private string id;
        private string NameCostumer;
        private string date;

        public OrderCart(string idRND, string date, string NameCostumer)
        {

            this.date = date;
            this.PaymentWay = "Cash";
            this.TotalPrice = 0;
            this.id = idRND;
            this.NameCostumer = NameCostumer;
        }

        public void SetPaymentWay(string PaymentWay)
        {
            this.PaymentWay = PaymentWay;
        }

        public void SetNameCostumer(string NameCostumer)
        {
            this.NameCostumer = NameCostumer;
        }

        public void SetTotalPrice(int TotalPrice)
        {
            this.TotalPrice = TotalPrice;
        }

        public void SetProducts(ArrayList list1)
        {
            this.Products = list1;
        }

        

        public string GetPaymentWay()
        {
            return this.PaymentWay;
        }

        public string GetNameCostumer()
        {
            return this.NameCostumer;
        }

        public int GetTotalPrice()
        {
            return this.TotalPrice;
        }

        public string GetId()
        {
            return this.id;
        }

        public string GetDDate()
        {
            return this.date;
        }

        public ArrayList GetProducts()
        {
            return this.Products;
        }

        public void SetId(string id)
        {
            this.id = id;
        }

        internal void SetProducts(object v)
        {
            throw new NotImplementedException();
        }
    }
}