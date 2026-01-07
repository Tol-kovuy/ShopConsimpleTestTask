using Microsoft.EntityFrameworkCore;
using ShopConsimpleTestTask.Data;
using ShopConsimpleTestTask.Services;

internal class Program
{
    private static void Main(string[] args) 
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ShopDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddControllers();

        builder.Services.AddScoped<IShopService, ShopService>();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            logger.LogInformation("Create BD");
            context.Database.EnsureCreated();

            DbInitializer.Seed(context, logger);
        }

        app.UseRouting();
        app.MapControllers();
        app.Run();
    }
}