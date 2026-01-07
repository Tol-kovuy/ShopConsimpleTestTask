namespace ShopConsimpleTestTask.Entities
{
    public class Purchase : Entity
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCost { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
    }
}
