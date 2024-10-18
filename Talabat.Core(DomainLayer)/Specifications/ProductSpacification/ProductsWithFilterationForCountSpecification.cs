using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;

namespace Talabat.Core_DomainLayer_.Specifications.ProductSpacification
{
	public class ProductsWithFilterationForCountSpecification : BaseSpecification<Product>
	{
        public ProductsWithFilterationForCountSpecification(ProductSpecificationParams specificationParams) : base(P =>
        (string.IsNullOrEmpty(specificationParams.Search) || P.Name.ToLower().Contains(specificationParams.Search.ToLower())) &&
        (!specificationParams.BrandId.HasValue || P.BrandId == specificationParams.BrandId.Value) && //true
        (!specificationParams.CategoryId.HasValue || P.CategoryId == specificationParams.CategoryId.Value) //true
		)
        {
            
        }
    }
}
