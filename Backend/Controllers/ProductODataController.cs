using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Shared.Entity;
using System.Net;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
	public class ProductODataController : ODataController
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
        [EnableQuery]
        public SingleResult<Product> Get([FromODataUri] int key)
        {
            IQueryable<Product> result = _context.Products.Where(p => p.ProductId == key);
            return SingleResult.Create(result);
        }


        [HttpGet]
		public IActionResult MostExpensive()
		{
			var product = _context.Products.Max(x => x.PurchasePrice);
			return Ok(product);
		}

		[HttpPost]
		public async Task<IActionResult> Post(Product product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
			return Created(product);
		}

		[HttpPost]
		public async Task<IActionResult> Delete([FromODataUri] int key)
		{
			var product = await _context.Products.FindAsync(key);
			if (product == null)
			{
				return NotFound();
			}
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
			return NoContent();
		}

	}
}
