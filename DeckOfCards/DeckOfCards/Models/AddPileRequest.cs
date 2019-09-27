using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckOfCards.Models
{
    public class AddPileRequest
    {
        public string Op { get; set; }
        public string Path { get; set; }
        public List<string> value { get; set; }

        public AddPileRequest (List<string> value)
        {
            this.Op = "add";
            this.Path = "/cards";
            this.value = value;
        }
    }
}