using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core_DomainLayer_.Enitities_Models_
{
	public class Product : BaseEntity
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        [InverseProperty("Products")]
        public ProductBrand Brand { get; set; } //Navigation Properity
        public int BrandId { get; set; } //FK
        [InverseProperty("Products")]
        public ProductCategory Category { get; set; } //Navigation Properity
        public int CategoryId { get; set; } //FK
    }
}
