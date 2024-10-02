
using Microsoft.EntityFrameworkCore;
using Talabat.Core_DomainLayer_.Enitities_Models_;
using Talabat.Core_DomainLayer_.Repositories.Contract;
using Talabat.Repository;
using Talabat.Repository.Data;

namespace Talabat.APIS
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

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

			#region Dependancy injection for controller
			//builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
			//builder.Services.AddScoped<IGenericRepository<ProductBrand>, GenericRepository<ProductBrand>>();
			//builder.Services.AddScoped<IGenericRepository<ProductCategory>, GenericRepository<ProductCategory>>();
			//OR
			builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
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
			var _dbContext = service.GetRequiredService<StoreContext>();

			var loggerFactory = service.GetRequiredService<ILoggerFactory>();
			try
			{
				await _dbContext.Database.MigrateAsync(); //Update DataBase
				await StoreContextSeeding.SeedAsync(_dbContext); //Data Seeding
			}
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<Program>();
				logger.LogError(ex, "An Error occured during Migration");
			}

			// Configure the HTTP request pipeline(Middle Ware).
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
