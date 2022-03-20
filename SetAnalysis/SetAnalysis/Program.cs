using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Dictionary<int, int> numMatchingAttributesToNumSets = new Dictionary<int, int>();
            for (int i = 0; i < 4; i++)
                numMatchingAttributesToNumSets[i] = 0;

            int numTrials = 100000;
            int totalSets = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            
            for (int i = 0; i < numTrials; i++)
            {
                var subset = GetRandomSubset(12, deck);
                var sets = SetFinder.FindSets(subset);

                foreach (Set set in sets)
                {
                    numMatchingAttributesToNumSets[set.MatchingAttributes.Count]++;
                    totalSets++;
                }
            }

            foreach (int key in numMatchingAttributesToNumSets.Keys)
            {
                int numSets = numMatchingAttributesToNumSets[key];
                double percentage = Math.Round(100.0 * numSets / totalSets, 3);
                Console.WriteLine("Sets with " + key + " matching attributes: " + numMatchingAttributesToNumSets[key] + " (" + percentage + "%)");
            }
            
            Console.WriteLine("Sets per 12 card group: " + (1.0 * totalSets / numTrials));
            Console.WriteLine("Time Elapsed: " + stopwatch.ElapsedMilliseconds + "ms");
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