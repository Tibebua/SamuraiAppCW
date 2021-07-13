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
    }
}
