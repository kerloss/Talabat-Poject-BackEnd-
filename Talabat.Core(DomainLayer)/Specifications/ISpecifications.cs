using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;

namespace Talabat.Core_DomainLayer_.Specifications
{
	public interface ISpecifications<T> where T : BaseEntity
	{
		//critria = where condition
        public Expression<Func<T,bool>> Critria { get; set; } //P => P.Id == id
        public List<Expression<Func<T,object>>> Includes { get; set; } //{P => P.Brand , P => P.Category}
	}
}
