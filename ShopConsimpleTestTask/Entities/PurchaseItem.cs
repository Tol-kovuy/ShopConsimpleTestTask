namespace ShopConsimpleTestTask.Entities
{
    public class PurchaseItem : Entity
    {
        public Guid PurchaseId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
    }
}
