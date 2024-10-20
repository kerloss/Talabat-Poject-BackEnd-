using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.DTOs;
using Talabat.APIS.Errors;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Repositories.Contract;

namespace Talabat.APIS.Controllers
{
	public class BasketController : BasicApiController
	{
		private readonly IBasketRepository _basketRepository;
		private readonly IMapper _mapper;

		public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
			_basketRepository = basketRepository;
			_mapper = mapper;
		}

		[HttpGet("{id}")] //GET   : api/Basket/id
		public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
		{
			var basket = await _basketRepository.GetBasketAsync(id);
			return Ok(basket ?? new CustomerBasket(id));
		}

		[HttpPost] //POST : api/Basket
		public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
		{
			//mapping from [customerBasketDto] to model [customerBasket]
			var mappedBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
			var createdOrUpdatedBasekt =await _basketRepository.UpdateBasketAsync(mappedBasket);
			if (createdOrUpdatedBasekt is null) return BadRequest(new ApiResponse(400));
			return Ok(createdOrUpdatedBasekt);
		}

		[HttpDelete]  //DELETE : api/Basket
		public async Task DeleteBasket(string id)
		{
			await _basketRepository.DeleteBasketAsync(id);
		}
	}
}
