using System;
using System.Collections.Generic;
using System.Linq;

namespace SetAnalysis
{
    public static class CardDealer
    {
        private static Random _random = new Random();
        
        public static List<SetCard> GetRandomSubset(int numCards, List<SetCard> wholeDeck)
        {
            if (numCards > wholeDeck.Count)
                Console.WriteLine("There are only " + wholeDeck.Count + " cards in the whole deck and you've requested " + numCards + ". Here's the whole deck");
            List<SetCard> chosenCards = wholeDeck.OrderBy(x => _random.Next()).Take(numCards).ToList();
            return chosenCards;
        }

        public static List<SetCard> GenerateDeck()
        {
            List<SetCard> cards = new List<SetCard>();
            
            foreach (Number number in Number.GetValues())
            foreach (Color color in Color.GetValues())
            foreach (Shape shape in Shape.GetValues())
            foreach (Shading shading in Shading.GetValues())
            {
                cards.Add(new SetCard(number, color, shape, shading));
                //Console.WriteLine("Card " + cards.Count + ": " + cards.Last());
            }

            return cards;
        }
    }
}