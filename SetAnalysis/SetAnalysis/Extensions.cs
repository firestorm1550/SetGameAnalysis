namespace SetAnalysis
{
    public static class Extensions
    {
        public static byte AsByte(this Number number) => (byte) number;
        public static byte AsByte(this Color color) => (byte) color;
        public static byte AsByte(this Shape shape) => (byte) shape;
        public static byte AsByte(this Shading shading) => (byte) shading;
    }
}