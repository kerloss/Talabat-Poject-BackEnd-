using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;

namespace Talabat.Repository.Data.Configurations
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			//Fluet APIs
			builder.Property(P => P.Name)
				   .IsRequired()
				   .HasMaxLength(50);

			builder.Property(P => P.Description).IsRequired();
			builder.Property(P => P.PictureUrl).IsRequired().HasColumnName("Picture Url");

			builder.Property(P => P.Price).HasColumnType("decimal(18,2)");

			builder.HasOne(B => B.Brand)
				   .WithMany(P => P.Products)
				   .HasForeignKey(P => P.BrandId);

			builder.HasOne(C => C.Category)
				   .WithMany(P => P.Products)
				   .HasForeignKey(P => P.CategoryId);
		}
	}
}
