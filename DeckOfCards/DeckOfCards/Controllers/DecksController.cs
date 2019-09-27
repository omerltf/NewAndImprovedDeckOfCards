using DeckOfCards.Data;
using DeckOfCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;

namespace DeckOfCards.Controllers
{
    [RoutePrefix("api/decks")]
    public class DecksController : ApiController
    {
        private IDeckRepository Repository;

        public DecksController(IDeckRepository repo)
        {
            Repository = repo;
        }

        async public Task<ShortDeckInfo> Post(DeckCreate creation)
        {
            int creationCount = creation.Count.HasValue ? creation.Count.Value : 1;
            Deck deck = await Repository.CreateNewShuffledDeckAsync(creationCount);
            ShortDeckInfo deckInfo = new ShortDeckInfo
            {
                DeckId = deck.DeckId,
                Remaining = deck.Cards.Where(x => !x.Drawn).Count()
            };
            return deckInfo;
        }

        [Route("{deckId}/cards")]
        async public Task<CardDrawnResponse> Delete(string deckId, CardDrawRequest request)
        {
            int drawCount = request.Count.HasValue ? request.Count.Value : 1;
            Deck deck = await Repository.DrawCardsAsync(deckId, drawCount);
            List<CardInfo> cards = deck.Cards
              .Where(x => x.Drawn)
              .Reverse()
              .Take(drawCount)
              .Reverse()
              .Select(x => new CardInfo { Suit = x.Suit, Value = x.Value, Code = x.Code })
              .ToList();
            return new CardDrawnResponse
            {
                DeckId = deckId,
                Remaining = deck.Cards.Where(x => !x.Drawn).Count(),
                Removed = cards,
            };
        }

        [Route("{deckId}/piles/{pileName}")]
        async public Task<PileInfo> Patch(string deckId, string PileName, AddPileRequest pileRequest)
        {
            Deck deck = await Repository.PutCardsInPile(deckId, PileName, pileRequest.value);

            return new PileInfo
            {
                deckId = deck.DeckId,
                remaining = deck.Cards.Where(x => !x.Drawn).Count(),
                piles = deck.Piles
            };
        }

        [Route("{deckId}/piles/{pileName}")]
        async public Task<ShortPileInfo> Get (string deckId, string PileName)
        {

            Deck deck = await Repository.GetDeck(deckId);
            Pile myPile = await Repository.GetPile(deckId, PileName);

            List<CardInfo> cards = deck.Cards
              .Where(x => x.PileId == myPile.Id)
              .Select(x => new CardInfo { Suit = x.Suit, Value = x.Value, Code = x.Code })
              .ToList();

            return new ShortPileInfo
            {
                deckId = deckId,
                remaining = deck.Cards.Where(x => !x.Drawn).Count(),
                PileName = myPile.Name,
                Cards = cards
            };
        }
    }
}
