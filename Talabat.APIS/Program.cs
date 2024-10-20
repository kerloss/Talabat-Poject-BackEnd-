
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Talabat.APIS.Errors;
using Talabat.APIS.Extenstions;
using Talabat.APIS.Helpers;
using Talabat.APIS.MiddleWare;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Enitities_Models_.Identity;
using Talabat.Core_DomainLayer_.Repositories.Contract;
using Talabat.Repository;
using Talabat.Repository.Data;
using Talabat.Repository.Data.Identity;

namespace Talabat.APIS
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			#region Dependancy injection for controller
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			//builder.Services.AddScoped<StoreContext>();
			//OR
			builder.Services.AddDbContext<StoreContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});
			builder.Services.AddDbContext<AppIdentityDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
			});
			builder.Services.AddSingleton<IConnectionMultiplexer>((serviceProvider) =>
			{
				var connection = builder.Configuration.GetConnectionString("Redis");
				return ConnectionMultiplexer.Connect(connection);
			});

			//ApplicationServicesExtenstions.AddApplicationServices(builder.Services);
			builder.Services.AddApplicationServices(); //Extenstion method
			builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
			{
				//options.Password.RequiredUniqueChars = 2;
				//options.Password.RequireDigit = true;
			}).AddEntityFrameworkStores<AppIdentityDbContext>();
			#endregion

			var app = builder.Build();

			//for update DataBase
			//Ask CLR Explicitly for creating object from storeContext
			//var scope = app.Services.CreateScope(); //Add Scope
			//try
			//{
			//	var service = scope.ServiceProvider;
			//	var _dbContext = service.GetRequiredService<StoreContext>();

			//	await _dbContext.Database.MigrateAsync();
			//}
			//finally
			//{
			//	scope.Dispose();
			//}

			//OR can use using prefer of try finally

			using var scope = app.Services.CreateScope(); //Add scope
			var service = scope.ServiceProvider;

			var _dbContext = service.GetRequiredService<StoreContext>(); //Explicitly
			var _identityDbContext = service.GetRequiredService<AppIdentityDbContext>();
			var _userManager = service.GetRequiredService<UserManager<AppUser>>();

			var loggerFactory = service.GetRequiredService<ILoggerFactory>();
			try
			{
				await _dbContext.Database.MigrateAsync(); //Update DataBase
				await StoreContextSeeding.SeedAsync(_dbContext); //Data Seeding
				await _identityDbContext.Database.MigrateAsync(); //Update Identity DataBase
				await AppIdentityDbContextSeeding.SeedUserAsync(_userManager); //Data Seeding

			}
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<Program>();
				logger.LogError(ex, "An Error occured during Migration");
			}

			#region MiddleWare

			// Configure the HTTP request pipeline(Middle Ware).
			app.UseMiddleware<ExceptionMiddleWare>();
			if (app.Environment.IsDevelopment())
			{
				app.UseSwaggerMiddleWare();
			}

			//redirect to endpoint named /errors when page not found
			app.UseStatusCodePagesWithReExecute("/Errors/{0}"); 
			app.UseHttpsRedirection();

			app.UseAuthorization();
			app.UseStaticFiles();

			app.MapControllers();
			#endregion

			app.Run();
		}
	}
}
