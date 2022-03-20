using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ardalis.SmartEnum;

namespace SetAnalysis
{
    public class Characteristic : IComparable<Characteristic>
    {
        public int Value;

        public Characteristic(int value)
        {
            Value = value;
        }

        public int CompareTo(Characteristic other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Value.CompareTo(other.Value);
        }
    }

    public class Color : Characteristic
    {
        public static readonly Color Red = new(0);
        public static readonly Color Green = new(1);
        public static readonly Color Purple = new(2);
        public Color(int value) : base(value) { }
        
        public static List<Color> GetValues() => new() {Red, Green, Purple};
    }
    
    public class Number : Characteristic
    {
        public static readonly Number One = new(0);
        public static readonly Number Two = new(1);
        public static readonly Number Three = new(2);
        public Number(int value) : base(value) { }
        
        public static List<Number> GetValues() => new() {One, Two, Three};
    }
    
    public class Shape : Characteristic
    {
        public static readonly Shape Oval = new(0);
        public static readonly Shape Squiggle = new(1);
        public static readonly Shape Diamond = new(2);
        public Shape(int value) : base(value) { }
        public static List<Shape> GetValues() => new() {Oval, Squiggle, Diamond};
    }
    
    public class Shading : Characteristic
    {
        public static readonly Shading Empty = new(0);
        public static readonly Shading Hashed = new(1);
        public static readonly Shading Solid = new(2);
        public Shading(int value) : base(value) { }
        public static List<Shading> GetValues() => new() {Empty, Hashed, Solid};

    }
}