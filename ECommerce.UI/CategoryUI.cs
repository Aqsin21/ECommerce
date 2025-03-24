using ECommerce.Application.Services;
using ECommerce.Infrastructure.EfCore.Context;
using ECommerce.Infrastructure.EfCore;


namespace ECommerce.UI
{
    public static class CategoryUI
    {
        private static AppDbContext context = new AppDbContext();
        private static CategoryManager categoryManager = new CategoryManager(
            new CategoryRepository(context));

        public static void ShowMenu()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== 🛍️ Category  Menu ===");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. Update Category");
                Console.WriteLine("3. Delete Category");
                Console.WriteLine("4. List All Categories");
                Console.WriteLine("5. List By Id Category");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCategory(); break;
                    case "2":
                        UpdateCategory(); break;
                    case "3":
                        RemoveCategory(); break;
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

        private static void AddCategory()
        {
           
        }

        private static void UpdateCategory()
        {
            
        }

        private static void RemoveCategory()
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
