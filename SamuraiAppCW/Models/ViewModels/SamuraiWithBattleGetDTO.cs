using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Models.ViewModels
{
    public class SamuraiWithBattleGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuoteGetDTO> Quotes { get; set; }
        public List<BattleGetDTO> Battles { get; set; }
    }
}
