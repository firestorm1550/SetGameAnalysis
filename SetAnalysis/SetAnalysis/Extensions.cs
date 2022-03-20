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

        public static Type GetMostCommonCharacteristic(this List<SetCard> cards)
        {
            // foreach (var pair in _cachedAttributeDictionary)
            // foreach (KeyValuePair<byte, int> internalPair in pair.Value)
            //     pair.Value[internalPair.Key] = 0;
            //
            // foreach (SetCard card in cards)
            // {
            //     _cachedAttributeDictionary[typeof(Number)][card.Number.Value]++;
            //     _cachedAttributeDictionary[typeof(Color)][card.Color.Value]++;
            //     _cachedAttributeDictionary[typeof(Shape)][card.Shape.Value]++;
            //     _cachedAttributeDictionary[typeof(Shading)][card.Shading.Value]++;
            // }
            //
            //
            // foreach (var pair in _cachedAttributeDictionary)
            // foreach (KeyValuePair<byte, int> internalPair in pair.Value)
            //     pair.Value[internalPair.Key] = 0;
            throw new NotImplementedException();
        }


        public static string ToPrettyString(this List<SetCard> cards) => cards.Count + " Cards:\n" + string.Join("\n", cards);
        public static string ToPrettyString(this List<Set> sets) => sets.Count + " Sets:\n" + string.Join("\n", sets);
    }
}