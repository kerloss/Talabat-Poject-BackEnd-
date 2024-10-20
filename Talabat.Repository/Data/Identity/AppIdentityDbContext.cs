using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_.Identity;

namespace Talabat.Repository.Data.Identity
{
	public class AppIdentityDbContext : IdentityDbContext<AppUser>
	{
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
		{
            
        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//Fluient API
			base.OnModelCreating(builder);

			builder.Entity<Address>().ToTable("Addresses");
		}
	}
}
