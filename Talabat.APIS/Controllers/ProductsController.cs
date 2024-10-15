using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.DTOs;
using Talabat.APIS.Errors;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Repositories.Contract;
using Talabat.Core_DomainLayer_.Specifications.ProductSpacification;

namespace Talabat.APIS.Controllers
{
	public class ProductsController : BasicApiController
	{
		private readonly IGenericRepository<Product> _productRepository;
		private readonly IGenericRepository<ProductBrand> _brandRepository;
		private readonly IGenericRepository<ProductCategory> _categoryRepository;
		private readonly IMapper _mapper;

		public ProductsController(IGenericRepository<Product> productRepository 
			,IGenericRepository<ProductBrand> brandRepository
			,IGenericRepository<ProductCategory> categoryRepository
			,IMapper mapper)
        {
			_productRepository = productRepository;
			_brandRepository = brandRepository;
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		//BaseUrl/api/Products
		[HttpGet]
		//public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		//{
		//	var products = await _productRepository.GetAllAsync();
  //          if (products == null)
  //          {
		//		return NotFound();
  //          }
  //          return Ok(products); //200
		//}

		public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		{
			var specification = new ProductWithBrandAndCategorySpecifications();
			var products = await _productRepository.GetAllWithSpecificationAsync(specification);
			var mapped = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
            if (products == null)
            {
				return NotFound(new ApiResponse(404));
            }
            return Ok(mapped); //200
		}

		//to show the display of ok and error in swagger to front end 
		[ProducesResponseType(typeof(ProductDto) ,StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse) ,StatusCodes.Status404NotFound)]
		[HttpGet("{id}")]
		//public async Task<ActionResult<Product>> GetProduct(int id)
		//{
		//	var product = await _productRepository.GetAsync(id);
		//	if (product == null)
		//	{
		//		return NotFound(new { Message = "Not Found", StatusCode = 404 }); //404
		//	}
		//	return Ok(product);
		//}

		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var specification = new ProductWithBrandAndCategorySpecifications(id);
			var products = await _productRepository.GetWithSpecificationAsync(specification);
            if (products == null)
            {
				return NotFound(new ApiResponse(404));
            }
			return Ok(_mapper.Map<Product,ProductDto>(products));
        }

		[HttpGet("brands")]
		public async Task<ActionResult<IEnumerable<ProductBrand>>> GetBrand()
		{
			var brands = await _brandRepository.GetAllAsync();
            if (brands == null)
            {
				return NotFound(new ApiResponse(404));
            }
			return Ok(brands);
        }

		[HttpGet("category")]
		public async Task<ActionResult<IEnumerable<ProductCategory>>> GetCategory()
		{
			var categories = await _categoryRepository.GetAllAsync();
            if (categories == null)
            {
				return NotFound(new ApiResponse(404));
            }
			return Ok(categories);
        }
    }
}
