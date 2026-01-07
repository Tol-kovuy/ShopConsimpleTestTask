using ShopConsimpleTestTask.DTOs;

namespace ShopConsimpleTestTask.Services
{
    public interface IShopService
    {
        // Повертає список клієнтів (id, ПІБ), у яких сьогодні день народження
        Task<IEnumerable<BirthdayClientDto>> GetBirthdayClientsAsync(DateTime date);

        // Повертає список клієнтів (id, ПІБ), які придбали за останні N днів. Для кожного клієнта необхідно виводити дату його останньої покупки.
        Task<IEnumerable<ClientByLastDayDto>> GetBuyersByLastDaysAsycn(int days);

        // Повертає список категорій продуктів, які купував знайдений клієнт. Для кожної категорії повертає кількість куплених одиниць.
        Task<IEnumerable<ProductCategoryDto>> GetCategoriesByClientAsync(Guid clientId);
    }
}
