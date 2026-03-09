using System;

namespace OOPDemo
{
    abstract class Shape
    {
        public abstract double GetArea();
    }

    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double GetArea()
        {
            return Width * Height;
        }
    }

    sealed class Circle : Shape
    {
        public double Radius { get; set; }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape s = new Rectangle { Width = 4, Height = 5 };
            Console.WriteLine($"Area: {s.GetArea()}");
        }
    }
}

/*
===============================================================================
ABSTRACT AND SEALED – C# vs C++
===============================================================================

ABSTRACT:

C++:
    virtual double GetArea() = 0;

C#:
    public abstract double GetArea();

- Class containing abstract methods must be abstract.
- Cannot instantiate abstract class.

SEALED:

C++:
    class Circle final {};

C#:
    sealed class Circle {}

Meaning:
- No class can inherit from Circle.

Also possible:
    public override sealed void Method()

Which prevents further overriding.

C# uses "sealed" instead of "final".
*/