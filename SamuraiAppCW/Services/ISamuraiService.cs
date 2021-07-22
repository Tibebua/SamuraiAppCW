using SamuraiAppCW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Services
{
    public interface ISamuraiService
    {
        Task<List<Samurai>> GetAllSamurais();
        Task<Samurai> GetSamurai(int id);
        Task<Samurai> CreateSamurai(Samurai samurai);
        Task<bool> CreateSamurais(List<Samurai> samurais);
    }
}
