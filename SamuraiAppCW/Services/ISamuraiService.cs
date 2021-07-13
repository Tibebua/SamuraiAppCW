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
    }
}
