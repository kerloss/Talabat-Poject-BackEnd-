using System.ComponentModel.DataAnnotations;
using Talabat.Core_DomainLayer_.Order_Aggregate;

namespace Talabat.APIS.DTOs
{
	public class OrderDto
	{
		[Required]
        public string BuyerEmail { get; set; }
		[Required]
		public string BasketId { get; set; }
		[Required]
		public int DeliveryMethodId { get; set; }
		public AddressDto ShipingAddress { get; set; }
    }
}
