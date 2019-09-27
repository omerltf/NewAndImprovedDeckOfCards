using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards.Data
{
    public interface IDeckRepository
    {
        Task<Deck> CreateNewShuffledDeckAsync(int deckCount);

        Task<Deck> DrawCardsAsync(string deckId, int numberToDraw);

        Task<Deck> PutCardsInPile(string deckId, string pileName, List<string> cardCodes);

        Task<Pile> GetPile(string deckId, string pileName);
        Task<Deck> GetDeck(string deckId);
    }
}
