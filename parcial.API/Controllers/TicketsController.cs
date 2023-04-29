using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parcial.API.Data;
using parcial.Shared.Entities;

namespace parcial.API.Controllers
{
    [ApiController]
    [Route("api/ticket")]
    public class TicketsController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Tickets.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ticket ticket)
        {
            _context.Add(ticket);
            await _context.SaveChangesAsync();
            return Ok(ticket);
        }
    }
}

