//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SamuraiAppCW.Models.ViewModels
//{
//    public class SamuraiWithBattlesVM
//    {
//        public SamuraiWithBattlesVM()
//        {
//            this.Battles = new List<Battle>();
//        }
//        public int Id { get; set; }
//        [Required]
//        public string Name { get; set; }
//        public ICollection<Quote> Quotes { get; set; }
//        public List<BattleVM> Battles { get; set; }

//        public SamuraiWithBattlesVM(Samurai samurai)
//        {
//            this.Id = samurai.Id;
//            this.Name = samurai.Name;
//            this.Quotes = samurai.Quotes;
//            this.Battles.AddRange(sa)
//        }
//    }
//}
