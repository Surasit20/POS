using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Shared.Entity;
using System.Net;

namespace Backend.Controllers
{

	public class OrderODataController : ODataController
	{

		private readonly DataContext _context;
		//private readonly IMapper _mapper;
		public OrderODataController(DataContext context)
		{
			_context = context;
			// _mapper = mapper;

		}

		[EnableQuery]
		public IActionResult Get()
		{
			return Ok(_context.Orders.AsQueryable());
		}


		[EnableQuery]
		public SingleResult<Order> Get([FromODataUri] int key)
		{
			IQueryable<Order> result = _context.Orders.Where(o => o.OrderId == key);
			return SingleResult.Create(result);
		}

		[EnableQuery]
		public SingleResult<Supplier> GetSupplier([FromODataUri] int key)
		{
			var result = _context.Orders.Where(o => o.OrderId == key).Select(o => o.Supplier);
			return SingleResult.Create(result);
		}

	}
}
