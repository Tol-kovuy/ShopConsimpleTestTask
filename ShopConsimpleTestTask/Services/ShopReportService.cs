using Microsoft.EntityFrameworkCore;
using ShopConsimpleTestTask.Data;
using ShopConsimpleTestTask.DTOs;

namespace ShopConsimpleTestTask.Services
{
    public class ShopReportService : IShopReportService
    {
        private readonly ShopDbContext _context;
        private readonly ILogger<ShopReportService> _logger;

        public ShopReportService
            (
            ShopDbContext context,
            ILogger<ShopReportService> logger
            )
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<BirthdayClientDto>> GetBirthdayClientsAsync(DateTime date)
        {
            if (date > DateTime.UtcNow.AddYears(1))
            {
                _logger.LogWarning("Invalid date range: {Date}", date);
                throw new ArgumentException("Invalid date range");
            }

            try
            {
                var dateOnly = date.Date;

                var clients = await _context.Clients
                    .Where(c => c.DateOfBirth.Month == dateOnly.Month &&
                    c.DateOfBirth.Day == dateOnly.Day)
                     .Select(c => new BirthdayClientDto
                     {
                         Id = c.Id,
                         FullName = c.FullName
                     })
                    .ToListAsync();

                _logger.LogInformation("Found {Count} birthdays on date {Date}", clients.Count, date.ToString("yyyy-MM-dd"));

                return clients;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message: "Error by date {Date}", date);
                throw;
            }
        }

        public async Task<IEnumerable<ClientByLastDayDto>> GetBuyersByLastDaysAsycn(int days, DateTime? referenceDate = null)
        {
            if (days <= 0)
            {
                _logger.LogWarning("Error param days: {Days}. Days may be > 0\"", days);
                throw new ArgumentException("Days may be > 0", nameof(days));
            }

            var reference = referenceDate?.Date ?? DateTime.UtcNow.Date;
            var cutoffDate = reference.AddDays(-days);

            try
            {
                var buyers = await _context.Purchases
                    .Where(p => p.Date >= cutoffDate)
                    .GroupBy(p => p.Client)
                    .Select(g => new ClientByLastDayDto
                    {
                        Id = g.Key.Id,
                        FullName = g.Key.FullName,
                        LastPurchaseDate = g.Max(p => p.Date)
                    })
                    .OrderByDescending(b => b.LastPurchaseDate)
                    .ToListAsync();

                _logger.LogInformation("Found {Count} buyers for remaining {Days} days", buyers.Count, days);
                return buyers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error by days {Days} days", days);
                throw;
            }
        }

        public async Task<IEnumerable<ProductCategoryDto>> GetCategoriesByClientAsync(Guid clientId)
        {
            try
            {
                var clientExists = await _context.Clients.AnyAsync(c => c.Id == clientId);
                if (!clientExists)
                {
                    _logger.LogWarning("Wrong client ID {ClientId} ", clientId);
                    throw new KeyNotFoundException($"No client by ID {clientId}");
                }

                var categories = await _context.PurchaseItems
                    .Where(pi => pi.Purchase.ClientId == clientId)
                    .GroupBy(pi => pi.Product.Category)
                    .Select(g => new ProductCategoryDto
                    {
                        Category = g.Key,
                        Quantity = g.Sum(pi => pi.Quantity)
                    })
                    .OrderByDescending(c => c.Quantity)
                    .ToListAsync();

                _logger.LogInformation("You have {Count} categories by client ID {ClientId}", categories.Count, clientId);
                return categories;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error by client ID {ClientId}", clientId);
                throw;
            }
        }
    }
}
