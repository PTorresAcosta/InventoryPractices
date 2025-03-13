
using Microsoft.EntityFrameworkCore;
using Practice5DataAccess.Data;
using Practice5Bussiness.Interfaces;
using Practice5Bussiness.Implementations;
using Practice5DataAccess.DAOs.Interfaces;
using Practice5DataAccess.DAOs.Implementations;
using System.Web.Http;

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
            builder.Services.AddScoped<IInventoryDAO, InventoryDAO>();
            builder.Services.AddScoped<IInventoryBLL, InventoryBLL>();
            builder.Services.AddScoped<ISaleProductDAO, SaleProductDAO>();
            builder.Services.AddScoped<ISaleProductBLL, SaleProductBLL>();
            builder.Services.AddScoped<ISaleDAO, SaleDAO>();
            builder.Services.AddScoped<ISaleBLL, SaleBLL>();

            builder.Services.AddControllers();


            var app = builder.Build();



            app.UseHttpsRedirection();


            app.MapControllers();

            

            app.Run();
        }
    }
}
