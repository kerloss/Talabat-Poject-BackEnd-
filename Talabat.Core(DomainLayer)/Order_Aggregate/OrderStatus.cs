using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core_DomainLayer_.Order_Aggregate
{
	public enum OrderStatus
	{
		[EnumMember(Value = "pending")]
		pending,
		[EnumMember(Value = "PaymentSucceded")]
		PaymentSucceded,
		[EnumMember(Value = "PaymentFailed")]
        PaymentFailed,
		[EnumMember(Value = "Cancelled")]
		Cancelled,
		[EnumMember(Value = "Delivered")]
		Delivered
	}
}
