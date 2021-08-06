using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Models
{
    public class Battle
    {
        public Battle()
        {
            this.SamuraiBattles = new HashSet<SamuraiBattle>();
        }
        [Key]
        public int BattleId { get; set; }
        public string Name { get; set; }
        // [Column(TypeName = "Date")] this also works, i just used the fluent api in the dbcontext
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BattlePlace { get; set; }
        public ICollection<SamuraiBattle> SamuraiBattles { get; set; }
    }
}
