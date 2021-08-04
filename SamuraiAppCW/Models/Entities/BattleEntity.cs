using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Models.Entities
{
    public class BattleEntity
    {
        public int BattleId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public BattleEntity()
        {

        }

        public BattleEntity(Battle model)
        {
            BattleId = model.BattleId;
            Name = model.Name;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
        }
    }
}
