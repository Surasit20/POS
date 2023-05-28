using Microsoft.EntityFrameworkCore;
using Shared.Entity;

namespace Backend.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{


			modelBuilder.Entity<Product>()
		   .HasMany(e => e.OrderItem)
		   .WithOne(e => e.Product)
		   .HasForeignKey(e => e.ProductId)
		   .IsRequired();

			modelBuilder.Entity<Order>()
		   .HasMany(e => e.OrderItem)
		   .WithOne(e => e.Order)
		   .HasForeignKey(e => e.OrderId)
		   .IsRequired();

			modelBuilder.Entity<Supplier>()
		   .HasMany(e => e.Order)
		   .WithOne(e => e.Supplier)
		   .HasForeignKey(e => e.SupplierId)
		   .IsRequired();

			modelBuilder.Entity<Purchaser>()
			.HasMany(e => e.Order)
			.WithOne(e => e.Purchaser)
			.HasForeignKey(e => e.PurchaserId)
			.IsRequired();

			for (int i = 1; i < 200; i++)
			{
				string name = (new string[] { "คอมพิวเตอร์", "ตู้เย็น", "หมอน", "ผ้าห่ม", "เก้าอี้" })[new Random().Next(5)];
				string description = (new string[] { "You could use JSON.NET to serialize your clas", "ET Core OData is a .NET library for building REST API services that conform to the OData protocol. The OData protocol defines best practices for consistent and strongly-typed REST APIs by specifying the format of requests and responses, type definition, and serv",
					"metadata endpoint that returns a document describing the API service' model, the data types it defines and the endpoints and capabilities it exposes. This document makes it easier for clients to consume the service. It can also be used by",
					"as attribute routing.\r\nHandles serialization and deserialization of requests and responses\r\nValidation of requests and responses based on the types defined in the OData model\r\nSupport for batch requests, which ",
					"\r\nAbility to generate client code from OData model description\r\nExpose a REST API layer to your data source for analytics functions.\r\nAdd advanced querying capabilities via OData query options to your REST API even when it's not based on OD" })[new Random(i).Next(5)];

				decimal purchasePrice = (new decimal[] { 244, 145, 444, 54, 33 })[new Random().Next(5)];
				decimal sellingPrice = (new decimal[] { 244, 145, 444, 54, 33 })[new Random().Next(5)];
				string unit = (new string[] { "เครื่อง", "ชิ้น", "อัน", "แผ่น", "ด้าม" })[new Random().Next(5)];

				modelBuilder.Entity<Product>().HasData(
				 new Product { ProductId = i, Name = name, Description = description, ImageUrl = "", PurchasePrice = purchasePrice, SellingPrice = sellingPrice, Unit = unit }
				);

				string supplierName = (new string[] { "John", "Bob", "Tom", "Test", "Elon" })[new Random().Next(5)];

				modelBuilder.Entity<Supplier>().HasData(
				 new Supplier { SupplierId = i, Name = supplierName, Address = "......", OfficeName = "...", TaxID = "....", PostalCode = "...." }
				);

				modelBuilder.Entity<Purchaser>().HasData(
				 new Purchaser { PurchaserId = i, Name = supplierName, Address = "......", OfficeName = "...", TaxID = "....", PostalCode = "...." }
				);

			}

			int countOrderItemID = 1;
			for (int i = 1; i < 50; i++)
			{
				int purchaserId = (new int[] { 1, 2, 3, 4, 5 })[new Random().Next(5)];
				int totalPrice = (new int[] { 204, 3456, 20, 500, 23545 })[new Random().Next(5)];
				bool isDeleted = (new bool[] { true, true, false, true, true })[new Random().Next(5)];
				modelBuilder.Entity<Order>().HasData(
				 new Order
				 {
					 OrderId = i,
					 DateCreated = DateTime.Now,
					 DateDeleted = DateTime.Now,
					 DateUpdated = DateTime.Now,
					 Discount = purchaserId,
					 IsActive = true,
					 IsDeleted = isDeleted,
					 OrderDate = DateTime.Now,
					 Note = "",
					 PurchaserId = purchaserId,
					 TotalPrice = totalPrice,
					 Vat = 7,
					 Status = 0,
					 SupplierId = i,

				 }
				);

				for (int j = i; j < 20; j++)
				{
					int no = (new int[] { 1, 2, 3, 4, 5 })[new Random().Next(5)];
					int quantity = (new int[] { 20, 10, 5, 15, 43 })[new Random().Next(5)];
					int totalPriceOrderItem = (new int[] { 20, 36, 20, 10, 45 })[new Random().Next(5)];
					modelBuilder.Entity<OrderItem>().HasData(
					 new OrderItem
					 {
						 OrdertItemId = countOrderItemID,
						 OrderId = j,
						 TotalPrice = totalPriceOrderItem,
						 No = no,
						 ProductId = i,
						 PurchasePrice = 50,
						 SellingPrice = 100,
						 Quantity = quantity
					 }
					);
					countOrderItemID++;

				}

			}

		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<Purchaser> Purchaser { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }

	}
}
