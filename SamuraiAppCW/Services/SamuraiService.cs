using SamuraiAppCW.Data.Repository;
using SamuraiAppCW.Models;
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
            _samuraiRepo = samuraiRepo;
        }

        public async Task<List<Samurai>> GetAllSamurais()
        {
            var allSamurais = await _samuraiRepo.GetSamurais();
            return allSamurais;
        }
    }
}
