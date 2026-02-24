using System;

namespace MyFirstNamespace
{
    // Entry point of the application.
    // This file is intentionally minimal and serves as a structural template
    // for demonstrating C# semantics (value vs reference types).
    internal class Program
    {
        // Main method – program execution starts here.
        static void Main(string[] args)
        {
            // Program entry point.
            // Add demonstration code here.

            Console.WriteLine("Demo application started.");
        }
    }
}

/*
================================================================================
C# FILE TYPE SYSTEM OVERVIEW
================================================================================

This file is intentionally minimal and serves as a structural template
for discussing fundamental differences between C# and C++ type semantics.

------------------------------------------------------------------------------
1. STRUCTURAL DIFFERENCE: PROGRAM ORGANIZATION
------------------------------------------------------------------------------

In C++:
    - Entry point: int main()
    - No required namespace
    - Free/Global functions allowed

In C#:
    - Entry point: static void Main(string[] args)
    - Code must live inside a class
    - Typically organized inside a namespace
    - No free-standing functions (everything belongs to a type)

C# enforces stronger structural organization than C++.

------------------------------------------------------------------------------
2. NAMESPACE VS C++ NAMESPACE
------------------------------------------------------------------------------

C++ namespace:
    - Rarely used for assembly organization
    - Logical grouping
    - Mostly compile-time symbol organization

C# namespace:
    - Similar concept
    - Used for assembly organization
    - Strongly integrated with project structure
    - Maps naturally to folder hierarchy

Example:
    namespace MyFirstNamespace
    {
        // Types defined here belong to MyFirstNamespace
    }

This helps avoid naming conflicts and improves architectural clarity.

------------------------------------------------------------------------------
3. MAIN METHOD DIFFERENCE
------------------------------------------------------------------------------

C++:
    int main()
    or
    int main(int argc, char* argv[])

C#:
    static void Main()
    or
    static void Main(string[] args)

Key differences:

- Must be inside a class
- Usually static
- May return void (most common) or int
- Receives command-line arguments as string[]

C# runtime (CLR - common language runtime) locates this method as the entry point.

------------------------------------------------------------------------------
4. MANAGED RUNTIME MODEL (CLR - common language runtime)
------------------------------------------------------------------------------

Unlike C++, C# runs inside the Common Language Runtime (CLR).

This means:

- Code compiles to Intermediate Language (IL)
- Memory is managed automatically
    - only new operator for object creation
    - No manual delete
    - Garbage Collector handles object lifetime

This is a fundamental architectural shift compared to C++.

------------------------------------------------------------------------------
5. VALUE VS REFERENCE SEMANTICS (CONTEXT FOR FUTURE EXTENSIONS)
------------------------------------------------------------------------------

In C++:
    struct and class both use value semantics by default.

In C#:
    struct  → value type
    class   → reference type

This file can be extended to demonstrate:

- Copying value types
- Sharing reference types
- Immutability
- Object identity vs data equality

Understanding this distinction is essential when transitioning
from C++ to C#.

------------------------------------------------------------------------------
6. DESIGN PHILOSOPHY DIFFERENCE
------------------------------------------------------------------------------

C++ philosophy:
    - Maximum control
    - Manual memory management
    - Performance transparency
    - Programmer responsible for lifetime

C# philosophy:
    - Safety first
    - Managed memory
    - Reduced accidental complexity
    - Clear separation of value and reference semantics

------------------------------------------------------------------------------
*/