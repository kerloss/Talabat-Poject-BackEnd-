using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core_DomainLayer_.Enitities_Models_;

namespace Talabat.Core_DomainLayer_.Repositories.Contract
{
	public interface IBasketRepository
	{
		Task<CustomerBasket?> GetBasketAsync(string basketId);
		Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket); //Add & update
		Task<bool> DeleteBasketAsync(string basketId);
	}
}
