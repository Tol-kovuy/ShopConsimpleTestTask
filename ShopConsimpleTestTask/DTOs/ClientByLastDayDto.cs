namespace ShopConsimpleTestTask.DTOs
{
    public class ClientByLastDayDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime LastPurchaseDate { get; set; }
    }
}
