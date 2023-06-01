using AutoMapper;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.EntityFrameworkCore;
using Shared.Entity;
using Shared.ModelDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase

    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public OrderController(DataContext context, IMapper mapper)
        {
            _context = context;
             _mapper = mapper;

        }

        // GET: api/<OrderController>

        [EnableQuery]
        [HttpGet]
        public async Task<List<OrderDTO>> Get()
        {

            var data = await _context.Orders
                .Include(o=> o.Purchaser)
                .Include(o => o.Supplier)
                .Include(o => o.OrderItem)
                .ThenInclude(o=> o.Product)
                .ToListAsync();
            List<OrderDTO> orderDto = _mapper.Map<List<OrderDTO>>(data);
            return orderDto;
        }

		// GET api/<OrderController>/5
	

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
