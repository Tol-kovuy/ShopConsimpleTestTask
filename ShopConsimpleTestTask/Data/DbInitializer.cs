using ShopConsimpleTestTask.Entities;

namespace ShopConsimpleTestTask.Data
{
    public static class DbInitializer
    {
        // TODO: Seed db
        public static void Seed(ShopDbContext context, ILogger? logger = null)
        {
            logger?.LogInformation("Start seed BD");

            logger?.LogInformation("Cleansing the existing data");
            context.PurchaseItems.RemoveRange(context.PurchaseItems);
            context.Purchases.RemoveRange(context.Purchases);
            context.Products.RemoveRange(context.Products);
            context.Clients.RemoveRange(context.Clients);
            context.SaveChanges();

            var today = DateTime.Today;

            var clients = new List<Client>
        {
            new Client
            {
                FullName = "Іваненко Іван Іванович",
                DateOfBirth = new DateTime(1990, today.Month, today.Day),
                RegistrationDate = new DateTime(2020, 1, 15)
            },
            new Client
            {
                FullName = "Петренко Петро Петрович",
                DateOfBirth = new DateTime(1985, today.Month, today.Day),
                RegistrationDate = new DateTime(2019, 3, 10)
            },
            new Client
            {
                FullName = "Коваленко Марія Олександрівна",
                DateOfBirth = new DateTime(1992, 8, 15),
                RegistrationDate = new DateTime(2021, 6, 5)
            },
            new Client
            {
                FullName = "Сидоренко Олександр Володимирович",
                DateOfBirth = new DateTime(1988, 3, 10),
                RegistrationDate = new DateTime(2022, 2, 20)
            },
            new Client
            {
                FullName = "Мельник Олена Сергіївна",
                DateOfBirth = new DateTime(1995, today.Month, today.Day),
                RegistrationDate = new DateTime(2023, 4, 12)
            }
        };

            context.Clients.AddRange(clients);
            context.SaveChanges();

            var products = new List<Product>
        {
            new Product
            {
                Name = "Ноутбук Dell XPS",
                Category = "Електроніка",
                ArticleNumber = "ELEC-001",
                Price = 35000.00m
            },
            new Product
            {
                Name = "Смартфон Samsung Galaxy",
                Category = "Електроніка",
                ArticleNumber = "ELEC-002",
                Price = 18000.00m
            },
            new Product
            {
                Name = "Навушники Sony",
                Category = "Електроніка",
                ArticleNumber = "ELEC-003",
                Price = 2500.00m
            },
            new Product
            {
                Name = "Планшет iPad",
                Category = "Електроніка",
                ArticleNumber = "ELEC-004",
                Price = 22000.00m
            },
            new Product
            {
                Name = "Футболка чоловіча",
                Category = "Одяг",
                ArticleNumber = "CLOTH-001",
                Price = 450.00m
            },
            new Product
            {
                Name = "Джинси Levis",
                Category = "Одяг",
                ArticleNumber = "CLOTH-002",
                Price = 1500.00m
            },
            new Product
            {
                Name = "Куртка зимова",
                Category = "Одяг",
                ArticleNumber = "CLOTH-003",
                Price = 3200.00m
            },
            new Product
            {
                Name = "Кросівки Nike",
                Category = "Одяг",
                ArticleNumber = "CLOTH-004",
                Price = 2800.00m
            },
            new Product
            {
                Name = "Хліб білий",
                Category = "Продукти",
                ArticleNumber = "FOOD-001",
                Price = 25.00m
            },
            new Product
            {
                Name = "Молоко 1л",
                Category = "Продукти",
                ArticleNumber = "FOOD-002",
                Price = 35.00m
            },
            new Product
            {
                Name = "Яйця курячі 10шт",
                Category = "Продукти",
                ArticleNumber = "FOOD-003",
                Price = 65.00m
            },
            new Product
            {
                Name = "Книга 'C# для початківців'",
                Category = "Книги",
                ArticleNumber = "BOOK-001",
                Price = 450.00m
            },
            new Product
            {
                Name = "Книга 'Entity Framework'",
                Category = "Книги",
                ArticleNumber = "BOOK-002",
                Price = 550.00m
            }
        };

            context.Products.AddRange(products);
            context.SaveChanges();

            var purchases = new List<Purchase>
        {
            new Purchase
            {
                Number = "PUR-001",
                Date = today.AddDays(-1),
                ClientId = clients[0].Id,
                TotalCost = 53000.00m
            },
            new Purchase
            {
                Number = "PUR-002",
                Date = today.AddDays(-3),
                ClientId = clients[0].Id,
                TotalCost = 900.00m
            },
            new Purchase
            {
                Number = "PUR-003",
                Date = today.AddDays(-5),
                ClientId = clients[0].Id,
                TotalCost = 2500.00m
            },
            new Purchase
            {
                Number = "PUR-004",
                Date = today.AddDays(-2),
                ClientId = clients[1].Id,
                TotalCost = 18000.00m
            },
            new Purchase
            {
                Number = "PUR-005",
                Date = today.AddDays(-4),
                ClientId = clients[1].Id,
                TotalCost = 4300.00m
            },
            new Purchase
            {
                Number = "PUR-006",
                Date = today.AddDays(-1),
                ClientId = clients[2].Id,
                TotalCost = 1950.00m
            },
            new Purchase
            {
                Number = "PUR-007",
                Date = today.AddDays(-6),
                ClientId = clients[2].Id,
                TotalCost = 125.00m
            },
            new Purchase
            {
                Number = "PUR-008",
                Date = today.AddDays(-15),
                ClientId = clients[3].Id,
                TotalCost = 22000.00m
            },
            new Purchase
            {
                Number = "PUR-009",
                Date = today.AddDays(-1),
                ClientId = clients[4].Id,
                TotalCost = 1000.00m
            }
        };

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            var purchaseItems = new List<PurchaseItem>
        {
            new PurchaseItem
            {
                PurchaseId = purchases[0].Id,
                ProductId = products[0].Id,
                Quantity = 1,
                UnitPrice = 35000.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[0].Id,
                ProductId = products[1].Id,
                Quantity = 1,
                UnitPrice = 18000.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[1].Id,
                ProductId = products[4].Id,
                Quantity = 2,
                UnitPrice = 450.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[2].Id,
                ProductId = products[2].Id,
                Quantity = 1,
                UnitPrice = 2500.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[3].Id,
                ProductId = products[1].Id,
                Quantity = 1,
                UnitPrice = 18000.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[4].Id,
                ProductId = products[5].Id,
                Quantity = 1,
                UnitPrice = 1500.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[4].Id,
                ProductId = products[7].Id,
                Quantity = 1,
                UnitPrice = 2800.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[5].Id,
                ProductId = products[4].Id,
                Quantity = 1,
                UnitPrice = 450.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[5].Id,
                ProductId = products[5].Id,
                Quantity = 1,
                UnitPrice = 1500.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[6].Id,
                ProductId = products[8].Id,
                Quantity = 2,
                UnitPrice = 25.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[6].Id,
                ProductId = products[9].Id,
                Quantity = 3,
                UnitPrice = 35.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[7].Id,
                ProductId = products[3].Id,
                Quantity = 1,
                UnitPrice = 22000.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[8].Id,
                ProductId = products[11].Id,
                Quantity = 1,
                UnitPrice = 450.00m
            },
            new PurchaseItem
            {
                PurchaseId = purchases[8].Id,
                ProductId = products[12].Id,
                Quantity = 1,
                UnitPrice = 550.00m
            }
        };

            context.PurchaseItems.AddRange(purchaseItems);
            context.SaveChanges();

            logger?.LogInformation("The database is successfully filled with test data: {ClientsCount} clients, {ProductsCount} products, {PurchasesCount} purchases, {ItemsCount} positions",
                clients.Count, products.Count, purchases.Count, purchaseItems.Count);
        }
    }
}
