using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalogAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Catalog")]
    public class CatalogController : Controller
    {
        private readonly CatalogContext _catalogContext;
        private readonly IConfiguration _configuration;
        public CatalogController(CatalogContext catalogContext,
            IConfiguration configuration)
        {
            _catalogContext = catalogContext;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> CatalogTypes()
        {
            var items= await _catalogContext.CatalogTypes.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> CatalogLocations()
        {
            var items = await _catalogContext.CatalogLocations.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> CatalogDates()
        {
            var items = await _catalogContext.CatalogDates.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> Events(
        
           [FromQuery] int pageSize =6,
           [FromQuery] int pageIndex =0
        )
        {
            var totalEvents = await
                _catalogContext.CatalogEvents.LongCountAsync();

            var eventsOnPage = await _catalogContext.CatalogEvents
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            eventsOnPage = ChangeUrlPlaceholder(eventsOnPage);
            return Ok(eventsOnPage);
        }

        [HttpGet]
        [Route("events/{id:int}")]
        public async Task<IActionResult> GetEventsById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var catalogevent= await _catalogContext.CatalogEvents
                .SingleOrDefaultAsync(c => c.Id == id);

            if (catalogevent != null)
            {
                catalogevent.PictureUrl = catalogevent.PictureUrl
                .Replace("http://externalcatalogbaseurltobereplaced",
                _configuration["ExternalCatalogBaseUrl"]
                );
                return Ok(catalogevent);
            }
            return NotFound(); 
            }
        

        private List<CatalogEvent> ChangeUrlPlaceholder(
            List<CatalogEvent> events)
        {
        events.ForEach(
           x => x.PictureUrl = 
            x.PictureUrl
            .Replace("http://externalcatalogbaseurltobereplaced",
            _configuration["ExternalCatalogBaseUrl"]
            ));
          return events;
        }
}
}
