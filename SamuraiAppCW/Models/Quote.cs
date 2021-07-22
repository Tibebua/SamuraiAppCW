using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Models
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }
        public string Text { get; set; }
        [ForeignKey(nameof(Samurai))]
        public int SamuraiId { get; set; } // EF looks for ClassName + "Id" and maps it as foreign key (z anotation is optional)
        public virtual Samurai Samurai { get; set; }
    }
}
