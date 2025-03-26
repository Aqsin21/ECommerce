using ECommerce.Application.Services;
using ECommerce.Infrastructure.EfCore.Context;
using ECommerce.Infrastructure.EfCore;
using ECommerce.Application.DTOs;


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
                Console.ForegroundColor = ConsoleColor.Green;
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
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("❌ Invalid choice."); break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }

        }

        private static void AddCategory()
        {
            Console.Clear();
            Console.WriteLine("🟢 Add New Category");

            Console.Write("Enter Category name: ");
            string name = Console.ReadLine();

            var createCategoryDto = new CreateCategoryDto
            {
                Name = name,
               
            };

            categoryManager.Add(createCategoryDto);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

        }

        private static void UpdateCategory()
        {
            Console.Write("Enter the category ID to update: ");
            int categoryId = int.Parse(Console.ReadLine());
            var existingCategory = categoryManager.GetById(categoryId);
            if (existingCategory == null)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("❌ Category not found.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }
            Console.Write($"Enter new name (current: {existingCategory.Name}): ");
            string newName = Console.ReadLine();

            var updateCategoryDto = new UpdateCategoryDto
            { 
                Id=categoryId,
                Name=newName
            };
            categoryManager.Update(updateCategoryDto);

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void RemoveCategory()
        {
            Console.Write("Enter the category ID to remove: ");
            int categoryId = int.Parse(Console.ReadLine());
            categoryManager.Remove(categoryId);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

        }
        private static void GetAll()
        {
            var categoryDtoList = categoryManager.GetAll(null, true);
            if (categoryDtoList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ No categories found.");
            }
            else
            {

                foreach (var category in categoryDtoList)
                {
                    Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
                }
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void GetById()
        {
            Console.Write("Enter the category ID: ");
            int categoryId = int.Parse(Console.ReadLine());
            var categoryDto = categoryManager.GetById(categoryId);


            if (categoryDto == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Product not found.");
            }
            else
            {

                Console.WriteLine($"ID: {categoryDto.Id}");
                Console.WriteLine($"Name: {categoryDto.Name}");

            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }


    }
}
