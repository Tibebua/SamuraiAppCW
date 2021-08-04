using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Models.ViewModels
{
    public class QuoteGetDTO
    {
        public int QuoteId { get; set; }
        public string Text { get; set; }

        public QuoteGetDTO(Quote model)
        {
            this.QuoteId = model.QuoteId;
            this.Text = model.Text;
        }
    }
}
