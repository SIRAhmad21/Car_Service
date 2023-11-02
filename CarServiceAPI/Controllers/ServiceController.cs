using CarServiceBL.IRepository;
using CarServiceBL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        public IBaseRepository<Service> baseRepository;
        public ServiceController(IBaseRepository<Service> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var services = baseRepository.GetAll();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var service = baseRepository.GetById(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPost]
        public IActionResult Post( Service service)
        {
            baseRepository.Add(service);

            return CreatedAtAction(nameof(Get), new { id = service.ServiceId }, service);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Service updatedService)
        {
            var existingService = baseRepository.GetById(id);

            if (existingService == null)
            {
                return NotFound();
            }

            baseRepository.UPdate(id, updatedService);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var service = baseRepository.GetById(id);
            if (service == null)
            {
                return NotFound();
            }

            baseRepository.Delete(id); 

            return Ok();
        }


    }
}
