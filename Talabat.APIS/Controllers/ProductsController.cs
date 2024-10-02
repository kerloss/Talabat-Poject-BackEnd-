using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Repositories.Contract;

namespace Talabat.APIS.Controllers
{
	public class ProductsController : BasicApiController
	{
		private readonly IGenericRepository<Product> _productRepository;

		public ProductsController(IGenericRepository<Product> productRepository)
        {
			_productRepository = productRepository;
		}

		//BaseUrl/api/Products
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		{
			var products = await _productRepository.GetAllAsync();
            if (products == null)
            {
				return NotFound();
            }
            return Ok(products); //200
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var product = await _productRepository.GetAsync(id);
            if (product == null)
            {
				return NotFound(new { Message = "Not Found", StatusCode = 404 }); //404
            }
			return Ok(product);
        }
    }
}
