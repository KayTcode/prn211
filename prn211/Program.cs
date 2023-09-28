using prn211;
internal class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>()
        {
            new Product(1 ,"Bánh Trung Thu", "Bánh",500.5,new DateTime(2024, 9, 25)),
            new Product(2, "Bánh xèo", "Bánh loại 2", 12000.666, new DateTime(2023, 12,20)),
            new Product(3, "Không phải bánh xèo", "bánh không ăn được", 30500.666, new DateTime(2025, 10, 26))
        };

        Find_Product find_product = new Find_Product(products);
        bool loop = true;
        bool check_menu = true;
        while (loop)
        {
            if (check_menu)
            {
                menu();
                string optionMenu = Console.ReadLine().ToUpper();
                switch (optionMenu)
                {
                    case "A":
                        find_product.insertProduct();
                        break;
                    case "B":
                        check_menu = false;
                        break;
                    case "C":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Please choose correct option.");
                        break;
                }
            }
            else
            {
                search();
                int option = find_product.enterInteger();
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter a number: ");
                        int id = find_product.enterInteger();
                        find_product.displayList(find_product.FindById(id));
                        break;
                    case 2:
                        Console.WriteLine("Enter a string: ");
                        string str = Console.ReadLine();
                        find_product.displayList(find_product.FindByName(str));
                        break;
                    case 3:
                        Console.WriteLine("Enter min price: ");
                        double min = find_product.enterDouble(double.MinValue);
                        Console.WriteLine("Enter max price: ");
                        double max = find_product.enterDouble(min);
                        find_product.displayList(find_product.FindByPrice(min, max));
                        break;
                    case 4:
                        Console.WriteLine("Enter date (MM/dd/yyyy): ");
                        DateTime date = find_product.dateTime();
                        find_product.displayList(find_product.FindByExpdate(date));
                        break;
                    case 5:
                        Console.WriteLine("Enter category: ");
                        string category = Console.ReadLine();
                        Console.WriteLine("Enter date (MM/dd/yyyy): ");
                        DateTime datetime = find_product.dateTime();
                        find_product.displayList(find_product.FindByCategoryAndExpDate(category, datetime));
                        break;
                    case 0:
                        check_menu = true;
                        break;
                    default:
                        Console.WriteLine("Please choose correct option.");
                        break;
                }
            }
        }
    }
    static void menu()
    {
        Console.WriteLine("===== PRODUCT MANAGEMENT =====");
        Console.WriteLine("A. Enter New Products in List");
        Console.WriteLine("B. Search Engine");
        Console.WriteLine("C. Exit");
        Console.WriteLine("Please choose option: ");
    }

    static void search()
    {
        Console.WriteLine("===== PRODUCT MANAGEMENT =====");
        Console.WriteLine("------ A. Search engine ------");
        Console.WriteLine("1. Find by id");
        Console.WriteLine("2. Find by name contains string");
        Console.WriteLine("3. Find by price between");
        Console.WriteLine("4. Find by expDate before a date");
        Console.WriteLine("5. Find by category and expdate ");
        Console.WriteLine("0. Back to main menu");
        Console.WriteLine("Please choose option: ");
    }
}