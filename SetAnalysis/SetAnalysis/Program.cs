using System;
using System.Collections.Generic;
using System.Linq;

namespace SetAnalysis
{
    class Program
    {
        private static Random _random = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<SetCard> deck = GenerateDeck();
            var subset = GetRandomSubset(12, deck);
            var sets = SetFinder.FindSets(subset);
            
            Console.WriteLine(subset.ToPrettyString()+"\n");
            Console.WriteLine(sets.ToPrettyString());
        }

        private static List<SetCard> GetRandomSubset(int numCards, List<SetCard> wholeDeck)
        {
            if (numCards > wholeDeck.Count)
                Console.WriteLine("There are only " + wholeDeck.Count + " cards in the whole deck and you've requested " + numCards + ". Here's the whole deck");
            List<SetCard> chosenCards = wholeDeck.OrderBy(x => _random.Next()).Take(numCards).ToList();
            return chosenCards;
        }

        private static List<SetCard> GenerateDeck()
        {
            List<SetCard> cards = new List<SetCard>();
            
            foreach (Number number in Enum.GetValues<Number>())
            foreach (Color color in Enum.GetValues<Color>())
            foreach (Shape shape in Enum.GetValues<Shape>())
            foreach (Shading shading in Enum.GetValues<Shading>())
            {
                cards.Add(new SetCard(number, color, shape, shading));
                //Console.WriteLine("Card " + cards.Count + ": " + cards.Last());
            }

            return cards;
        }
    }
}