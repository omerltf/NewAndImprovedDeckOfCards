using DeckOfCards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckOfCards.Models
{
    public class ShortPileInfo
    {
        public string deckId { get; set; }
        public int remaining { get; set; }
        public string PileName { get; set; }
        public List<CardInfo> Cards {get; set;}
        //public Pile piles { get; set; }
    }
}