using SamuraiAppCW.Models.OwnedEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Models
{
    public class Samurai
    {
        public Samurai()
        {
            this.Quotes = new HashSet<Quote>();
            this.SamuraiBattles = new HashSet<SamuraiBattle>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public FormalName FormalName { get; set; }
        public ICollection<Quote> Quotes { get; set; }
        public ICollection<SamuraiBattle> SamuraiBattles { get; set; }
        public Address Address { get; set; }
    }
}
