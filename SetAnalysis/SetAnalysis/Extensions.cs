using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SetAnalysis
{
    public static class Extensions
    {
        public static List<Tuple<SetCard, SetCard, SetCard>> CreateTriplets(this List<SetCard> cards)
        {
            var triplets = new List<Tuple<SetCard, SetCard, SetCard>>();
            if (cards.Count < 3)
                return triplets;

            for (int i = 0; i < cards.Count - 2; i++)
            for (int j = i + 1; j < cards.Count - 1; j++)
            for (int k = j + 1; k < cards.Count; k++)
                triplets.Add(new Tuple<SetCard, SetCard, SetCard>(cards[i], cards[j], cards[k]));

            return triplets;
        }

        public static Characteristic GetMostCommonCharacteristic(this List<SetCard> cards)
        {
            Dictionary<Characteristic, int> occurrences = new Dictionary<Characteristic, int>();
            foreach (var characteristic in Characteristic.GetAllCharacteristics()) 
                occurrences[characteristic] = 0;

            foreach (SetCard card in cards)
            {
                occurrences[card.Number]++;
                occurrences[card.Color]++;
                occurrences[card.Shape]++;
                occurrences[card.Shading]++;
            }
            
            
            Characteristic most = Number.One;
            
            foreach (var characteristic in Characteristic.GetAllCharacteristics())
                if (occurrences[characteristic] > occurrences[most])
                    most = characteristic;


            return most;
        }


        public static string ToPrettyString(this List<SetCard> cards) => cards.Count + " Cards:\n" + string.Join("\n", cards);
        public static string ToPrettyString(this List<Set> sets) => sets.Count + " Sets:\n" + string.Join("\n", sets);
    }
}