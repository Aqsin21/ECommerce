using ECommerce.Application.Services;
using ECommerce.Infrastructure.EfCore.Context;
using ECommerce.Infrastructure.EfCore;


namespace ECommerce.UI
{
    public static  class OrderUI
    {
        private static AppDbContext context = new AppDbContext();
        private static OrderManager orderManager = new OrderManager(
            new OrderRepository(context));


        public static void ShowMenu()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== 🛍️ Order  Menu ===");
                Console.WriteLine("1. Add Order");
                Console.WriteLine("2. Update Order");
                Console.WriteLine("3. Delete Order");
                Console.WriteLine("4. List All Orders");
                Console.WriteLine("5. List By Id Order");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddOrder(); break;
                    case "2":
                        UpdateOrder(); break;
                    case "3":
                        RemoveOrder(); break;
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


        private static void AddOrder()
        {

        }

        private static void UpdateOrder()
        {

        }

        private static void RemoveOrder()
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
