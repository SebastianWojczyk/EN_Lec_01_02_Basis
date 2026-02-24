using System;

class Program
{
    static void Main(string[] args)
    {
        // ===============================
        // VALUE TYPES
        // ===============================
        int a = 10;      // int – value type
        int b = a;       // copying the value – b gets an independent copy
        b = 20;          // changing b DOES NOT affect a

        Console.WriteLine("Value Types:");
        Console.WriteLine($"a = {a}"); // 10 – value of a remains unchanged
        Console.WriteLine($"b = {b}"); // 20 – only b was changed

        // Custom structure (struct) – also a value type
        Point p1 = new Point { X = 5, Y = 10 }; // struct – value type
        Point p2 = p1;                          // value copy
        p2.X = 99;                              // changing p2 DOES NOT affect p1

        Console.WriteLine("\nCustom Value Type (struct):");
        Console.WriteLine($"p1.X = {p1.X}, p1.Y = {p1.Y}"); // 5,10 – original unchanged
        Console.WriteLine($"p2.X = {p2.X}, p2.Y = {p2.Y}"); // 99,10 – independent copy

        // ===============================
        // REFERENCE TYPES
        // ===============================
        // Class – reference type
        // NOTE: for reference types you must explicitly call the constructor
        MyClass obj1 = new MyClass(); // if we don't instantiate it, obj1 would be null
        obj1.Value = 5;

        MyClass obj2 = obj1; // copying the reference – both variables point to the same object
        obj2.Value = 10;     // change through obj2 DOES affect obj1

        Console.WriteLine("\nReference Type with Class:");
        Console.WriteLine($"obj1.Value = {obj1.Value}"); // 10 – shared object
        Console.WriteLine($"obj2.Value = {obj2.Value}"); // 10
    }
}

// Custom structure – value type
struct Point
{
    public int X; // field – part of the structure (value type)
    public int Y;
}

// Class – reference type
class MyClass
{
    public int Value; // public field
}

/*
================================================================================
C# VALUE TYPES vs REFERENCE TYPES
================================================================================

This file demonstrates the fundamental semantic difference between
value types and reference types in C#, explained for someone
who already understands C++ object semantics.

------------------------------------------------------------------------------
1. CORE DIFFERENCE: C++ vs C#
------------------------------------------------------------------------------

In C++:

    - struct and class behave the same (except for default visibility).
    - Both have VALUE semantics by default.
    - Copying an object copies the entire object.

Example in C++:

    class MyClass { public: int value; };

    MyClass a;
    MyClass b = a;   // full object copy

Each variable owns its own independent copy of the object.

In C#:

    - struct = VALUE TYPE
    - class  = REFERENCE TYPE

This difference is built into the type system.
You do not choose semantics per object — they are determined by the type.

------------------------------------------------------------------------------
2. VALUE TYPES IN C# (struct and primitives)
------------------------------------------------------------------------------

Example:

    int a = 10;
    int b = a;

This behaves exactly like C++.
The value is copied.
Changing b does not affect a.

Custom struct behaves the same way:

    struct Point
    {
        public int X;
        public int Y;
    }

When we write:

    Point p2 = p1;

The entire struct is copied.
This is conceptually identical to C++ value semantics.

Each variable stores its own independent data.

Important:
    With value types, assignment copies the data itself.

------------------------------------------------------------------------------
3. REFERENCE TYPES IN C# (class)
------------------------------------------------------------------------------

In C#:

    class MyClass
    {
        public int Value;
    }

When we write:

    MyClass obj1 = new MyClass();
    MyClass obj2 = obj1;

This DOES NOT copy the object.

Instead:
    - The object lives on the managed heap.
    - obj1 stores a reference to it.
    - obj2 receives a copy of that reference.
    - Both variables refer to the same object.

Therefore:

    obj2.Value = 10;

also changes:

    obj1.Value

Because there is only ONE object.

------------------------------------------------------------------------------
4. IMPORTANT MENTAL SHIFT FOR C++ DEVELOPERS
------------------------------------------------------------------------------

In C++:
    Class types behave like values by default.

In C#:
    Class types behave like shared objects by default.

This inversion is the most important conceptual difference
when moving from C++ to C#.

In C++ you must opt into shared state.
In C# you must opt into value semantics (by using struct).

------------------------------------------------------------------------------
5. MEMORY MODEL (SIMPLIFIED)
------------------------------------------------------------------------------

VALUE TYPE (struct, int):
    - Variable directly contains the data.
    - Assignment copies the entire data.
    - No shared state after copy.

REFERENCE TYPE (class):
    - Variable contains a reference.
    - Object is allocated on managed heap.
    - Assignment copies the reference, not the object.
    - Multiple variables can refer to the same instance.

------------------------------------------------------------------------------
6. WHY THIS MATTERS
------------------------------------------------------------------------------

A common C++ assumption:

    "Assigning an object creates an independent copy."

In C# this is TRUE only for:
    - struct
    - primitive types

It is FALSE for:
    - class

------------------------------------------------------------------------------
7. DESIGN INTENTION IN C#
------------------------------------------------------------------------------

C# intentionally separates:

    struct  → small, lightweight, value-like data
    class   → identity-based, reference-based objects

This enforces clearer architectural decisions and reduces
accidental expensive copying of large objects.

------------------------------------------------------------------------------
8. SUMMARY TABLE
------------------------------------------------------------------------------

Type in C++         | Default Semantics
---------------------------------------
struct              | value
class               | value

Type in C#          | Default Semantics
---------------------------------------
struct              | value
class               | reference

------------------------------------------------------------------------------
9. EDUCATIONAL PURPOSE OF THIS FILE
------------------------------------------------------------------------------

This file demonstrates:

    1. Primitive value copy (int)
    2. Custom struct copy
    3. Class reference sharing

The goal is to clearly understand the difference between:

    copying data
vs
    copying a reference to shared data

Mastering this distinction is fundamental for writing correct,
predictable, and safe C# code.

------------------------------------------------------------------------------
*/