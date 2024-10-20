using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.DTOs;
using Talabat.APIS.Errors;
using Talabat.Core_DomainLayer_.Enitities_Models_.Identity;

namespace Talabat.APIS.Controllers
{
	public class AccountController : BasicApiController
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpPost("login")] //Post : /api/Account/login
		public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
		{
			var user = await _userManager.FindByEmailAsync(loginDto.Email);
			if (user == null) return Unauthorized(new ApiResponse(401));

			var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
			if (result.Succeeded is false) return Unauthorized(new ApiResponse(401));
			return Ok(new UserDto()
			{
				DisplayName = user.DisplayName,
				Email = user.Email,
				Token = "This will be token"
			});
		}

		[HttpPost("register")] //Post : /api/Account/register
		public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto) 
		{
			// create user
			var user = new AppUser()
			{
				DisplayName = registerDto.DisplayName,
				Email = registerDto.Email,
				UserName = registerDto.Email.Split("@")[0],
				PhoneNumber = registerDto.PhoneNumber,
			};

			//createAsync
			var result = await _userManager.CreateAsync(user, registerDto.Password);

			//return Ok(UserDto)
			if (result.Succeeded is false) return BadRequest(new ApiResponse(400));
			return Ok(new UserDto()
			{
				DisplayName = user.DisplayName,
				Email = user.Email,
				Token = "this will be token"
			});
		}
	}
}
