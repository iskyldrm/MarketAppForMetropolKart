using AutoMapper;
using MarketApp.Entities.Concrete;
using MarketApp.WebApp.DTO;

namespace MarketApp.WebApp.AutoMapper
{
    public class ProductMap:Profile
    {
        public ProductMap()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(listdto => listdto.CategoryID, src => src.MapFrom(p => p.Category.CategoryName))
                .ForMember(listdto => listdto.SupplierID, src => src.MapFrom(p => p.Supplier.CompanyName))
                .ForMember(listdto => listdto.TaxId, src => src.MapFrom(p => p.Kdv.TaxType));

            CreateMap<ProductDTO, Product>();
        }
    }
}
