using System;

namespace OOPDemo
{
    class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Some generic sound");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }

    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal a1 = new Dog();
            Animal a2 = new Cat();

            a1.MakeSound(); // Woof!
            a2.MakeSound(); // Meow!
        }
    }
}

/*
===============================================================================
POLYMORPHISM IN C# – KEY DIFFERENCES FROM C++
===============================================================================

1. In C++, dynamic dispatch requires "virtual".
   In C#, dynamic dispatch requires:
        virtual (in base)
        override (in derived)

2. C# enforces explicitness:
   - If base method is not virtual, you CANNOT override it.
   - Compiler prevents accidental overriding.

3. Runtime behavior:
   Animal a = new Dog();
   a.MakeSound();  // calls Dog version

   This is true polymorphism (dynamic binding).

4. Without virtual:
   The base version would be called.

C# is stricter and safer than C++ in this area.
*/