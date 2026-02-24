using System;

namespace PrimitiveTypesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // ==============================================================
            // PRIMITIVE VALUE TYPES
            // --------------------------------------------------------------
            // Common value types in C#: int, double, float, decimal, bool, char
            // ==============================================================
            Console.WriteLine("=== PRIMITIVE VALUE TYPES ===");

            int i = 42;             // integer
            double d = 3.14159;     // double-precision floating-point
            float f = 2.718f;       // single-precision floating-point
            decimal m = 12345.67m;  // high-precision decimal for financial calculations
            bool b = true;           // boolean
            char c = 'X';            // character
            string s = "Hello";      // string (reference type! - description below)

            Console.WriteLine($"int: {i}");    //$"" is string interpolation, similar to C++20's std::format
            Console.WriteLine($"double: {d}");
            Console.WriteLine($"float: {f}");
            Console.WriteLine($"decimal: {m}");
            Console.WriteLine($"bool: {b}");
            Console.WriteLine($"char: {c}");
            Console.WriteLine($"string: {s}");

            // ==============================================================
            // VAR KEYWORD
            // --------------------------------------------------------------
            // var infers the type at compile-time
            // Once inferred, the type is fixed and cannot change
            // C++ analogy: auto keyword
            // overuse of var can reduce readability, so use it ONLY when its necessary!
            // ==============================================================
            Console.WriteLine("\n=== VAR KEYWORD ===");

            var x = 100;             // inferred as int
            var y = 2.718;           // inferred as double
            var z = "world";         // inferred as string
            var w = 12345.67m;       // inferred as decimal
            var fVar = 3.14f;        // inferred as float
            var bVar = false;        // inferred as bool
            var cVar = 'Z';          // inferred as char

            Console.WriteLine($"x (var): {x} ({x.GetType()})");
            Console.WriteLine($"y (var): {y} ({y.GetType()})");
            Console.WriteLine($"z (var): {z} ({z.GetType()})");
            Console.WriteLine($"w (var): {w} ({w.GetType()})");
            Console.WriteLine($"fVar (var): {fVar} ({fVar.GetType()})");
            Console.WriteLine($"bVar (var): {bVar} ({bVar.GetType()})");
            Console.WriteLine($"cVar (var): {cVar} ({cVar.GetType()})");

            // ==============================================================
            // VALUE COPY SEMANTICS
            // --------------------------------------------------------------
            // Assignment copies the value for value types
            // ==============================================================
            int a = 10;
            int b2 = a;  // copy of value
            b2 = 20;     // modifying b2 does not affect a

            decimal price1 = 99.99m;
            decimal price2 = price1; // copy of value
            price2 = 199.99m;        // price1 unaffected

            Console.WriteLine("\nValue copy example:");
            Console.WriteLine($"a = {a}, b2 = {b2}");
            Console.WriteLine($"price1 = {price1}, price2 = {price2}");

            // ==============================================================
            // REFERENCE COPY SEMANTICS
            // --------------------------------------------------------------
            // Assignment copies the reference for reference types
            // --------------------------------------------------------------
            // Strings are reference types but immutable
            // --------------------------------------------------------------
            // modifying a string variable creates a new string object,
            // leaving the original unchanged
            // ==============================================================

            string s1 = "Hello";

            string s2 = s1; // reference copy - both s1 and s2 point to the same string object "Hello"
            if(s1==s2) // true - both reference the same string object
            {
                Console.WriteLine("\nStrings s1 and s2 reference the same object.");
            }

            s2 = "World";   // original s1 not affected - assigning a new string value to s2 creates a new object, s1 still points to "Hello"
                            //Why? Because "World" is a new string literal, so s2 now references a different string object. s1 still references "Hello".
            if(s1==s2) // false - s1 still references "Hello", s2 now references "World"
            {
                Console.WriteLine("\nStrings s1 and s2 reference the same object.");
            }

            Console.WriteLine("\nString (reference but immutable) example:");
            Console.WriteLine($"s1 = {s1}");
            Console.WriteLine($"s2 = {s2}");
        }
    }
}

/*
================================================================================
C# PRIMITIVE TYPES AND VAR KEYWORD
Explanation for Developers with C++ Background
================================================================================

1. PRIMITIVE VALUE TYPES
------------------------------------------------------------------------------

- int, double, float, decimal, bool, char are value types.
- Assignment copies the value. Modifying the copy does not affect the original.
- string is a reference type but immutable in C#:
    * Copying a string copies the reference
    * Changing the variable creates a new string object, leaving the original unchanged

C++ analogy:
    int a = 10;
    int b = a; // copy, same semantics
    std::string s1 = "Hello";
    std::string s2 = s1; // copy by value, independent in C++

- decimal is a value type for high-precision calculations (28–29 digits).
- float uses less memory, double has standard floating-point precision.

------------------------------------------------------------------------------
2. VAR KEYWORD
------------------------------------------------------------------------------

- 'var' allows compile-time type inference.
- Type is fixed once inferred; cannot change later.
- C++ analogy: auto keyword

Example:
    var x = 42;    // inferred as int
    auto x = 42;   // C++ equivalent

------------------------------------------------------------------------------
3. VALUE VS REFERENCE SEMANTICS
------------------------------------------------------------------------------

- Value types (int, double, float, decimal, bool, char) are copied by assignment
- Reference types (string, objects) copy the reference
- Strings are reference types but immutable:
      string s1 = "Hello";
      string s2 = s1;
      s2 = "World"; // s1 remains "Hello"

------------------------------------------------------------------------------
4. DESIGN NOTES
------------------------------------------------------------------------------

- Use 'var' for simplicity when type is unknown or difficult to write, but prefer explicit types for readability
- decimal is preferred for money/financial calculations

------------------------------------------------------------------------------
5. SUMMARY TABLE
------------------------------------------------------------------------------

Type          | C++ analogy       | C# behavior
--------------|-----------------|---------------------------
int           | int              | value type, copied on assignment
double        | double           | value type, copied on assignment
float         | float            | value type, copied on assignment
decimal       | ---              | value type, copied on assignment, high precision
bool          | bool             | value type, copied on assignment
char          | char             | value type, copied on assignment
string        | std::string      | reference type, immutable
var           | auto             | compile-time type inference
Assignment    | =                | copies value (value types) or reference (reference types)

------------------------------------------------------------------------------
*/