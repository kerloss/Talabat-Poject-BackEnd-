using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Order_Aggregate;

namespace Talabat.Repository.Data.Configurations
{
	public class OrderConfig : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			//Fluent API
			builder.Property(o => o.Status)
				   .HasConversion(OStatus => OStatus.ToString(),
								  OStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), OStatus));
			//1 [order] total => 1 [Address] total
			builder.OwnsOne(o => o.ShippingAddress, shippingAddress => shippingAddress.WithOwner());

			//builder.HasOne(o => o.DeliveryMethod).WithOne();
			//builder.HasIndex(o => o.DeliveryMethodID).IsUnique();

			builder.Property(o => o.SubTotal).HasColumnType("decimal(18,2)");
			builder.HasOne(o => o.DeliveryMethod).WithOne().OnDelete(DeleteBehavior.SetNull);
		}
	}
}
