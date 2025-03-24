using ECommerce.Application.DTOs;
using ECommerce.Application.Services;
using ECommerce.Infrastructure.EfCore;

using ECommerce.Infrastructure.EfCore.Context;

namespace ECommerce.UI
{
    public   class ProductUI
    {
        private static AppDbContext context = new AppDbContext();
        private static ProductManager productManager = new ProductManager(
            new ProductRepository(context),
            new CategoryManager(new CategoryRepository(context))
        );

        public static void ShowMenu()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== 🛍️ Product Menu ===");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. List All Products");
                Console.WriteLine("5. List By Id Category");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct(); break;
                    case "2":
                        UpdateProduct(); break;
                    case "3":
                        RemoveProduct(); break;
                    case "4":
                        GetAll(); break;
                    case "5":
                        GetById(); break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("❌ Invalid choice."); break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }

        }

           
        private static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("🟢 Add New Product");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter stock: ");
            int stock = int.Parse(Console.ReadLine());

            Console.Write("Enter category ID: ");
            int categoryId = int.Parse(Console.ReadLine());

            var createProductDto = new CreateProductDto
            {
                Name = name,
                Price = price,
                StockQuantity = stock,
                CategoryId = categoryId
            };

            var result = productManager.Add(createProductDto);

            if (result)
            {
                Console.WriteLine("✅ Product added successfully!");
            }
            else
            {
                Console.WriteLine("❌ Failed to add product.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void UpdateProduct()
        {
            // ...
        }

        private static void RemoveProduct()
        {

        }
        private static void GetAll()
        {

        }

        private static void GetById()
        {

        }
    }
}
