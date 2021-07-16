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
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}
