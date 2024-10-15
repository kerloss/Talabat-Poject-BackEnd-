using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.Errors;
using Talabat.Repository.Data;

namespace Talabat.APIS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BuggyController : ControllerBase
	{
		private readonly StoreContext _dbContext;

		public BuggyController(StoreContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet("notfound")] //GET : api/Buggy/notfound
		public ActionResult GetNotFoundRequest()
		{
			var product = _dbContext.Products.Find(100);
			if(product == null)
			{
				return NotFound(new ApiResponse(404));
			}
			return Ok(product);
		}

		[HttpGet("servererror")] //GET : api/Buggy/servererror
		public ActionResult GetServerError()
		{
			var product = _dbContext.Products.Find(100);
			var productDto = product.ToString(); //Throw null reference exception
			return Ok(productDto);
		}

		[HttpGet("badrequest")] //GET : api/Buggy/badrequest
		public ActionResult GetBadRequest()
		{
			return BadRequest(new ApiResponse(400));
		}

		[HttpGet("unauthorized")] //GET : api/Buggy/unauthorized
		public ActionResult GetUnAuthorized()
		{
			return Unauthorized(new ApiResponse(401));
		}

		[HttpGet("badrequest/{id}")] //GET : api/Buggy/badrequest/five
		public ActionResult GetBadRequest(int id)
		{
			return Ok();
		}
	}
}
