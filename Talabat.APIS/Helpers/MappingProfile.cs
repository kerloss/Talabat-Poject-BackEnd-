using AutoMapper;
using Talabat.APIS.DTOs;
using Talabat.Core_DomainLayer_.Enitities_Models_;

namespace Talabat.APIS.Helpers
{
	public class MappingProfile : Profile
	{

		public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(D => D.Brand, O => O.MapFrom(s => s.Brand.Name))
                .ForMember(D => D.Category, O => O.MapFrom(s => s.Category.Name))
                .ForMember(D => D.PictureUrl, O => O.MapFrom<ProductPictureUrlResolver>()); //{BaseUrl}/picture/

            CreateMap<CustomerBasketDto, CustomerBasketDto>();
            CreateMap<BasketItemDto, BasketItemDto>();
		}
    }
}
