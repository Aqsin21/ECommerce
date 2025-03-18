namespace ECommerce.Domain.Entities
{
    public  class User:Entity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!; 
        public string? PhoneNumber { get; set; }
        public string Address { get; set; } = null!;
        public UserType Role { get; set; } = UserType.User;
        public ICollection<Order> Orders { get; set; } = new List<Order>();







    }
}
