//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SamuraiAppCW.Models;
//using SamuraiAppCW.Services;

//namespace SamuraiAppCW.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SamuraiController : ControllerBase
//    {
//        private readonly ISamuraiService _samuraiService;

//        public SamuraiController(ISamuraiService samuraiService)
//        {
//            _samuraiService = samuraiService ?? throw new ArgumentNullException(nameof(samuraiService));
//        }

//        [HttpGet("GetAllSamurais", Name ="GetAllSamurais")]
//        public async Task<ActionResult<List<Samurai>>> GetSamurais()
//        {
//            var samurais = await _samuraiService.GetAllSamurais();
//            if(samurais == null)
//            {
//                return NotFound();
//            }
//            return Ok(samurais);
//        }

//        [HttpGet("GetSamurai/{id}", Name ="GetSamurai")]
//        public async Task<ActionResult<Samurai>> GetSamurai(int id)
//        {
//            var samurai = await _samuraiService.GetSamurai(id);
//            if (samurai == null)
//            {
//                return NotFound();
//            }
//            return Ok(samurai);
//        }

//        [HttpPost("AddSamurai")]
//        public async Task<ActionResult<Samurai>> CreateSamurai([FromBody]Samurai samurai)
//        {
//            var entity = await _samuraiService.CreateSamurai(samurai);
//            return CreatedAtRoute(nameof(GetSamurai), new { id = samurai.Id }, entity); // here u can pass the "samurai" too
//        }

//        [HttpPost("AddSamurais")]
//        public async Task<ActionResult<List<Samurai>>> CreateSamurais([FromBody] List<Samurai> samurais)
//        {
//            var entities = await _samuraiService.CreateSamurais(samurais);
//            return Ok();
//        }

//        [HttpGet("GetSamuraiWithBattles/{id}", Name = "GetSamuraiWithBattles")]
//        //public async Task<ActionResult<Samurai>> GetSamuraiWithBattles(int id)
//        //{
//        //    var samurai = await _samuraiService.GetSamuraiWithHisBattles(id);
//        //    if (samurai == null)
//        //    {
//        //        return NotFound();
//        //    }
//        //    return Ok(samurai);
//        //}

//        // BATTLE
//        [HttpPost("AddBattle")]
//        public async Task<ActionResult<Battle>> CreateBattle([FromBody] Battle battle)
//        {
//            await _samuraiService.CreateBattle(battle);
//            return CreatedAtRoute("GetBattle", new { id = battle.BattleId }, battle);

//        }

//        [HttpGet("GetBattle/{id}", Name = "GetBattle")]
//        public async Task<ActionResult<Battle>> GetBattle(int id)
//        {
//            return await _samuraiService.GetBattle(id);
//        }

//    }
//}
