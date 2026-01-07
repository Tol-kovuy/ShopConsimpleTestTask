using ShopConsimpleTestTask.DTOs;

namespace ShopConsimpleTestTask.Services
{
    public class ShopService : IShopService
    {
        public Task<IEnumerable<BirthdayClientDto>> GetBirthdayClientsAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientByLastDayDto>> GetBuyersByLastDaysAsycn(int days)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductCategoryDto>> GetCategoriesByClientAsync(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
