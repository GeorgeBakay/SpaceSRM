using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSpaceSRM.Models;

namespace RestSpaceSRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpaceController : ControllerBase
    {
        DataContext db;
        public SpaceController(DataContext db)
        {
            this.db = db;

        }
        [HttpPost]
        public async Task<ActionResult> AddService(Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }
            db.services.Add(
                new Service {
                    Name= service.Name,
                    Price = service.Price,
                    Procent = service.Procent,
                    Type = service.Type,
                }
                );
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> AddServices(List<Service> services)
        {
            if(services == null)
            {
                return BadRequest();
            }

            db.services.AddRange(services);
            await db.SaveChangesAsync();

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<Service>>> GetServices()
        {
            List<Service> services = db.services.ToList();
            return Ok(services);
        }


    }
}
