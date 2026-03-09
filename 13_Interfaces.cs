using System;

namespace OOPDemo
{
    interface IDriveable
    {
        void Drive();
    }

    interface IElectric
    {
        void Charge();
    }

    class ElectricCar : IDriveable, IElectric
    {
        public void Drive()
        {
            Console.WriteLine("Driving silently...");
        }

        public void Charge()
        {
            Console.WriteLine("Charging battery...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IDriveable car = new ElectricCar();
            car.Drive();
        }
    }
}

/*
===============================================================================
INTERFACES – SUBSTITUTE FOR MULTIPLE INHERITANCE
===============================================================================

C++ supports multiple inheritance of classes.
C# does NOT.

Instead, C# uses interfaces.

Key rules:

1. Interface contains only method signatures (traditionally).
2. A class may implement multiple interfaces:
        class A : I1, I2, I3

3. Interface does NOT contain implementation (simplified view for students).

Polymorphism works through interfaces:

    IDriveable d = new ElectricCar();
    d.Drive();

This is extremely common in real-world C# applications.
*/