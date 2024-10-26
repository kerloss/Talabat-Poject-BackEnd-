using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Order_Aggregate;

namespace Talabat.Core_DomainLayer_.Services.Contract
{
	public interface IOrderService
	{
		Task<Order?> CreateOrderAsync(string buyerEmail, string basketID, int deliveryMethodId, Address ShippingAddress);
		Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
		Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail);
	}
}
