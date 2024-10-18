using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Repositories.Contract;
using Talabat.Core_DomainLayer_.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly StoreContext _dbContext;

		public GenericRepository(StoreContext dbContext)
        {
			_dbContext = dbContext;
		}

        public async Task<IReadOnlyList<T>> GetAllAsync()
		{
            if (typeof(T) == typeof(Product))
            {
				return (IReadOnlyList<T>)await _dbContext.Set<Product>().Include(P => P.Brand).Include(P => P.Category).ToListAsync();
            }
			return await _dbContext.Set<T>().ToListAsync();
		} //old

		public async Task<T> GetAsync(int id)
		{
			if(typeof(T) == typeof(Product))
			{
				return await _dbContext.Set<Product>().Where(P => P.Id == id).Include(P => P.Brand).Include(P => P.Category).FirstOrDefaultAsync() as T;
			}
			return await _dbContext.Set<T>().FindAsync(id);
		} //old

		public async Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(ISpecifications<T> specifications)
		{
			return await SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), specifications).ToListAsync();
			//OR
			//return await ApplySpecification(specifications).ToListAsync();
		}
		public async Task<T> GetWithSpecificationAsync(ISpecifications<T> specifications)
		{
			return await ApplySpecification(specifications)/*SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), specifications)*/.FirstOrDefaultAsync();
		}
		public async Task<int> GetCountAsync(ISpecifications<T> specifications)
		{
			return await ApplySpecification(specifications).CountAsync();
		}

		//function to avoid repeat of this line SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), specifications)
		private IQueryable<T> ApplySpecification(ISpecifications<T> specifications)
		{
			return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), specifications);
		}
	}
}
