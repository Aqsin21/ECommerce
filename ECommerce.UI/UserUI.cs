using ECommerce.Application.Services;
using ECommerce.Infrastructure.EfCore;
using ECommerce.Infrastructure.EfCore.Context;


namespace ECommerce.UI
{
    public static class UserUI
    {
        private static AppDbContext context = new AppDbContext();
        private static UserManager userManager=new UserManager(
            new UserRepository(context));


        public static void ShowMenu()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== 🛍️ User  Menu ===");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Update User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. List All Users");
                Console.WriteLine("5. List By Id User");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddUser(); break;
                    case "2":
                        UpdateUser(); break;
                    case "3":
                        RemoveUser(); break;
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


        private static void AddUser()
        {

        }

        private static void UpdateUser()
        {

        }

        private static void RemoveUser()
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
