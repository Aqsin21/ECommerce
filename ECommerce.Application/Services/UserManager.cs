using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using System.Linq.Expressions;

namespace ECommerce.Application.Services
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _reposiotry;

        public UserManager(IUserRepository reposiotry)
        {
            _reposiotry = reposiotry;
        }

        public void Add(CreateUserDto createDto)
        {
           var user= new User();
            {
                user.UserName=createDto.UserName;
                user.Email = createDto.Email;
                user.FirstName = createDto.FirstName;
                user.LastName = createDto.LastName;
                user.Address = createDto.Address;
            }

        }

        public UserDto Get(Expression<Func<User, bool>> predicate)
        {
            var user = _reposiotry.Get(predicate);
            var userDto = new UserDto
             { 
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName=user.LastName,
                Address = user.Address

            
             };
            return userDto;

        }

        public List<UserDto> GetAll(Expression<Func<User, bool>>? predicate, bool AsNoTracking)
        {
           var user =_reposiotry.GetAll(predicate, AsNoTracking);
           var userDtoList = new List<UserDto>();
            foreach ( var item in user)
            {
                userDtoList.Add(new UserDto
                {
                    UserName = item.UserName,
                    Email = item.Email,
                    FirstName = item.FirstName,
                    LastName=item.LastName,
                    Address = item.Address

                });

            }

            return userDtoList;
        }

        public UserDto GetById(int id)
        {
           var user = _reposiotry.GetById(id);
            var userDto = new UserDto
           { 
                UserName = user.UserName,
                Email=user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address
           };

            return userDto;

        }

        public void Remove(int id)
        {
            var existEntity=_reposiotry.GetById(id);
            if (existEntity == null) throw new Exception("Not found");

            _reposiotry.Remove(existEntity);
        }

        public void Update(UpdateUserDto updateDto)
        {
            var user = new User
            {
                UserName = updateDto.UserName,
                Id = updateDto.Id,
                FirstName = updateDto.FirstName,
                LastName = updateDto.LastName,
                Address = updateDto.Address,
                Email = updateDto.Email

            };
           _reposiotry.Update(user);
        }
    }
}
