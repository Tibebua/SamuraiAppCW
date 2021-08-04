using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Models.Entities
{
    public class SamuraiEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuoteEntity> QuoteEntities { get; set; }
        public List<BattleEntity> BattleEntities { get; set; }

        public SamuraiEntity(Samurai samuraiModel)
        {
            if(samuraiModel != null)
            {
                Id = samuraiModel.Id;
                Name = samuraiModel.Name;
                QuoteEntities = samuraiModel.Quotes.ToList().ConvertAll(model => new QuoteEntity(model));
                BattleEntities = samuraiModel.SamuraiBattles.Select(sb => sb.Battle).ToList().ConvertAll(model => new BattleEntity(model));
            }
        }
    }
}
