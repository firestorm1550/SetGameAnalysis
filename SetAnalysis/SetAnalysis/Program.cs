using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SetAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<SetCard> deck = CardDealer.GenerateDeck();
            Dictionary<int, int> numMatchingAttributesToNumSets = new Dictionary<int, int>();
            for (int i = 0; i < 4; i++)
                numMatchingAttributesToNumSets[i] = 0;

            int numTrials = 100000;
            int totalSets = 0;
            int setsThatMatchMostCommonCharacteristic = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            
            for (int i = 0; i < numTrials; i++)
            {
                List<SetCard> subset = CardDealer.GetRandomSubset(12, deck);
                Characteristic mostCommonCharacteristic = subset.GetMostCommonCharacteristic();
                List<Set> sets = SetFinder.FindSets(subset);

                foreach (Set set in sets)
                {
                    numMatchingAttributesToNumSets[set.MatchingAttributes.Count]++;
                    totalSets++;

                    if (set.MatchingAttributes.Contains(mostCommonCharacteristic))
                        setsThatMatchMostCommonCharacteristic++;
                }
            }

            PrintSetTypeInfo(numMatchingAttributesToNumSets, totalSets);
            
            Console.WriteLine("Sets per 12 card group: " + (1.0 * totalSets / numTrials));
            PrintSetsMatchingMostCommonCharacteristic(setsThatMatchMostCommonCharacteristic, totalSets);
            Console.WriteLine("Time Elapsed: " + stopwatch.ElapsedMilliseconds + "ms");
        }

        
        private static void PrintSetTypeInfo(Dictionary<int, int> numMatchingAttributesToNumSets, int totalSets)
        {
            foreach (int key in numMatchingAttributesToNumSets.Keys)
            {
                int numSets = numMatchingAttributesToNumSets[key];
                double percentage = Math.Round(100.0 * numSets / totalSets, 3);
                Console.WriteLine("Sets with " + key + " matching attributes: " + numMatchingAttributesToNumSets[key] + " (" +
                                  percentage + "%)");
            }
        }

        private static void PrintSetsMatchingMostCommonCharacteristic(int setsThatMatchMostCommonCharacteristic, int totalSets)
        {
            double percentage = Math.Round(100.0 * setsThatMatchMostCommonCharacteristic / totalSets, 3);
            Console.WriteLine("Sets that match the most common characteristic: " + setsThatMatchMostCommonCharacteristic + " (" +percentage + "%)");
        }
    }
}