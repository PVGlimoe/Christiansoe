using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Christiansoe.Data;
using Christiansoe.Models;
using Christiansoe.DTO;
using Christiansoe.Service;
using Christiansoe.ViewModels;

namespace Christiansoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBingoBoardController : ControllerBase
    {
        private readonly ChristiansoeContext _context;

        public UserBingoBoardController(ChristiansoeContext context)
        {
            _context = context;
        }

        // GET: api/UserBingoBoards
        [HttpGet]
        public async Task<ActionResult<UserBingoBoardViewModel>> GetUserBingoBoard(
                [FromQuery(Name = "BingoBoardId")] int BingoBoardId,
                [FromQuery(Name = "UserId")] string UserId
            )
        {
            UserBingoBoardViewModel userBingoBoard = _context.UserBingoBoard
                .Where(
                    b => b.BingoBoard.Id == BingoBoardId 
                    && b.UserId == UserId 
                    && !b.Done
                )
                .Include(b => b.BingoBoard)
                .Select(b => new UserBingoBoardViewModel
                    {
                        Id = b.Id,
                        Name = b.BingoBoard.Name,
                        Map = b.BingoBoard.Map != null? new MapViewModel
                        {
                            Id = b.BingoBoard.Map.Id,
                            Name = b.BingoBoard.Map.Name,
                            Url = b.BingoBoard.Map.Url
                        }:null,
                        Done = b.Done,
                        UserId = b.UserId
                    })
                .FirstOrDefault();

            if (userBingoBoard == null){
                // create bingoboard
                return NotFound();
            }
            return userBingoBoard;
        }

        // POST: api/UserBingoBoards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserBingoBoardViewModel>> UserBingoBoard(UserBingoBoardDTO userBingoBoardDTO)
        {
            var userId = userBingoBoardDTO.UserId;
            var bingoboardId = userBingoBoardDTO.BingoBoardId;

            BingoBoard bingoboard = _context.BingoBoard.Include(b => b.Fields).FirstOrDefault(b => b.Id == bingoboardId);

            if(bingoboard == null){
                return BadRequest();
            }

            var userFields = new List<UserField>();
            Random rng = new Random();
            int month = DateTime.Now.Month;
            int position = 1;
            var fields = bingoboard.Fields.FindAll(f => DateService.monthBetween(f.StartMonth, f.EndMonth, month)).OrderBy(f => rng.Next()).ToList().GetRange(0, 9);
            foreach( Field field in fields){
                UserField userField = new UserField();
                userField.UserId = userId;
                userField.Position = position;
                userField.Field = field;

                userFields.Add(userField);

                position++;
            }

            var userBingoBoard = new UserBingoBoard();
            userBingoBoard.BingoBoard = bingoboard;
            userBingoBoard.UserId = userId;

            //Only selects the fields with the right start and end monts, and saves them in the field list
            userBingoBoard.Fields = userFields;

            _context.UserBingoBoard.Add(userBingoBoard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserBingoBoard", new { id = userBingoBoard.Id }, new UserBingoBoardViewModel
                {
                    Id = userBingoBoard.Id,
                    Name = userBingoBoard.BingoBoard.Name,
                    Map = userBingoBoard.BingoBoard.Map != null? new MapViewModel
                    {
                        Id = userBingoBoard.BingoBoard.Map.Id,
                        Name = userBingoBoard.BingoBoard.Map.Name,
                        Url = userBingoBoard.BingoBoard.Map.Url
                    }:null,
                    Done = userBingoBoard.Done,
                    UserId = userBingoBoard.UserId
                }
            );
        }

        // PUT: api/Fields/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBingoBoard(int id, UserBingoBoard @userBingoBoard)
        {
            if (id != @userBingoBoard.Id)
            {
                return BadRequest();
            }

            _context.Entry(@userBingoBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBingoBoardExists(id))
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

        private bool UserBingoBoardExists(int id)
        {
            return _context.UserBingoBoard.Any(e => e.Id == id);
        }
    }
}
