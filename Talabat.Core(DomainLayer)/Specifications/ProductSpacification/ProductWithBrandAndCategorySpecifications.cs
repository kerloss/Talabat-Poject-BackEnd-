using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;

namespace Talabat.Core_DomainLayer_.Specifications.ProductSpacification
{
	public class ProductWithBrandAndCategorySpecifications : BaseSpecification<Product>
	{
        public ProductWithBrandAndCategorySpecifications() : base()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }
        public ProductWithBrandAndCategorySpecifications(int id) : base(P => P.Id == id)
        {
            Includes.Add(P => P.Id);
            Includes.Add(P => P.Category);
        }
    }
}
