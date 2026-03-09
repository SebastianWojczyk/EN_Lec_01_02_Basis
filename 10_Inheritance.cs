using System;

namespace OOPDemo
{
    class Person
    {
        public string Name { get; set; }

        public void Introduce()
        {
            Console.WriteLine($"Hi, my name is {Name}");
        }
    }

    class Student : Person
    {
        public string Major { get; set; }

        public void Study()
        {
            Console.WriteLine($"{Name} studies {Major}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.Name = "Alice";
            s.Major = "Computer Science";

            s.Introduce(); // inherited method
            s.Study();
        }
    }
}

/*
===============================================================================
INHERITANCE IN C# – COMPARISON WITH C++
===============================================================================

1. Basic syntax:
   class Derived : Base

   Equivalent in C++:
   class Derived : public Base

2. IMPORTANT DIFFERENCE:
   - In C++, inheritance may be public/private/protected.
   - In C#, inheritance is always "public".

3. C# does NOT support multiple inheritance of classes.
   C++ does:
       class C : public A, public B

   In C# this is forbidden (diamond problem avoided).

-------------------------------------------------------------------------------

4. ROOT CLASS – System.Object

In C# every class implicitly inherits from System.Object.

Example:

    class Person
    {
    }

is internally treated as:

    class Person : Object
    {
    }

This means that ALL classes automatically inherit several fundamental methods.

Important methods inherited from Object:

    ToString()
        Returns a string representation of the object.

        Example:
            Person p = new Person();
            Console.WriteLine(p.ToString());

        Default implementation prints the full type name:
            Namespace.Person

        Usually overridden to provide meaningful output.

------------------------------------------------------------

    GetType()
        Returns runtime type information.

        Example:

            Person p = new Person();
            Console.WriteLine(p.GetType());

        Output:
            OOPDemo.Person
------------------------------------------------------------

    Equals(object obj)
        Compares two objects for equality.

        Default implementation checks reference equality
        (whether both variables reference the same object).

        Often overridden when objects represent value data.

------------------------------------------------------------

    GetHashCode()
        Returns an integer hash code for the object.

        Used by collections such as:

            Dictionary - hash code determines element of the dictionary
            HashSet - hash code determines uniqueness
            LINQ - hash code for grouping

        If Equals() is overridden, GetHashCode() should also be overridden.

------------------------------------------------------------
    Simple Example of Implementation

    class Person
    {
        public string Name;
        public int Age;

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            if (other == null)
                return false;

            return Name == other.Name && Age == other.Age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }
    }

HashCode.Combine() is a helper method introduced in modern C#.


------------------------------------------------------------
 IMPORTANT CONSEQUENCES
------------------------------------------------------------

Because every class inherits from Object:

- all classes support ToString()
- all classes support Equals()
- all classes support GetHashCode()
- all classes support GetType()

Even user-defined classes automatically receive this functionality.

This makes Object the fundamental root of the entire C# type system.

This file demonstrates structural inheritance only.
Polymorphism comes next.
*/