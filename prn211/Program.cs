using prn211;

static void Main(string[] args)
{
        List<Product> Products = new List<Product>()
     {
            new Product(1, "Bánh Trung Thu", "Bánh", 50000,new DateTime(9/30/2023)),
            new Product(2, "Bánh xèo", "Bánh loại 2", 12000, new DateTime(9/ 27/2023)),
            new Product(3, "Không phải bánh xèo", "bánh không ăn được", 30500, new DateTime(10/1/2023))
        
     };

    Find_Product find = new Find_Product(Products);
}