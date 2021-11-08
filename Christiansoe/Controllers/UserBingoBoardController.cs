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
                .Select(b => new UserBingoBoardViewModel
                {
                    Id = b.Id,
                    Name = b.BingoBoard.Name,
                    Done = b.Done,
                    Map = new MapViewModel 
                    {
                        Id = b.BingoBoard.Map.Id,
                        Name = b.BingoBoard.Map.Name,
                        Url = b.BingoBoard.Map.Url
                    }
                })
                .First();
            return userBingoBoard;
        }

        // POST: api/UserBingoBoards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BingoBoard>> PostUserBingoBoard(BingoBoard bingoBoard)
        {
            _context.BingoBoard.Add(bingoBoard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBingoBoard", new { id = bingoBoard.Id }, bingoBoard);
        }
    }
}
