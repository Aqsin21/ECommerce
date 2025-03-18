using ECommerce.Domain.Entities;
using ECommerce.Application.DTOs;

namespace ECommerce.UI
{
    internal class Program
    {
        List<User> users = new List<User>
{
    new User
    {
        UserName = "admin",
        Password = "admin123",
        Role = UserType.Admin
    }
};
        static void Main(string[] args)
        {
            Console.WriteLine("=== Welcome to ECommerce Console App ===");

            while (true)
            {
                Console.WriteLine("\n1. Login");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Login();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

            void Login()
            {
                Console.Write("\nUsername: ");
                string? username = Console.ReadLine();
                Console.Write("Password: ");
                string? password = Console.ReadLine();

                var user = users.FirstOrDefault(u => u.UserName == username && u.Password == password);
                if (user != null)
                {
                    Console.WriteLine($"\n✅ Login successful! Welcome, {user.Username} ({user.Role})");

                    if (user.Role == UserType.Admin)
                        AdminMenu(user);
                    else
                        UserMenu(user);
                }
                else
                {
                    Console.WriteLine("❌ Login failed. Invalid credentials.");
                }
            }


        }
    }
}
