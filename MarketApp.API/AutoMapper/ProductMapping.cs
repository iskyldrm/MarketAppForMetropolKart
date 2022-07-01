using AutoMapper;
using MarketApp.API.Models;
using MarketApp.Entities.Concrete;

namespace MarketApp.API.AutoMapper
{
    public class ProductMapping:Profile
    {
        /// <summary>
        /// Listeleme için gerekli mapping işlemi. İlişkili ID ler yerine İlişkili name ler gelmesi için.
        /// </summary>
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(listdto => listdto.CategoryID, src => src.MapFrom(p=>p.Category.CategoryName))
                .ForMember(listdto => listdto.SupplierID, src => src.MapFrom(p => p.Supplier.CompanyName))
                .ForMember(listdto => listdto.TaxId, src => src.MapFrom(p => p.Kdv.TaxType));

            CreateMap<ProductDTO, Product>();
        }
    }
}
