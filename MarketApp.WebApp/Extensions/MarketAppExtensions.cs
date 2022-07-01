using MarketApp.BL.Abstract;
using MarketApp.BL.Concrete;
using MarketApp.WebApp.AutoMapper;

namespace MarketApp.WebApp.Extensions
{
    public static class MarketAppExtensions
    {
        public static IServiceCollection AddMarketManagerService(this IServiceCollection Services)
        {
            
            Services.AddScoped<ITaxManager, TaxManager>();
            Services.AddScoped<IProductManager, ProductManager>();
            Services.AddScoped<ISupplierManager, SupplierManager>();
            Services.AddScoped<ICatagoryManager, CategoryManager>();
            Services.AddScoped<ITaxManager, TaxManager>();
            Services.AddAutoMapper(typeof(ProductMap));

            return Services;    
        }
    }
}
