using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Christiansoe.Data;
using Christiansoe.Models;
using Christiansoe.ViewModels;

namespace Christiansoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly ChristiansoeContext _context;

        public RoutesController(ChristiansoeContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteViewModel>>> GetRoute([FromQuery(Name = "themeId")] int? themeId, [FromQuery(Name = "name")] string? name)
        {
            List<RouteViewModel> routes;
            if(themeId != null){
                routes = _context.Theme.Where(t => t.Id == themeId).SelectMany(t => t.Routes, (t, r) => new RouteViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Length = r.Length,
                    HikingTime = r.HikingTime,
                    Description = r.Description,
                    BingoBoardId = r.BingoBoard.Id,
                }).ToList();
            }
            else if(name != null){
                routes = _context.Route.Where(r => r.Name.Equals(name)).Select(r => new RouteViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Length = r.Length,
                    HikingTime = r.HikingTime,
                    Description = r.Description,
                    BingoBoardId = r.BingoBoard.Id,
                }).ToList();
            }
            else {
                routes = _context.Route.Select(r => new RouteViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Length = r.Length,
                    HikingTime = r.HikingTime,
                    Description = r.Description,
                    BingoBoardId = r.BingoBoard.Id,
                }).ToList();
            }
            return routes;
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Route>> GetRouteById(int id)
        {
            var route = await _context.Route.FindAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            return route;
        }

        // PUT: api/Routes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoute(int id, Route route)
        {
            if (id != route.Id)
            {
                return BadRequest();
            }

            _context.Entry(route).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Routes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Route>> PostRoute(Route route, [FromQuery(Name = "themeId")] int themeId)
        {

            var theme = _context.Theme.Include(t => t.Routes).FirstOrDefault(x => x.Id == themeId);

            theme.Routes.Add(route);

            _context.Entry(theme).State = EntityState.Modified;

            await _context.SaveChangesAsync();


            return Ok();
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var route = await _context.Route.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }

            _context.Route.Remove(route);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RouteExists(int id)
        {
            return _context.Route.Any(e => e.Id == id);
        }
    }
}
