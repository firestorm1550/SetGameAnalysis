namespace SetAnalysis
{
    public static class SetFinder
    {
        public static bool IsSet(SetCard card1, SetCard card2, SetCard card3)
        {
            int numberSum = card1.Number.AsByte() + card2.Number.AsByte() + card3.Number.AsByte();
            int colorSum = card1.Color.AsByte() + card2.Color.AsByte() + card3.Color.AsByte();
            int shapeSum = card1.Shape.AsByte() + card2.Shape.AsByte() + card3.Shape.AsByte();
            int shadingSum = card1.Shading.AsByte() + card2.Shading.AsByte() + card3.Shading.AsByte();

            numberSum %= 3; 
            colorSum %= 3; 
            shapeSum %= 3;  
            shadingSum %= 3;

            return numberSum + colorSum + shapeSum + shadingSum == 0;
        }
    }
}