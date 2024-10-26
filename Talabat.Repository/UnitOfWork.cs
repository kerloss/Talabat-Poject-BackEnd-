using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Order_Aggregate;
using Talabat.Core_DomainLayer_.Repositories.Contract;
using Talabat.Repository.Data;
using Talabat.Repository.Repository.Contract;

namespace Talabat.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly StoreContext _dbContext;
		private Hashtable _repository;

		public UnitOfWork(StoreContext dbContext) // Ask clr for creating object from DbContext[storeContext]
        {
			_dbContext = dbContext;
			_repository = new Hashtable();
		}

		public async ValueTask DisposeAsync()
		{
			await _dbContext.DisposeAsync();
		}

		public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity //TEntity => order
		{
			var key = typeof(TEntity).Name; //order
            if (!_repository.ContainsKey(key))
            {
				var repository = new GenericRepository<TEntity>(_dbContext);
				_repository.Add(key, repository);
			}
			return _repository[key] as IGenericRepository<TEntity>;
        }

		//public IGenericRepository<Product> ProductsRepo { get; set; }	//null
		//public IGenericRepository<ProductBrand> BrandsRepo { get; set; }	//null
		//public IGenericRepository<ProductCategory> CategorysRepo { get; set; }	//null
		//public IGenericRepository<DeliveryMethod> DeliveryMethodRepo { get; set; }	//null
		//public IGenericRepository<OrderItem> OrderItemsRepo { get; set; }	//null
		//public IGenericRepository<Order> OrdersRepo { get; set; }	//null

		public async Task<int> SaveChangesAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
	}
}
