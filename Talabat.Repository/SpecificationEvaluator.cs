using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Specifications;

namespace Talabat.Repository
{
	public static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
	{
		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> innnerQuery, ISpecifications<TEntity> specifications)
		{
			var query = innnerQuery; //_dbContext.set<Product>()  TEntity => Product
			if (specifications.Critria is not null) //P => P.Id == id
			{
				query = query.Where(specifications.Critria); // _dbContext.set<Product>.where(P => P.Id == id)
			}

			// query = _dbContext.set<Product>.where(P => P.Id == id)

			#region Example of Aggregate function
			//string[] names = { "maha", "ahmed", "yehia" };
			//string msg = "hello";
			//msg = names.Aggregate(msg, (str01, str02) => $"{str01} {str02}"); //msg = hello maha ahmed yehia
			#endregion

			query = specifications.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
			// query = _dbContext.set<Product>.where(P => P.Id == id).Include(P => P.Brand)
			// query = _dbContext.set<Product>.where(P => P.Id == id).Include(P => P.Brand).Include(P => P.Category)
			
			return query;
		}
	}
}
