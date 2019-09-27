using DeckOfCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckOfCards.Models
{
    public class PileInfo
    {
        public  string deckId { get; set; }
        public int remaining { get; set; }
        public IList<Pile> piles { get; set; }
    }
}