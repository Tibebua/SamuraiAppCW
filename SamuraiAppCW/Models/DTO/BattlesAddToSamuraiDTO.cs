using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Models.DTO
{
    public class BattlesAddToSamuraiDTO
    {
        public int SamuraiId { get; set; }
        public List<Battle> Battles { get; set; }
    }
}
