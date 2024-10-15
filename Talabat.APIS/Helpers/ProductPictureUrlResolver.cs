using AutoMapper;
using Talabat.APIS.DTOs;
using Talabat.Core_DomainLayer_.Enitities_Models_;

namespace Talabat.APIS.Helpers
{
	public class ProductPictureUrlResolver : IValueResolver<Product, ProductDto, string>
	{
		private readonly IConfiguration _configuration;

		public ProductPictureUrlResolver(IConfiguration configuration)
        {
			_configuration = configuration;
		}
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
		{
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
				return $"{_configuration["ApiBaseUrl"]}/{source.PictureUrl}"; //BaseUrl/picture/PictureName
            }
			return string.Empty;
        }
	}
}
