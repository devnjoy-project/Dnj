
using Dnj.Samples.UnitOfWork.Server.Services;
using Dnj.Samples.UnitOfWork.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dnj.Samples.UnitOfWork.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfWorkController : ControllerBase
    {
        private readonly UnitOfWorkService _service;
        public UnitOfWorkController(UnitOfWorkService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var service = await _service.Get();
            return Ok(service);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var service = await _service.Get(id);
            return Ok(service);
        }
        [HttpPost]
        public async Task<IActionResult> Post(UnitOfWorkDto unitOfWork)
        {
            if (!ModelState.IsValid) return NoContent();
            var service = await _service.Post(unitOfWork);
            
            return Ok(service); 
        }
        [HttpPut]
        public async Task<IActionResult> Put(UnitOfWorkDto unitOfWork)
        {
            await _service.Put(unitOfWork);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
