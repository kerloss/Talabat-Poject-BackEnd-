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

        public BaseSpecification()
        {
            // critria = null
        }
        public BaseSpecification(Expression<Func<T,bool>> critriaExpression) //P => P.Id == id
        {
            Critria = critriaExpression;
        }
    }
}
