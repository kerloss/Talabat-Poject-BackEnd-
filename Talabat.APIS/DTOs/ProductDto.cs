﻿using System.ComponentModel.DataAnnotations.Schema;
using Talabat.Core_DomainLayer_.Enitities_Models_;

namespace Talabat.APIS.DTOs
{
	public class ProductDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
		public string PictureUrl { get; set; }
		public decimal Price { get; set; }
		//[InverseProperty("Products")]
		public string Brand { get; set; } //Navigation Properity
		public int BrandId { get; set; } //FK
		//[InverseProperty("Products")]
		public string Category { get; set; } //Navigation Properity
		public int CategoryId { get; set; } //FK
	}
}
