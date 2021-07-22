using SamuraiAppCW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Data.Repository
{
    public interface ISamuraiRepository
    {
        Task<List<Samurai>> GetSamurais();
        Task<Samurai> GetSamurai(int id);
        Task<Samurai> CreateSamurai(Samurai samurai);
        Task<bool> CreateSamurais(List<Samurai> samurais);
    }
}
