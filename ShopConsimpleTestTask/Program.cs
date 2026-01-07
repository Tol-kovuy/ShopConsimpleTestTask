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
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "ConsimpleShopTesttask API",
                Version = "v1",
                Description = "develop by Maksym",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Shop API Support"
                }
            });
        });

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

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConsimpleShopTesttask API v1");
            c.RoutePrefix = string.Empty; 
        });

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}