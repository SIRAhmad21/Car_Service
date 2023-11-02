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
    public class ProdectController : ControllerBase
    {
        public IBaseRepository<Prodect> prorepo;
      
        public ProdectController(IBaseRepository<Prodect> _prorepo)
        {
            prorepo = _prorepo;
           
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = prorepo.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = prorepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(Prodect product)
        {
            prorepo.Add(product);

            return CreatedAtAction(nameof(Get), new { id = product.ProdectId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Prodect updatedProduct)
        {
            var existingProduct = prorepo.GetById(id);

            if (existingProduct == null)
            {
                return NotFound();
            }
            prorepo.UPdate(id,updatedProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = prorepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            prorepo.Delete(id);

            return Ok();
        }
    }
}
