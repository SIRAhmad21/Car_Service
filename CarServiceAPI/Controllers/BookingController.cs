using CarServiceBL.IRepository;
using CarServiceBL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
   
        public IBaseRepository<Booking> baseRepository;
        public BookingController(IBaseRepository<Booking> _baseRepository)
        {
            baseRepository = _baseRepository;
        }

       

            [HttpGet]
            public IActionResult Get()
            {
                var bookings = baseRepository.GetAll();
                return Ok(bookings);
            }

            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var booking = baseRepository.GetById(id);
                if (booking == null)
                {
                    return NotFound();
                }
                return Ok(booking);
            }

            [HttpPost]
            public IActionResult Post([FromBody] Booking booking)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                baseRepository.Add(booking);
              

                return CreatedAtAction(nameof(Get), new { id = booking.BookingId }, booking);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] Booking updatedBooking)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingBooking = baseRepository.GetById(id);

                if (existingBooking == null)
                {
                    return NotFound();
                }

            
           
            baseRepository.UPdate(id,updatedBooking);

              

                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var booking = baseRepository.GetById(id);
                if (booking == null)
                {
                    return NotFound();
                }

             baseRepository.Delete(id);


                return NoContent();
            }
        }

    }

