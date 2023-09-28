using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prn211
{
    public class Find_Product
    {
       public List<Product> products = new List<Product>();
        public Find_Product()
        {

        }
        public Find_Product(List<Product> products)
        {
            this.products = products;
        }
        public int enterInteger()
        {
            while(true)
            {
                string str = Console.ReadLine();
                if(int.TryParse(str, out int number) )
                { 
                    return number;
                }else
                {
                    Console.WriteLine("Please enter an integer number!!");
                }
            }
        }
        public double enterDouble(double min)
        {
            while(true)
            {
                string str = Console.ReadLine() ;
                if(double.TryParse(str,out double number) ) 
                {
                    if(number >=  min)
                    {
                        return number;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number more than " + min);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number!!");
                }
            }
        }
        public string enterString()
        {
            while(true)
            {
                string str = Console.ReadLine();
                if(!str.Trim().Equals("") && str != null)
                {
                    return str;
                }
                else
                {
                    Console.WriteLine("Please enter a string not empty!!");
                }
            }
        }
        public DateTime dateTime()
        {
            while (true)
            {
                string str = Console.ReadLine();
                if(DateTime.TryParse(str,out DateTime date)){
                    return date;
                }
                else
                {
                    Console.WriteLine("Please enter correct date.");
                }
            }
        }
        public void insertProduct()
        {
            Console.WriteLine("Enter id: ");
            int id = enterInteger();
            Console.WriteLine("Enter name: ");
            string name = enterString();
            Console.WriteLine("Enter category: ");
            string category = enterString();
            Console.WriteLine("Enter price: ");
            double price = enterDouble(double.MinValue);
            Console.WriteLine("Enter expdate (dd/MM/yyyy): ");
            DateTime expdate = dateTime();
            Product product = new Product(id, name, category, price, expdate);
            products.Add(product);
            Console.WriteLine("Add product successfully");
            displayList(products);
        }
        public void displayList(List<Product> list)
        {
            Console.WriteLine("Product list: ");
            if(list.Count != 0 && list != null)
            {
                foreach(Product product in list)
                {
                    Console.WriteLine(product.ToString());
                }
            }
            else
            {
                Console.WriteLine("Cannot find any product.");
            }
        }
        public List<Product> ascendingSortByExpDate(List<Product> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (DateTime.Compare(list[i].expDate, list[j].expDate) > 0)
                    {
                        Product temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
        public List<Product> FindById(int id) {
            List<Product> ListByID = new List<Product>();
            foreach (Product p in products)
            {
                if (p.id == id)
                {
                    ListByID.Add(p);
                }
            }
            return ascendingSortByExpDate(ListByID);
        }
        public List <Product> FindByName(string str) 
        {
            List<Product> ListByName = new List<Product>();
            foreach (Product p in products)
            {
                if (p.name.ToLower().Contains(str.ToLower()))
                {
                    ListByName.Add(p);
                }
            }
            return ascendingSortByExpDate(ListByName);
        }
        public List<Product> FindByPrice(double min, double max) 
        {
            List <Product> ListByPrice = new List<Product>();
            foreach (Product p in products)
            {
                if (p.price >= min && p.price <= max)
                {
                    ListByPrice.Add(p);
                }
            }
            return ascendingSortByExpDate(ListByPrice);
        }
        public List<Product> FindByExpdate(DateTime dateTime) 
        {
            List<Product> ListByExpdate = new List<Product>();
            foreach (Product p in products)
            {
                if(DateTime.Compare(p.expDate, dateTime) < 0)
                {
                    ListByExpdate.Add(p);
                }
            }
            return ascendingSortByExpDate(ListByExpdate);
        }
        public List<Product> FindByCategoryAndExpDate(string category, DateTime dateTime)
        {
            List<Product> list = new List<Product>();
            foreach (Product p in products)
            {
                if (p.category.ToLower().Equals(category.ToLower()) &&
                    DateTime.Compare(p.expDate, dateTime) == 0)
                    list.Add(p);
            }
            return ascendingSortByExpDate(list);
        }

    }
}
