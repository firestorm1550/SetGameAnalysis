using System;
using System.Collections.Generic;

namespace SetAnalysis
{
    public static class SetFinder
    {
        public static bool IsSet(SetCard card1, SetCard card2, SetCard card3)
        {
            int numberSum = card1.Number.Value + card2.Number.Value + card3.Number.Value;
            int colorSum = card1.Color.Value + card2.Color.Value + card3.Color.Value;
            int shapeSum = card1.Shape.Value + card2.Shape.Value + card3.Shape.Value;
            int shadingSum = card1.Shading.Value + card2.Shading.Value + card3.Shading.Value;

            numberSum %= 3; 
            colorSum %= 3; 
            shapeSum %= 3;  
            shadingSum %= 3;

            return numberSum + colorSum + shapeSum + shadingSum == 0;
        }

        public static List<Set> FindSets(List<SetCard> cards)
        {
            List<Tuple<SetCard, SetCard, SetCard>> triplets = cards.CreateTriplets();
            //Console.WriteLine(triplets.Count + " triplets in " + cards.ToPrettyString() + "\n");
            
            List<Set> sets = new List<Set>();
            foreach (Tuple<SetCard,SetCard,SetCard> triplet in triplets)
                if (IsSet(triplet.Item1, triplet.Item2, triplet.Item3))
                    sets.Add(new Set(triplet));
            return sets;
        }
    }
}