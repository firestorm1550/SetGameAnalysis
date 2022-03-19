namespace SetAnalysis
{
    public struct SetCard
    {
        public Number  Number;
        public Color   Color;
        public Shape   Shape;
        public Shading Shading;

        public SetCard(Number number, Color color, Shape shape, Shading shading)
        {
            Number = number;
            Color = color;
            Shape = shape;
            Shading = shading;
        }

        public override string ToString()
        {
            return Number + "-" + Color + "-" + Shape + "-" + Shading;
        }
    }
}