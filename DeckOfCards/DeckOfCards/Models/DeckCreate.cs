using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckOfCards.Models
{
    public class DeckCreate
    {
        public int? Count { get; set; }

        public DeckCreate()
        {
            this.Count = 1;
        }
    }
}