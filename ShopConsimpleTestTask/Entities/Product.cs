namespace ShopConsimpleTestTask.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string ArticleNumber { get; set; }
        public decimal Price { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
    }
}
