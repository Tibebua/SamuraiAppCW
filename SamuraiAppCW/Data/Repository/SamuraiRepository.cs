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

        public async Task<List<Samurai>> GetSamurais()
        {
            var samurais = await _context.Samurais.ToListAsync();
            return samurais;
        }
    }
}
