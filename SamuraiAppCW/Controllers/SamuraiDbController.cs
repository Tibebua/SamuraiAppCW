using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamuraiAppCW.Data;
using SamuraiAppCW.Models;
using SamuraiAppCW.Models.Entities;
using SamuraiAppCW.Models.ViewModels;

namespace SamuraiAppCW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraiDbController : ControllerBase
    {
        private readonly SamuraiContext _samuraiContext;

        public SamuraiDbController(SamuraiContext samuraiContext)
        {
            _samuraiContext = samuraiContext;
        }

        [HttpGet("GetAllSamurais", Name = "GetAllSamurais")]
        public async Task<ActionResult<List<Samurai>>> GetSamurais()
        {
            var samurais = await _samuraiContext.Samurais.Include(s => s.Quotes).ToListAsync();
            if (samurais == null)
            {
                return NotFound();
            }
            return Ok(samurais);
        }

        [HttpGet("GetSamurai/{id}", Name = "GetSamurai")]
        public async Task<ActionResult<Samurai>> GetSamurai(int id)
        {
            var samurai = await _samuraiContext.Samurais.Include(s => s.Quotes).Where(s => s.Id == id).FirstOrDefaultAsync();
            if (samurai == null)
            {
                return NotFound();
            }
            return Ok(samurai);
        }

        [HttpPost("AddSamurai")]
        public async Task<ActionResult<Samurai>> CreateSamurai([FromBody] Samurai samurai)
        {
            var obj = await _samuraiContext.Samurais.AddAsync(samurai);
            _samuraiContext.SaveChanges();
            return CreatedAtRoute(nameof(GetSamurai), new { id = samurai.Id }, obj.Entity); // here u can pass the "samurai" too
        }

        [HttpPost("AddSamurais")]
        public async Task<ActionResult<List<Samurai>>> CreateSamurais([FromBody] List<Samurai> samurais)
        {
            await _samuraiContext.Samurais.AddRangeAsync(samurais);
            _samuraiContext.SaveChanges();
            return Ok();
        }

        //BATTLE
        [HttpGet("GetSamuraiWithBattlesViaSelect/{samuraiId}", Name = "GetSamuraiWithBattlesViaSelect")]
        public async Task<ActionResult> GetSamuraiWithBattlesViaSelect(int samuraiId)
        {
            //var samuraiWithBattles = await _samuraiContext.Samurais.Include(s => s.SamuraiBattles)
            //    .ThenInclude(sb => sb.Battle).Where(s => s.Id == samuraiId).FirstOrDefaultAsync();
            var samuraiWithBattles = _samuraiContext.Samurais.Where(s => s.Id == samuraiId).Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                Quotes = s.Quotes.Select(q => new { q.QuoteId, q.Text }).ToList(),
                Battles = s.SamuraiBattles.Select(s => s.Battle).Select(b => new { b.BattleId, b.Name, b.StartDate, b.EndDate }).ToList()
            });
            return Ok(samuraiWithBattles);
        }

        [HttpGet("GetSamuraiWithBattlesViaEntity/{samuraiId}", Name = "GetSamuraiWithBattlesViaEntity")]
        public async Task<ActionResult<SamuraiEntity>> GetSamuraiWithBattlesViaEntity(int samuraiId)
        {
            var samuraiWithBattles = await _samuraiContext.Samurais.Include(s => s.Quotes).Include(s => s.SamuraiBattles)
                .ThenInclude(sb => sb.Battle).Where(s => s.Id == samuraiId).FirstOrDefaultAsync();
            var samuraiWithBattleEntity = new SamuraiEntity(samuraiWithBattles);
            return samuraiWithBattleEntity;
        }

        [HttpGet("GetAllSamuraiWithBattlesViaSelect", Name = "GetAllSamuraiWithBattlesViaSelect")]
        public async Task<ActionResult> GetAllSamuraiWithBattlesViaSelect()
        {
            var samuraiWithBattles = _samuraiContext.Samurais.Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                Quotes = s.Quotes.Select(q => new { q.QuoteId, q.Text }).ToList(),
                Battles = s.SamuraiBattles.Select(s => s.Battle).Select(b => new { b.BattleId, b.Name, b.StartDate, b.EndDate }).ToList()
            });
            return Ok(samuraiWithBattles);
        }


        [HttpPost("AddBattle")]
        public async Task<ActionResult<Battle>> CreateBattle([FromBody] Battle battle)
        {
            var obj = await _samuraiContext.Battles.AddAsync(battle);
            _samuraiContext.SaveChanges();            
            return CreatedAtRoute("GetBattle", new { id = battle.BattleId }, battle);
        }

        [HttpGet("GetBattle/{id}", Name = "GetBattle")]
        public async Task<ActionResult<Battle>> GetBattle(int id)
        {
            var battle = await _samuraiContext.Battles.FirstOrDefaultAsync(b => b.BattleId == id);
            return battle;
        }
    }
}
