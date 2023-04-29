using parcial.Shared.Entities;

namespace parcial.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
    
            await _context.Database.EnsureCreatedAsync();
            await TicketAsync();
        }
        private async Task TicketAsync()
        {


                if (!_context.Tickets.Any())
                {
                    for (int n = 0; n < 50000; n++)
                    {
                        _context.Tickets.Add(new Ticket { Date = null, Used = false, Entrance = null });
                    }

                }


                  await _context.SaveChangesAsync();
        }
    }
}
