using Microsoft.AspNetCore.Mvc;
using ShopConsimpleTestTask.DTOs;
using ShopConsimpleTestTask.Services;

namespace ShopConsimpleTestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        private readonly ILogger<ShopController> _logger;

        public ShopController(IShopService shopService, ILogger<ShopController> logger)
        {
            _shopService = shopService;
            _logger = logger;
        }

        [HttpGet("birthday-clients/{date}")]
        public async Task<ActionResult<IEnumerable<BirthdayClientDto>>> GetBirthdayClientsAsync(DateTime date)
        {
            try
            {
                var clients = await _shopService.GetBirthdayClientsAsync(date);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error by {Date}", date);
                return StatusCode(500, "Inner server error");
            }
        }

        [HttpGet("buyers-by-last-days/{days}")]
        public async Task<ActionResult<IEnumerable<ClientByLastDayDto>>> GetBuyersByLastDaysAsycn(int days)
        {
            try
            {
                var buyers = await _shopService.GetBuyersByLastDaysAsycn(days);
                return Ok(buyers);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Wrong param days: {Days}. {Message}", days, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Eroor by days {Days}", days);
                return StatusCode(500, "Inner server error");
            }
        }

        [HttpGet("categories-by-client/{clientId}")]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetCategoriesByClientAsync(Guid clientId)
        {
            try
            {
                var categories = await _shopService.GetCategoriesByClientAsync(clientId);
                return Ok(categories);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning("Client by ID {ClientId} not found", clientId);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Err by client ID {ClientId}", clientId);
                return StatusCode(500, "Inner server error");
            }
        }
    }
}
