using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Models.Entities
{
    public class QuoteEntity
    {
        public int QuoteId { get; set; }
        public string Text { get; set; }

        public QuoteEntity()
        {

        }
        public QuoteEntity(Quote model)
        {
            if(model != null)
            {
                QuoteId = model.QuoteId;
                Text = model.Text;
            }
        }
    }
}
