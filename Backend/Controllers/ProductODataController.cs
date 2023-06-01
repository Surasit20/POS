using AutoMapper;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Shared.Entity;
using Shared.ModelDTO;
using System.Net;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
	public class ProductODataController : ODataController
	{

		private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductODataController(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;

		}

        [EnableQuery(PageSize = 10)]
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
		public async Task<IActionResult> Post([FromBody] ProductDTO productDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
			Product product = _mapper.Map<Product>(productDto);
            _context.Products.Add(product);
			await _context.SaveChangesAsync();
			return Created(product);
            }catch (Exception ex)
			{
          
                Console.WriteLine(ex.Message);
                return Created(new Product());
            }

        }

		[HttpDelete]
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
        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] int key, [FromBody] Delta<Product> product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await _context.Products.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            product.Patch(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] Product update)
        {
     
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.ProductId)
            {
                return BadRequest();
            }
            _context.Entry(update).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        private bool ProductExists(int key)
        {
            return _context.Products.Any(p => p.ProductId == key);
        }

    }
}
