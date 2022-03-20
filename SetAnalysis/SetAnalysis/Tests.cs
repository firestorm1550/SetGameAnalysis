using System.Collections.Generic;
using NUnit.Framework;

namespace SetAnalysis
{
    public static class Tests
    {
        [Test]
        public static void DiffShapesPositive()
        {
            SetCard card1 = new SetCard(Number.One, Color.Red, Shape.Squiggle, Shading.Solid);
            SetCard card2 = new SetCard(Number.One, Color.Red, Shape.Oval, Shading.Solid);
            SetCard card3 = new SetCard(Number.One, Color.Red, Shape.Diamond, Shading.Solid);
            
            Assert.IsTrue(SetFinder.IsSet(card1, card2, card3));
        }
        
        [Test]
        public static void DiffShapesNumbersPositive()
        {
            SetCard card1 = new SetCard(Number.One, Color.Red, Shape.Squiggle, Shading.Solid);
            SetCard card2 = new SetCard(Number.Two, Color.Red, Shape.Oval, Shading.Solid);
            SetCard card3 = new SetCard(Number.Three, Color.Red, Shape.Diamond, Shading.Solid);
            
            Assert.IsTrue(SetFinder.IsSet(card1, card2, card3));
        }
        
        [Test]
        public static void DiffShapesNumbersColorsPositive()
        {
            SetCard card1 = new SetCard(Number.One, Color.Red, Shape.Squiggle, Shading.Solid);
            SetCard card2 = new SetCard(Number.Two, Color.Green, Shape.Oval, Shading.Solid);
            SetCard card3 = new SetCard(Number.Three, Color.Purple, Shape.Diamond, Shading.Solid);
            
            Assert.IsTrue(SetFinder.IsSet(card1, card2, card3));
        }
        
        [Test]
        public static void DiffShapesNumbersColorsShadingPositive()
        {
            SetCard card1 = new SetCard(Number.One, Color.Red, Shape.Squiggle, Shading.Solid);
            SetCard card2 = new SetCard(Number.Two, Color.Green, Shape.Oval, Shading.Hashed);
            SetCard card3 = new SetCard(Number.Three, Color.Purple, Shape.Diamond, Shading.Solid);
            
            Assert.IsTrue(SetFinder.IsSet(card1, card2, card3));
        }
        
        [Test]
        public static void DiffShapesNumbersNegative()
        {
            SetCard card1 = new SetCard(Number.One, Color.Red, Shape.Squiggle, Shading.Solid);
            SetCard card2 = new SetCard(Number.One, Color.Red, Shape.Squiggle, Shading.Solid);
            SetCard card3 = new SetCard(Number.Three, Color.Red, Shape.Diamond, Shading.Solid);
            
            Assert.IsFalse(SetFinder.IsSet(card1, card2, card3));
        }
        
        [Test]
        public static void DiffColorsNegative()
        {
            SetCard card1 = new SetCard(Number.One, Color.Red, Shape.Squiggle, Shading.Solid);
            SetCard card2 = new SetCard(Number.Two, Color.Green, Shape.Squiggle, Shading.Solid);
            SetCard card3 = new SetCard(Number.Three, Color.Red, Shape.Squiggle, Shading.Solid);
            
            Assert.IsFalse(SetFinder.IsSet(card1, card2, card3));
        }

        [Test]
        public static void TestMostCommonCharacteristicOnes()
        {
            List<SetCard> cards = new List<SetCard>()
            {
                {new(Number.One, Color.Red, Shape.Squiggle, Shading.Empty)},
                {new(Number.One, Color.Green, Shape.Oval, Shading.Empty)},
                {new(Number.One, Color.Green, Shape.Squiggle, Shading.Solid)},
                {new(Number.One, Color.Purple, Shape.Diamond, Shading.Empty)},
                {new(Number.One, Color.Purple, Shape.Diamond, Shading.Hashed)},
            };
            Characteristic mostCommonCharacteristic = cards.GetMostCommonCharacteristic();
            
            Assert.IsTrue(mostCommonCharacteristic == Number.One);
        }
    }
    
    
}