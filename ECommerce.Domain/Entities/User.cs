namespace ECommerce.Domain.Entities
{
    public  class User:Entity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!; 
        public string? PhoneNumber { get; set; }
        public string Address { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();







    }
}
