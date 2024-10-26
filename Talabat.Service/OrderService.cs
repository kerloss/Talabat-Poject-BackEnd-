using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Order_Aggregate;
using Talabat.Core_DomainLayer_.Repositories.Contract;
using Talabat.Core_DomainLayer_.Services.Contract;

namespace Talabat.Service
{
	public class OrderService : IOrderService
	{
		private readonly IBasketRepository _basketRepository;
		private readonly IUnitOfWork _unitOfWork;
		//private readonly IGenericRepository<Product> _productRepo;
		//private readonly IGenericRepository<DeliveryMethod> _deliveryMethodRepo;
		//private readonly IGenericRepository<Order> _orderRepo;

		public OrderService(IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
			_basketRepository = basketRepository;
			_unitOfWork = unitOfWork;
			//_productRepo = productRepo;
			//_deliveryMethodRepo = deliveryMethodRepo;
			//_orderRepo = orderRepo;
		}
        public async Task<Order?> CreateOrderAsync(string buyerEmail, string basketID, int deliveryMethodId, Address ShippingAddress)
		{
			// 1. Get Basket From basket Repo
			var basket = await _basketRepository.GetBasketAsync(basketID);

			// 2. Get Selected Items at Basket From Products Repo
			var orderItems = new List<OrderItem>();
            if (basket?.Items?.Count > 0)
            {
				foreach (var item in basket.Items)
				{
					var product = await _unitOfWork.Repository<Product>().GetAsync(item.Id);
					var productItemOrdered = new ProductItemOrdered(item.Id, product.Name, product.PictureUrl);
					var orderItem = new OrderItem(productItemOrdered, product.Price, item.Quantity);
					orderItems.Add(orderItem);
				}
            }

			// 3. Calculate SubTotal
			var subTotal = orderItems.Sum(orderItem => orderItem.Price * orderItem.Quantity);

			// 4. Get Delivery Method From DeliveryMethod Repo
			var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetAsync(deliveryMethodId);

			// 5. Create Order	order Repo
			var order = new Order(buyerEmail, ShippingAddress, deliveryMethod, orderItems, subTotal);
			await _unitOfWork.Repository<Order>().AddAsync(order);

			// 6. Save To DataBase
			var result = await _unitOfWork.SaveChangesAsync();
			if (result <= 0) return null;
			return order;
        }

		public Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
		{
			throw new NotImplementedException();
		}
	}
}
