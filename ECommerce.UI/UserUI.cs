﻿using ECommerce.Application.DTOs;
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=== 🛍️ User  Menu ===");
                Console.WriteLine("1. Change Rol  User");
                Console.WriteLine("2. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                         break;
                  
                    case "2":
                        return;
                    default:
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("❌ Invalid choice."); break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }

        }


        private static void AddUser()
        {
            Console.Clear();
            Console.WriteLine("🟢 Add New Product");

            Console.Write("Enter Username: ");
            string name = Console.ReadLine();

            Console.Write("Enter FirstName: ");
            string firstname= Console.ReadLine();

            Console.Write("Enter LastName: ");
            string lastname = Console.ReadLine();

            Console.Write("Enter Email adress: ");
            string email = Console.ReadLine();

           

            var createUserDto = new CreateUserDto
            {
                UserName = name,
                FirstName= firstname,
                LastName= lastname,
                Email= email

            };
            userManager.Add(createUserDto);


            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void UpdateUser()
        {
            Console.Write("Enter the user ID to update: ");
            int userId = int.Parse(Console.ReadLine());
            var existingUser = userManager.GetById(userId);
            if (existingUser == null)
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("❌ User not found.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }
            Console.Write($"Enter new name (current: {existingUser.UserName}): ");
            string newName = Console.ReadLine();

            Console.Write($"Enter new name (current: {existingUser.FirstName}): ");
            string newFirstName = Console.ReadLine();

            Console.Write($"Enter new name (current: {existingUser.LastName}): ");
            string newLastName = Console.ReadLine();

            Console.Write($"Enter new name (current: {existingUser.Email}): ");
            string newEmail = Console.ReadLine();

            var updateUserDto = new UpdateUserDto
            {
                Id = userId,
                UserName = newName,
                FirstName= newFirstName,
                LastName =newLastName,
                Email= newEmail
            };
            userManager.Update(updateUserDto);

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

        }

        private static void RemoveUser()
        {
            Console.Write("Enter the user ID to remove: ");
            int userId = int.Parse(Console.ReadLine());
            userManager.Remove(userId);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void GetAll()
        {
            var userDtoList = userManager.GetAll(null, true);
            if (userDtoList.Count == 0)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("❌ No categories found.");
            }
            else
            {

                foreach (var user in userDtoList)
                {
                    Console.WriteLine($"ID: {user.Id}, Name: {user.UserName} , FirstName :{user.FirstName} ,LastName :{user.LastName} ,Email :{user.Email} , Adress:{user.Address}");
                }
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void GetById()
        {
            Console.Write("Enter the user ID: ");
            int userId = int.Parse(Console.ReadLine());
            var userDto = userManager.GetById(userId);


            if (userDto == null)
            {
                Console.WriteLine("❌ User not found.");
            }
            else
            {

                Console.WriteLine($"ID: {userDto.Id}");
                Console.WriteLine($"UserName: {userDto.UserName}");
                Console.WriteLine($"FirstName:{userDto.FirstName}");
                Console.WriteLine($"LastName:{userDto.LastName}");
                Console.WriteLine($"Email:{userDto.Email}");

            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

        }
    }
}
