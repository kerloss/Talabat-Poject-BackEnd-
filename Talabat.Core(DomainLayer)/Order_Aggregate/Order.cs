using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;

namespace Talabat.Core_DomainLayer_.Order_Aggregate
{
	public class Order : BaseEntity
	{
        public Order()
        {
            
        }
        public Order(string buyerEmail, Address shippingAddress, DeliveryMethod deliveryMethod, ICollection<OrderItem> orderItems, decimal subTotal	)
		{
			BuyerEmail = buyerEmail;
			ShippingAddress = shippingAddress;
			DeliveryMethod = deliveryMethod;
			OrderItems = orderItems;
			SubTotal = subTotal;
		}

		public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public OrderStatus Status { get; set; }
        public Address ShippingAddress { get; set; }
        public int? DeliveryMethodId { get; set; } //FK [delivery][optional]
        public DeliveryMethod? DeliveryMethod { get; set; } //relation 1 [order][Mandatory]=> [Delivery][optional] 1
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>(); //avigation prop [Many]
        public decimal SubTotal { get; set; } // =orderItem * Qunatity
        //public decimal Total { get; set; } //subTotal + DeliveyMethod
        public string PaymentIntentId { get; set; }

        // GetTotal = subTotal+DeliveryMethod
        public decimal GetTotal() => SubTotal + DeliveryMethod.Cost;


	}

}
