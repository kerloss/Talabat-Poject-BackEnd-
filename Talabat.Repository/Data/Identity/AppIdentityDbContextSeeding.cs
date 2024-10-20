using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_.Identity;

namespace Talabat.Repository.Data.Identity
{
	public static class AppIdentityDbContextSeeding
	{
		public static async Task SeedUserAsync(UserManager<AppUser> _userManager)
		{
            if (_userManager.Users.Count() == 0)
            {
				var user = new AppUser()
				{
					DisplayName = "kerloss emeil",
					Email = "kerloss.emeil18@gmail.com",
					UserName = "kerloss.emeil",
					PhoneNumber = "01210810875"
				};
				await _userManager.CreateAsync(user, "P@$$w0rd");
            }
        }
	}
}
