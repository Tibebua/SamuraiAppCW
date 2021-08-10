using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamuraiAppCW.Data;
using SamuraiAppCW.Models;
using SamuraiAppCW.Models.DTO;
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

        [HttpPost("AddQuote")]
        public async Task<ActionResult<Quote>> AddQuote([FromBody] Quote quote)
        {
            var obj = await _samuraiContext.Quotes.AddAsync(quote);
            _samuraiContext.SaveChanges();
            return quote;
        }

        //BATTLE
        [HttpGet("GetSamuraiWithBattlesViaSelect/{samuraiId}", Name = "GetSamuraiWithBattlesViaSelect")]
        public async Task<ActionResult<SamuraiEntity>> GetSamuraiWithBattlesViaSelect(int samuraiId)
        {
            //var samuraiWithBattles = _samuraiContext.Samurais.Where(s => s.Id == samuraiId).Select(s => new
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    Quotes = s.Quotes.Select(q => new { q.QuoteId, q.Text }),
            //    Battles = s.SamuraiBattles.Select(s => s.Battle).Select(b => new { b.BattleId, b.Name, b.StartDate, b.EndDate })
            //});

            var samuraiWithBattles = _samuraiContext.Samurais.Where(s => s.Id == samuraiId).Select(s => new SamuraiEntity
            {
                Id = s.Id,
                Name = s.Name,
                QuoteEntities = s.Quotes.Select(q => new QuoteEntity { QuoteId = q.QuoteId, Text = q.Text }),
                BattleEntities = s.SamuraiBattles.Select(sb => sb.Battle)
                .Select(b => new BattleEntity { BattleId = b.BattleId, Name = b.Name, StartDate = b.StartDate, EndDate = b.EndDate })
            });


            return Ok(samuraiWithBattles);
        }

        [HttpGet("GetSamuraiWithBattlesViaInclude/{samuraiId}", Name = "GetSamuraiWithBattlesViaInclude")]
        public async Task<ActionResult<SamuraiEntity>> GetSamuraiWithBattlesViaInclude(int samuraiId)
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

        [HttpGet("GetBattleAndInvolvedSamuraisViaInclude/{battleId}", Name = "GetBattleAndInvolvedSamuraisViaInclude")]
        public async Task<ActionResult<List<BattleViewModel>>> GetBattleAndInvolvedSamuraisViaInclude(int battleId)
        {
            var battleModel = await _samuraiContext.Battles.Where(b => b.BattleId == battleId)
                .Include(b => b.SamuraiBattles).ThenInclude(sb => sb.Samurai).FirstOrDefaultAsync();
            var battleWithInvolvedSamuraisVM = new BattleViewModel();
            battleWithInvolvedSamuraisVM.BattleId = battleModel.BattleId;
            battleWithInvolvedSamuraisVM.Name = battleModel.Name;
            battleWithInvolvedSamuraisVM.StartDate = battleModel.StartDate;
            battleWithInvolvedSamuraisVM.EndDate = battleModel.EndDate;
            battleWithInvolvedSamuraisVM.BattlePlace = battleModel.BattlePlace;
            battleWithInvolvedSamuraisVM.InvolvedSamurais = battleModel.SamuraiBattles.Select(sb => sb.Samurai.Name).ToList();
            return Ok(battleWithInvolvedSamuraisVM);
        }


        [HttpPost("AddBattle")]
        public async Task<ActionResult<Battle>> CreateBattle([FromBody] Battle battle)
        {
            var obj = await _samuraiContext.Battles.AddAsync(battle);
            _samuraiContext.SaveChanges();            
            return CreatedAtRoute("GetBattle", new { id = battle.BattleId }, battle);
        }

        [HttpPost("AddBattlesToSamurai")]
        public async Task<ActionResult<SamuraiEntity>> AddBattlesToSamurai([FromBody] BattlesAddToSamuraiDTO battlesToBeAddedToSamurai)
        {
            var samurai = await _samuraiContext.Samurais.Where(s => s.Id == battlesToBeAddedToSamurai.SamuraiId).FirstOrDefaultAsync();
            foreach( Battle battle in battlesToBeAddedToSamurai.Battles)
            {
                samurai.SamuraiBattles.Add(new SamuraiBattle { Battle = battle });
            }
            await _samuraiContext.SaveChangesAsync();
            return Ok(new SamuraiEntity(samurai));
        }

        [HttpPost("AddSamuraiWithQuotesAndBattles")]
        public async Task<ActionResult> AddSamuraiWithQuotesAndBattles([FromBody] SamuraiWithQuotesAndBattlesAddDTO samuCreateWithBattles)
        {
            Samurai samurai;
            samurai = samuCreateWithBattles.Samurai;
            samurai.Quotes = samuCreateWithBattles.Samurai.Quotes;
            foreach(Battle battle in samuCreateWithBattles.Battles)
            {
                samurai.SamuraiBattles.Add(new SamuraiBattle { Battle = battle});
            }
            _samuraiContext.Add(samurai);
            await _samuraiContext.SaveChangesAsync();
            return Ok(new SamuraiEntity(samurai));
        }

    }
}
