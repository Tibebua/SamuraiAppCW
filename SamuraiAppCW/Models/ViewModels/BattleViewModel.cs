using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Models.ViewModels
{
    public class BattleViewModel
    { 
        public int BattleId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BattlePlace { get; set; }
        public List<string> InvolvedSamurais { get; set; }
    }
}
