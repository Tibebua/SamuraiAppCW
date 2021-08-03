using SamuraiAppCW.Data.Repository;
using SamuraiAppCW.Models;
using SamuraiAppCW.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Services
{
    public class SamuraiService: ISamuraiService
    {
        private readonly ISamuraiRepository _samuraiRepo;

        public SamuraiService(ISamuraiRepository samuraiRepo)
        {
            _samuraiRepo = samuraiRepo ?? throw new ArgumentNullException(nameof(samuraiRepo));
        }

        public async Task<List<Samurai>> GetAllSamurais()
        {
            var allSamurais = await _samuraiRepo.GetSamurais();
            return allSamurais;
        }

        public async Task<Samurai> GetSamurai(int id)
        {
            var Samurai = await _samuraiRepo.GetSamurai(id);
            return Samurai;
        }

        //public async Task<SamuraiWithBattlesVM> GetSamuraiWithHisBattles(int samuraiId)
        //{
        //    var samurai = await _samuraiRepo.GetSamuraiWithHisBattles(samuraiId);
        //    SamuraiWithBattlesVM samuariWithBattle = new SamuraiWithBattlesVM();
        //    samura
        //}

        public async Task<Samurai> CreateSamurai(Samurai samurai)
        {
            return await _samuraiRepo.CreateSamurai(samurai);
        }

        public async Task<bool> CreateSamurais(List<Samurai> samurais)
        {
            return await _samuraiRepo.CreateSamurais(samurais);
        }
        
        // BATTLE
        public async Task<Battle> CreateBattle(Battle battle)
        {
            return await _samuraiRepo.CreateBattle(battle);
        }

        public async Task<Battle> GetBattle(int Id)
        {
            return await _samuraiRepo.GetBattle(Id);
        }
    }
}
