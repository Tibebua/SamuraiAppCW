using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Models
{
    public class SamuraiBattle
    {
        [ForeignKey(nameof(Samurai))]
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }
        [ForeignKey(nameof(Battle))]
        public int BattleRefId { get; set; }
        public Battle Battle { get; set; }
    }
}
