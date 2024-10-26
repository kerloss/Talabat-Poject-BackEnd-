using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Order_Aggregate;
using Talabat.Core_DomainLayer_.Repositories.Contract;

namespace Talabat.Core_DomainLayer_
{
	public interface IUnitOfWork : IAsyncDisposable
	{
        //public IGenericRepository<Product> ProductsRepo { get; set; }
        //public IGenericRepository<ProductBrand> BrandsRepo { get; set; }
        //public IGenericRepository<ProductCategory> CategorysRepo { get; set; }
        //public IGenericRepository<DeliveryMethod> DeliveryMethodRepo { get; set; }
        //public IGenericRepository<OrderItem> OrderItemsRepo { get; set; }
        //public IGenericRepository<Order> OrdersRepo { get; set; }

        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
