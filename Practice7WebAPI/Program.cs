
using Microsoft.EntityFrameworkCore;
using Practice5Bussiness;
using Practice5DataAccess.Data;
using Practice5DataAccess;

namespace Practice7WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IProductBLL, ProductBLL>();
            builder.Services.AddScoped<IProductDAO, ProductDAO>();
            builder.Services.AddScoped<IPurchaseDAO, PurchaseDAO>();
            builder.Services.AddScoped<IPurchaseBLL, PurchaseBLL>();
            builder.Services.AddScoped<IPurchaseProductDAO, PurchaseProductDAO>();
            builder.Services.AddScoped<IPurchaseProductBLL, PurchaseProductBLL>();

            builder.Services.AddControllers();
            

            var app = builder.Build();

            

            app.UseHttpsRedirection();


            app.MapControllers();

            app.Run();
        }
    }
}
