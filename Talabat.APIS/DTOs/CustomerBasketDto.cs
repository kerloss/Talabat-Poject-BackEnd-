using Talabat.Core_DomainLayer_.Enitities_Models_;

namespace Talabat.APIS.DTOs
{
	public class CustomerBasketDto
	{
		public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}
