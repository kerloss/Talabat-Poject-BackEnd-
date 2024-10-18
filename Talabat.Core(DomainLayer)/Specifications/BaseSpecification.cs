using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;

namespace Talabat.Core_DomainLayer_.Specifications
{
	public class BaseSpecification<T> : ISpecifications<T> where T : BaseEntity
	{
		public Expression<Func<T, bool>> Critria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
		public Expression<Func<T, object>> OrderBy { get; set; } //null
		public Expression<Func<T, object>> OrderByDesc { get; set; } //null
		public Expression<Func<T, object>> ThenBy { get; set; } //null
		public Expression<Func<T, object>> ThenByDesc { get; set; }	//null
		public int Take { get; set; } //0
		public int Skip { get; set; } //0
		public bool IsPaginationEnabled { get; set; } = false;

		public BaseSpecification()
        {
            // critria = null
        }
        public BaseSpecification(Expression<Func<T,bool>> critriaExpression) //P => P.Id == id
        {
            Critria = critriaExpression;
        }
        public void AddOrderBy(Expression<Func<T,object>> OrderByExpression) //just setter for orderBy
        {
            OrderBy = OrderByExpression;
        }
		public void AddOrderByDesc(Expression<Func<T, object>> OrderByExpression) //just setter for orderByDesc
		{
			OrderByDesc = OrderByExpression;
		}
		public void AddThenBy(Expression<Func<T, object>> OrderByExpression) //just setter for ThenBy
		{
			ThenBy = OrderByExpression;
		}
		public void AddThenByDesc(Expression<Func<T, object>> OrderByExpression) //just setter for ThenByDesc
		{
			ThenByDesc = OrderByExpression;
		}
		public void ApplyPagination(int skip ,int take)
		{
			IsPaginationEnabled = true;
			Skip = skip;
			Take = take;
		}
	}
}
