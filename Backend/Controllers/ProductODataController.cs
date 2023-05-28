using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{

	public class ProductODataController : ControllerBase
	{

		private readonly DataContext _context;
		public ProductODataController(DataContext context)
		{
			_context = context;
			// _mapper = mapper;

		}

		[EnableQuery]
		public IActionResult Get()
		{
			return Ok(_context.Products.AsQueryable());
		}


	}
}
