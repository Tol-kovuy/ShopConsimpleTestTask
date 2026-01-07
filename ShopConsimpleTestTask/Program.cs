using Microsoft.EntityFrameworkCore;
using ShopConsimpleTestTask.Data;

internal class Program
{
    private static void Main(string[] args) 
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ShopDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddControllers();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
            dbContext.Database.Migrate(); 
        }

        app.UseRouting();
        app.MapControllers();
        app.Run();
    }
}