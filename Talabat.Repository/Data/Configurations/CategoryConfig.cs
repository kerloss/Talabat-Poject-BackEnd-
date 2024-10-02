﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;

namespace Talabat.Repository.Data.Configurations
{
	public class CategoryConfig : IEntityTypeConfiguration<ProductCategory>
	{
		public void Configure(EntityTypeBuilder<ProductCategory> builder)
		{
			builder.Property(C => C.Name).IsRequired();
		}
	}
}
