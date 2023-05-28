using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Backend.Controllers
{

    public class OrderODataController : ControllerBase
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
            return Ok(_context.Products.AsQueryable());
        }
    }
}
