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
        public ProductWithBrandAndCategorySpecifications(ProductSpecificationParams specificationParams) : base(P =>
            //brandId = null
            //categoryid = null
            //P.Name.ToLower().Contains(spec.Search.ToLower())
            (string.IsNullOrEmpty(specificationParams.Search) || P.Name.ToLower().Contains(specificationParams.Search.ToLower())) &&
            (!specificationParams.BrandId.HasValue || P.BrandId == specificationParams.BrandId.Value) && //true
            (!specificationParams.CategoryId.HasValue || P.CategoryId == specificationParams.CategoryId.Value) //true
            )
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
            if (!string.IsNullOrEmpty(specificationParams.Sort))
            {
                switch (specificationParams.Sort)
                {
                    case "priceAsc":
                        //OrderBy(P=>P.Price)
                        AddOrderBy(P => P.Price);
                        break;
                    case "priceDesc":
                        //OrderByDesc(P=>P.Price)
                        AddOrderByDesc(P => P.Price);
                        break;
                    case "Name":
                        AddOrderBy(P => P.Name);
                        break;
                    default:
                        AddOrderBy(P => P.Id);
                        break;
                }
            }
            else
                AddOrderBy(P => P.Id);

            //totalProduct = 18
            //pageSize = 5
            //pageIndex = 2

            ApplyPagination((specificationParams.PageIndex - 1) * specificationParams.PageSize, specificationParams.PageSize);
        }
        public ProductWithBrandAndCategorySpecifications(int id) : base(P => P.Id == id)
        {
            Includes.Add(P => P.Id);
            Includes.Add(P => P.Category);
        }
    }
}
