using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Specifications;

namespace Talabat.Core_DomainLayer_.Repositories.Contract
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<T?> GetAsync(int id);
		Task<IReadOnlyList<T>> GetAllAsync();
		Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(ISpecifications<T> specifications);
		Task<T?> GetWithSpecificationAsync(ISpecifications<T> specifications);
		Task<int> GetCountAsync(ISpecifications<T> specifications);
		Task AddAsync(T entity);
		void UpdateAsync(T entity);
		void DeleteAsync(T entity);

	}
}
