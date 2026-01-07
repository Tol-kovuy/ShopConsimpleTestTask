namespace ShopConsimpleTestTask.Entities
{
    public class Client : Entity
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
