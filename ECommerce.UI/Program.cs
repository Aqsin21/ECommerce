using ECommerce.Domain.Entities;
using ECommerce.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using ECommerce.Infrastructure.EfCore;
using ECommerce.Infrastructure.EfCore.Context;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Domain.Interfaces;

namespace ECommerce.UI
{
    internal class Program
    {



        static void Main(string[] args)
        {
            var context = new AppDbContext();
            var productManager = new ProductManager(
            new ProductRepository(context),
            new CategoryManager(new CategoryRepository(context)));
            var categoryManager = new CategoryManager(
                new CategoryRepository(context));




            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=== Welcome to ECommerce Console App ===");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the Username:  ");
            string username = Console.ReadLine();
            Console.Write("Enter the Password:  ");
            string password = Console.ReadLine();


            var user = context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nLogin successful! Welcome, {user.FirstName} ");


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong password or Username!");
            }



            if (user.Role == UserType.Admin)
            {
                Console.Clear();
                Console.WriteLine("=== 🧠 Admin Panel ===");
                Console.WriteLine("1. Work with Products");
                Console.WriteLine("2. Work with Categories");
                Console.WriteLine("3. Work with Users");
                Console.WriteLine("4. Work with Orders");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string choice= Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ProductUI.ShowMenu(); break;
                    case "2":
                        CategoryUI.ShowMenu(); break;
                    case "3":
                        OrderUI.ShowMenu(); break;

                    case "4":
                        UserUI.ShowMenu(); break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid selection."); break;
                }
            }


            else
            {

            }




























































        }
    }
}

