using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace ECommerce.Application.Services
{
    public class ProductManager : IProductService
    {
        private List<Product> basket = new List<Product>(); // Sepet
        private readonly IProductRepository _repository;

        private readonly List<ProductDto> _basket = new List<ProductDto>();

        public ProductManager(IProductRepository repository, CategoryManager categoryManager)
        {
            _repository = repository;
        }

        public void Add(CreateProductDto createDto)
        {
            var existingProduct = _repository.Get(p => p.Name == createDto.Name);
            if (existingProduct != null)
            {
                Console.WriteLine("Warnin a product with same name already exist");
                return;

            }
            var product = new Product
            {
                Id = createDto.Id,
                Name = createDto.Name,
                Price = createDto.Price,
                Description = createDto.Description,
                StockQuantity = createDto.StockQuantity,
                CategoryId = createDto.CategoryId
            };

            _repository.Add(product);
            Console.WriteLine("Product Added Succesfuly");

        }

        public ProductDto Get(Expression<Func<Product, bool>> predicate)
        {
            var product = _repository.Get(predicate);

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name

            };
            return productDto;

        }

        public List<ProductDto> GetAll(Expression<Func<Product, bool>>? predicate, bool AsNoTracking)
        {
            var products = _repository.GetAll(predicate, AsNoTracking);
            var productDtoList = new List<ProductDto>();
            foreach (var item in products)
            {
                productDtoList.Add(new ProductDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price

                });

            }

            return productDtoList;
        }

        public ProductDto GetById(int id)
        {
            var product = _repository.GetById(id);
            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name
            };

            return productDto;

        }

        public void Remove(int id)
        {
            var existEntity = _repository.GetById(id);
            if (existEntity == null) throw new Exception("Not found");

            _repository.Remove(existEntity);
        }

        public void Update(UpdateProductDto updateDto)
        {
            var existingProduct = _repository.GetById(updateDto.Id);
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }
            existingProduct.Name = updateDto.Name ?? existingProduct.Name;
            existingProduct.Price = updateDto.Price;
            existingProduct.Description = updateDto.Description ?? existingProduct.Description;
            existingProduct.CategoryId = updateDto.CategoryId;

            _repository.Update(existingProduct);
        }



        public void AddToBasket(int productId)
        {
            var product = _repository.GetById(productId);

            if (product == null)
            {
                Console.WriteLine("❌ Product not found!");
                return;
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            _basket.Add(productDto);
            Console.WriteLine($"✓ {product.Name} added to basket.");
        }


        public void ShowBasket()
        {
            Console.WriteLine("\n🛒 Basket Items:");
            if (_basket.Count == 0)
            {
                Console.WriteLine("Your basket is empty.");
                return;
            }

            foreach (var item in _basket)
            {
                Console.WriteLine($"- {item.Name} | {item.Price}$");
            }
        }

        public void PurchaseBasket()
        {
            if (_basket.Count == 0)
            {
                Console.WriteLine("❌ Your basket is empty. Please add items to your basket before proceeding.");
                return;
            }

            decimal totalAmount = 0;
            foreach (var item in _basket)
            {
                totalAmount += item.Price;
            }

            Console.WriteLine($"Your total basket amount is: {totalAmount}$");
            Console.Write("Do you want to proceed with the purchase? (Yes/No): ");
            string confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "yes")
            {
                Console.ForegroundColor=ConsoleColor.Green;
                Console.WriteLine("Your purchase has been successfully completed!");

               
                _basket.Clear();
            }
            else
            {
                Console.WriteLine("Purchase cancelled.");
            }
        }
    }
}
