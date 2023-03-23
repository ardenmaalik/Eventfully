using Eventfully.Domain.Entities;
using Eventfully.Domain.Entities.DTOs;
using Eventfully.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Eventfully.WebUI.Controllers
{
    [Route("api/[controller]")] // api/event
    [ApiController]
    public class EventController : ControllerBase
    {
       
        public static AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetEvents")]

        public async Task<IActionResult> Get()
        {
            var events = await _context.Events.ToListAsync();
            return Ok(events);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _context.Events.FirstOrDefaultAsync(x => x.EventId == id);

            if (result == null)
            {
                return BadRequest("Invalid Id");
            }

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Event postevent) 
        {

            await _context.Events.AddAsync(postevent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", postevent.EventId, postevent);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, [FromBody] EventDto eventDto)
        {
            var result = await _context.Events.FirstOrDefaultAsync(x => x.EventId == id);

            if (result == null)
            {
                return BadRequest("Invalid Id");
            }

            result.EventName = eventDto.EventName ?? result.EventName;
            result.EventType = eventDto.EventType ?? result.EventType;
            result.EventDescription = eventDto.EventDescription ?? result.EventDescription;
            result.Category = eventDto.Category ?? result.Category;
            result.Price = eventDto.Price != 0 ? eventDto.Price : result.Price;
            result.EventThumbnail = eventDto.EventThumbnail ?? result.EventThumbnail;
            result.EventBanner = eventDto.EventBanner ?? result.EventBanner;
            result.EventDate = eventDto.EventDate != default ? eventDto.EventDate : result.EventDate;
            result.EventTime = eventDto.EventTime ?? result.EventTime;

            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Events.FirstOrDefaultAsync(x => x.EventId == id);

            if (result == null)
            {
                return BadRequest("Invalid Id");
            }

            _context.Events.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

 
