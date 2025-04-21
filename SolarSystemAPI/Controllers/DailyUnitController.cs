using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Mvc;
using SolarSystemAPI.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SolarSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyUnitController : ControllerBase
    {
        private readonly IDynamoDBContext _context;

        public DailyUnitController(IDynamoDBContext context)
        {
            _context = context;
        }

        [HttpGet]        
        public async Task<IActionResult> GetAll()
        {
            var dailyUnits = await _context.ScanAsync<DailyUnits>(default).GetRemainingAsync();
            return Ok(dailyUnits);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DailyUnits request)
        {
            var dailyUnits = await _context.LoadAsync<DailyUnits>(request.Id, request.SubId);
            if (dailyUnits != null) return BadRequest($"DailyUnits with Id {request.Id} and {request.SubId} Already Exists");
            await _context.SaveAsync(request);
            return Ok(request);
        }

        [HttpDelete("{id}/{subid}")]
        public async Task<IActionResult> Delete(Int32 id, Int32 subid)
        {
            var dailyUnits = await _context.LoadAsync<DailyUnits>(id, subid);
            if (dailyUnits == null) return NotFound();
            await _context.DeleteAsync(dailyUnits);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(DailyUnits request)
        {
            var dailyUnits = await _context.LoadAsync<DailyUnits>(request.Id, request.SubId);
            if (dailyUnits == null) return NotFound();
            await _context.SaveAsync(request);
            return Ok(request);
        }        
    }
}
