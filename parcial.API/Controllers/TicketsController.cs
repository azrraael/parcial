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
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (ticket is null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Ticket ticket)
        {
            _context.Update(ticket);
            try
            {

                await _context.SaveChangesAsync();
                return Ok(ticket);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

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

