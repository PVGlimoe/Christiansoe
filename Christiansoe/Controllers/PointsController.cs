using Christiansoe.Data;
using Christiansoe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Christiansoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly ChristiansoeContext _context;

        public PointsController(ChristiansoeContext context)
        {
            _context = context;
        }


    // Get: api/Points
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Point>>> GetPoint()
        {
            return await _context.Point.ToListAsync();
        }

    // POST: api/Points
    [HttpPost]
        public async Task<ActionResult<Point>> PostPoint(List<Point> points, [FromQuery(Name = "mapId")] int mapId)
        {
            //Creates an object of the requested map from the database, based on the query on the mapId
            var map = await _context.Map.FindAsync(mapId);
            //Sets the points list from the map to the posted Json file
            map.Points = points;
            //Tells the database that the state has changed
            _context.Entry(map).State = EntityState.Modified;
            //Posts it
            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}
