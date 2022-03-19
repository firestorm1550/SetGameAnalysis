using System;
using System.Collections.Generic;
using System.Linq;

namespace SetAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<SetCard> cards = new List<SetCard>();
            
            foreach (Number number in Enum.GetValues<Number>())
            foreach (Color color in Enum.GetValues<Color>())
            foreach (Shape shape in Enum.GetValues<Shape>())
            foreach (Shading shading in Enum.GetValues<Shading>())
            {
                cards.Add(new SetCard(number, color, shape, shading));
                Console.WriteLine("Card: " + cards.Count + ": " + cards.Last());
            }
        }
    }
}