using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prn211
{
    public class Find_Product
    {
       List<Product> Products { get; set; } = new List<Product>();
        public Find_Product(List<Product> products)
        {
            Products = products;
        }
        public Product Get_product_by_id (int id)
        {
            foreach (Product product in Products)
            {
                if(product.id == id)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
