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
		public Expression<Func<T,object>> OrderBy { get; set; } //OrderBy(P=>P.Name)
        public Expression<Func<T,object>> OrderByDesc { get; set; } //OrderByDesc(P=>P.Name)
        public Expression<Func<T,object>> ThenBy { get; set; } //ThenBy(P=>P.Name)
        public Expression<Func<T,object>> ThenByDesc { get; set; } //ThenByDesc(P=>P.Name)
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginationEnabled { get; set; }
    }
}
