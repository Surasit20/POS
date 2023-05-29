using Backend.Data;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Shared.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddOData(options =>
	options.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100)
	.AddRouteComponents("odata", GetEdmModel()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
	//options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();


static IEdmModel GetEdmModel()
{
	ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
	modelBuilder.EntitySet<Product>("ProductOData");
	modelBuilder.EntitySet<Order>("OrderOData");

	modelBuilder.Namespace = "ProductService";
	modelBuilder.EntityType<Product>().Collection
	.Function("MostExpensive")
	.Returns<decimal>();


	//modelBuilder.EntitySet<OrderItem>("OrderOData");
	//modelBuilder.EntitySet<Supplier>("OrderOData");
	//modelBuilder.EntitySet<Purchaser>("OrderOData");
	return modelBuilder.GetEdmModel();
}