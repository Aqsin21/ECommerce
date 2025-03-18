using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace ECommerce.Application.Services
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }

        public void Add(CreateProductDto createDto)
        {
            var product = new Product
            {
                Id = createDto.Id,
                Name = createDto.Name,
                Price = createDto.Price,
                Description = createDto.Description,
                StockQuantity = createDto.StockQuantity,
                CategoryId=createDto.CategoryId
             };

            _repository.Add(product);


           


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
           var productDtoList= new List<ProductDto>();
            foreach (var item in products)
            {
                productDtoList.Add(new ProductDto
                {
                    Id = item.Id,
                    Name = item.Name
                });

            }

            return productDtoList;
        }

        public ProductDto GetById(int id)
        {
            var product =_repository.GetById(id);
            var productDto = new ProductDto
            { 
                Id = product.Id,
                Name = product.Name
            };

            return productDto;

        }

        public void Remove(int id)
        {
            var existEntity= _repository.GetById(id);
            if (existEntity == null) throw new Exception("Not found");

            _repository.Remove(existEntity);
        }

        public void Update(UpdateProductDto updateDto)
        {
            var product = new Product
            {
                Id = updateDto.Id,
                Name = updateDto.Name,
            };

            _repository.Update(product);
        }
    }
}
