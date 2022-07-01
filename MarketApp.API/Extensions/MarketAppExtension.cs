using MarketApp.API.AutoMapper;
using MarketApp.BL.Abstract;
using MarketApp.BL.Concrete;

namespace MarketApp.API.Extensions
{
    public static class MarketAppExtension
    {
        /// <summary>
        /// manager sınıfları için gerekli services extension metodu
        /// </summary>
        /// <param name="Services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMarketManagerService(this IServiceCollection Services)
        {
            Services.AddControllers();
            Services.AddScoped<ITaxManager, TaxManager>();
            Services.AddScoped<IProductManager, ProductManager>();
            Services.AddScoped<ISupplierManager, SupplierManager>();
            Services.AddScoped<ICatagoryManager, CategoryManager>();
            Services.AddScoped<ITaxManager, TaxManager>();
            Services.AddAutoMapper(typeof(ProductMapping));

            return Services;
        }
    }
}
