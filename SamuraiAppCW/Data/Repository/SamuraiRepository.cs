using Microsoft.EntityFrameworkCore;
using SamuraiAppCW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Data.Repository
{
    public class SamuraiRepository: ISamuraiRepository
    {
        private readonly SamuraiContext _context;

        public SamuraiRepository(SamuraiContext context)
        {
            _context = context;
        }

        // Samurai
        public async Task<List<Samurai>> GetSamurais()
        {
            var samurais = await _context.Samurais.Include(s => s.Quotes).ToListAsync();
            return samurais;
        }

        public async Task<Samurai> GetSamurai(int id)
        {
            var samurai = await _context.Samurais.Include(s => s.Quotes).Where(s => s.Id == id).FirstOrDefaultAsync();
            return samurai;
        }

        public async Task<Samurai> GetSamuraiWithHisBattles(int samuId)
        {
            var samurai = await _context.Samurais.Include(s => s.SamuraiBattles)
                .ThenInclude(sb => sb.Battle).Where(sa => sa.Id == samuId).FirstOrDefaultAsync();
            return samurai;
        }

        public async Task<Samurai> CreateSamurai(Samurai samurai)
        {
            var obj = await _context.Samurais.AddAsync(samurai);
            _context.SaveChanges();
            return obj.Entity;
        }

        public async Task<bool> CreateSamurais(List<Samurai> samurais)
        {
            await _context.Samurais.AddRangeAsync(samurais);
            _context.SaveChanges();
            return true;
        }

        // Battle
        public async Task<Battle> CreateBattle(Battle battle)
        {
            var obj = await _context.Battles.AddAsync(battle);
            _context.SaveChanges();
            return obj.Entity;
        }

        public async Task<Battle> GetBattle(int id)
        {
            var battle = await _context.Battles.FirstOrDefaultAsync(b => b.BattleId == id);
            return battle;
        }

    }
}
