using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TrilloBackend.Controllers
{

    [Route("api/hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly TrilloContext _context;

        public HotelsController(TrilloContext context)
        {
            _context = context;
        }

        // GET: api/hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return await _context.Hotels
                .Include(e => e.Reviews)
                .Include(e => e.Bookings)
                .ToListAsync();
        }

        // GET: api/hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(long id)
        {
            var hotel = await _context.Hotels
                .Include(e => e.Reviews)
                .Include(e => e.Bookings)
                .FirstOrDefaultAsync(e => e.HotelId == id)
               ;

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }


        // PUT: api/hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.HotelId)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHotel), new { id = hotel.HotelId }, hotel);
        }

        // PostGET: api/hotels/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelSearch(string? name, string? address)
        {
            // check Name and Address record
            var hotelQuery = _context.Hotels
                .Include(e => e.Reviews)
                .Include(e => e.Bookings)
                .AsQueryable();

            // name && address
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(address))
            {   
                var result = await hotelQuery
                    .Where(e => EF.Functions.Like(e.Name, $"%{name}%") && EF.Functions.Like(e.Address, $"%{address}%"))
                    .ToListAsync();
                return result;
            }

            // check name without address
            if (!string.IsNullOrEmpty(name))
            {
                var result = await hotelQuery
                    .Where(e => EF.Functions.Like(e.Name, $"%{name}%"))
                    .ToListAsync();
                if (result.Any())
                    return result;
            }

            // chenck address without name
            if (!string.IsNullOrEmpty(address))
            {
                var result = await hotelQuery
                    .Where(e => EF.Functions.Like(e.Address, $"%{address}%"))
                    .ToListAsync();
                if (result.Any())
                    return result;
            }

            // return []
            return new List<Hotel>();
        }

        // DELETE: api/hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.HotelId == id);
        }
    }
}
