using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prn211
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public double price { get; set; }
        public DateTime expDate { get; set; }

        public Product(int id, string name, string category, double price, DateTime expDate)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.price = price;
            this.expDate = expDate;
        }
        public override string ToString()
        {
            return id + "\t" + name + "\t" + category + "\t" + price + "\t" + expDate.ToString("dd/MM/yyyy");
        }
    }

}
