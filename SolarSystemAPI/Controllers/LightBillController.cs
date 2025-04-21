using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarSystemAPI.Model;

namespace SolarSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LightBillController : ControllerBase
    {
        private readonly IDynamoDBContext _context;

        public LightBillController(IDynamoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lightBills = await _context.ScanAsync<LightBills>(default).GetRemainingAsync();
            return Ok(lightBills);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LightBills request)
        {
            var lightBills = await _context.LoadAsync<LightBills>(request.Id);
            if (lightBills != null) return BadRequest($"LightBills with Id {request.Id} Already Exists");
            await _context.SaveAsync(request);
            return Ok(request);
        }

        [HttpDelete("{id}/{subid}")]
        public async Task<IActionResult> Delete(Int32 id, Int32 subid)
        {
            var lightBills = await _context.LoadAsync<LightBills>(id, subid);
            if (lightBills == null) return NotFound();
            await _context.DeleteAsync(lightBills);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(LightBills request)
        {
            var lightBills = await _context.LoadAsync<LightBills>(request.Id, request.SubId);
            if (lightBills == null) return NotFound();
            await _context.SaveAsync(request);
            return Ok(request);
        }
    }
}
