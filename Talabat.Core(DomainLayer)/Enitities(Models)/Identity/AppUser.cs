using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core_DomainLayer_.Enitities_Models_.Identity
{
	public class AppUser : IdentityUser
	{
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}
