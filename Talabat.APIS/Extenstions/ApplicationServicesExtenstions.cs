using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.Errors;
using Talabat.APIS.Helpers;
using Talabat.Core_DomainLayer_.Repositories.Contract;
using Talabat.Repository;

namespace Talabat.APIS.Extenstions
{
	//to make class as extenstion method we need to make it static class and put this
	public static class ApplicationServicesExtenstions
	{
		//services carry => builder.Services
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			//builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
			//builder.Services.AddScoped<IGenericRepository<ProductBrand>, GenericRepository<ProductBrand>>();
			//builder.Services.AddScoped<IGenericRepository<ProductCategory>, GenericRepository<ProductCategory>>();
			//OR
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddAutoMapper(typeof(MappingProfile));
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = (actioncontext) =>
				{
					var errors = actioncontext.ModelState.Where(P => P.Value.Errors.Count() > 0)
														 .SelectMany(P => P.Value.Errors)
														 .Select(P => P.ErrorMessage)
														 .ToList();

					var response = new ApiValidatoinErrorResponse()
					{
						Errors = errors
					};
					return new BadRequestObjectResult(response);
				};
			});
			return services;
		}

		public static WebApplication UseSwaggerMiddleWare(this WebApplication app)
		{
			app.UseSwagger();
			app.UseSwaggerUI();

			return app;
		}
	}
}
