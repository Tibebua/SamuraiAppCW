using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Models.DTO
{
    public class SamuraiWithQuotesAndBattlesAddDTO
    {
        public Samurai Samurai { get; set; }
        public List<Battle> Battles { get; set; }
    }
}
