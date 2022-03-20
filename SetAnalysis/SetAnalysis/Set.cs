using System;
using System.Collections.Generic;

namespace SetAnalysis
{
    public struct Set
    {
        public SetCard Card1;
        public SetCard Card2;
        public SetCard Card3;

        public List<Type> MatchingAttributes;

        public Set(SetCard card1, SetCard card2, SetCard card3)
        {
            if (SetFinder.IsSet(card1, card2, card3) == false)
                throw new Exception("This set is invalid");
            
            Card1 = card1;
            Card2 = card2;
            Card3 = card3;

            MatchingAttributes = new List<Type>();
            
            if(card1.Number == card2.Number && card2.Number == card3.Number)
                MatchingAttributes.Add(typeof(Number));
            if(card1.Color == card2.Color && card2.Color == card3.Color)
                MatchingAttributes.Add(typeof(Color));
            if(card1.Shape == card2.Shape && card2.Shape == card3.Shape)
                MatchingAttributes.Add(typeof(Shape));
            if(card1.Shading == card2.Shading && card2.Shading == card3.Shading)
                MatchingAttributes.Add(typeof(Shading));
        }

        public Set(Tuple<SetCard, SetCard, SetCard> triplet) : this(triplet.Item1, triplet.Item2, triplet.Item3)
        {
            
        }
        
        public override string ToString()
        {
            return "{" + Card1 + ", " + Card2 + ", " + Card3 + "}";
        }
    }
}