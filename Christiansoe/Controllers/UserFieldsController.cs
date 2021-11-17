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
    public class UserFieldsController : ControllerBase
    {
        private readonly ChristiansoeContext _context;

        public UserFieldsController(ChristiansoeContext context)
        {
            _context = context;
        }

        // GET: api/Fields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserFieldViewModel>>> GetUserFields([FromQuery(Name = "userBingoBoardId")] int UserBingoBoardId)
        {

            List<UserFieldViewModel> fields = _context.UserBingoBoard
                .Where(b => b.Id == UserBingoBoardId)
                .SelectMany(b => b.Fields, (b, f) => new UserFieldViewModel
                    {
                        Id = f.Id,
                        Name = f.Field.Name,
                        Description = f.Field.Description,
                        PictureUrl = f.Field.PictureUrl,
                        SoundUrl = f.Field.SoundUrl,
                        VideoUrl = f.Field.VideoUrl,
                        UserId = f.UserId,
                        IsMarked = f.IsMarked,
                        Position = f.Position,
                    })
                .OrderBy(userField => userField.Position )
                .ToList();
            return fields;
        }

        // PUT: api/Fields/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutField(int id, UserField @userField)
        {
            if (id != @userField.Id)
            {
                return BadRequest();
            }

            _context.Entry(@userField).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserFieldExists(id))
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

        private bool UserFieldExists(int id)
        {
            return _context.UserField.Any(e => e.Id == id);
        }
    }
}
