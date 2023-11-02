using CarServiceBL.IRepository;
using CarServiceBL.Models;
using CarServiceEF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianController : ControllerBase
    {

        public IBaseRepository<Technician> baseRepository;
        public TechnicianController(IBaseRepository<Technician> _baseRepository)
        {
            baseRepository = _baseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var technicians = baseRepository.GetAll();
            return Ok(technicians);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var technician = baseRepository.GetById(id);
            if (technician == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post( Technician technician)
        {
            baseRepository.Add(technician);

            return CreatedAtAction(nameof(Get), new { id = technician.TechnicianId }, technician);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,  Technician updatedTechnician)
        {
            var existingTechnician = baseRepository.GetById(id);

            if (existingTechnician == null)
            {
                return NotFound();
            }

            baseRepository.UPdate(id, updatedTechnician);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var technician = baseRepository.GetById(id);
            if (technician == null)
            {
                return NotFound();
            }

            baseRepository.Delete(id);

            return Ok();
        }
    }
}
