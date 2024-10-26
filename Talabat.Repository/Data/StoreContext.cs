using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Order_Aggregate;
using Talabat.Repository.Data.Configurations;

namespace Talabat.Repository.Data
{
	public class StoreContext : DbContext
	{
		public StoreContext(DbContextOptions<StoreContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Flent Api
			//modelBuilder.ApplyConfiguration(new ProductConfig());
			//modelBuilder.ApplyConfiguration(new BrandConfig());
			//modelBuilder.ApplyConfiguration(new CategoryConfig());
			//modelBuilder.ApplyConfiguration(new DeliveryMethodConfig());
			//modelBuilder.ApplyConfiguration(new OrderConfig());
			//modelBuilder.ApplyConfiguration(new OrderItemConfig());
			//OR
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
    }
}
