using System;
using System.Collections.Generic; // required for List and Dictionary

class Program
{
    static void Main(string[] args)
    {
        // ==============================================================
        // ARRAYS
        // --------------------------------------------------------------
        // An array has a fixed length – you cannot increase or decrease it.
        // All elements have the same type. Indexing starts at zero.
        // ==============================================================
        Console.WriteLine("=== ARRAY ===");

        int[] numbers = new int[3]; // array with 3 elements (default value 0)
        numbers[0] = 10;
        numbers[1] = 20;
        numbers[2] = 30;

        Console.WriteLine("Array elements:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine($"Index {i}: {numbers[i]}");
        }
    }
}

/*
================================================================================
C# ARRAYS – EXPLANATION FOR DEVELOPERS WITH C++ BACKGROUND
================================================================================

This snippet demonstrates the basic usage of arrays in C#.
It is intended for developers familiar with C++ who want
to understand how C# arrays behave.

------------------------------------------------------------------------------
1. BASIC CONCEPT
------------------------------------------------------------------------------

In C#:

- An array is a reference type.
- It holds a fixed number of elements of the same type.
- The length is immutable – you cannot resize the array after creation.
- Indexing starts at zero (0).

C++ comparison:

- In C++, you can use built-in arrays:
      int numbers[3];
  These behave similarly, but:
    * They are allocated on the stack (unless dynamically allocated)
    * Passing them to functions decays them to pointers
- In C#, arrays are always objects on the managed heap.
  They store references in the variable, not the actual array data on the stack.

------------------------------------------------------------------------------
2. DECLARATION AND INITIALIZATION
------------------------------------------------------------------------------

C# syntax:

    int[] numbers = new int[3];

Explanation:

- 'int[]' specifies an array of integers.
- 'new int[3]' allocates an array with 3 elements.
- Default values:
    * numeric types → 0
    * bool → false
    * reference types → null

Assignment example:

    numbers[0] = 10;

Access is done via index:

    numbers[index]

------------------------------------------------------------------------------
3. ITERATION
------------------------------------------------------------------------------

You can iterate over arrays using:

- for loop (as shown above)

    for (int i = 0; i < numbers.Length; i++)
    {
        Console.WriteLine($"Index {i}: {numbers[i]}");
    }

- foreach loop:

    foreach (int n in numbers)
    {
        Console.WriteLine(n);
    }

Index information is sometimes required, so 'for' is commonly used.

------------------------------------------------------------------------------
4. VALUE VS REFERENCE SEMANTICS
------------------------------------------------------------------------------

Important:

- In C#, arrays are reference types.
- Assigning one array variable to another copies the reference, not the contents:

    int[] arr1 = new int[3];
    int[] arr2 = arr1;
    arr2[0] = 99;  // arr1[0] is also 99

- This differs from structs or primitive types (value types) that are copied by value.

------------------------------------------------------------------------------
5. MEMORY AND SAFETY
------------------------------------------------------------------------------

- Arrays live on the managed heap.
- The CLR ensures safe access; accessing an invalid index throws an exception (IndexOutOfRangeException).
- No manual memory management is required, unlike C++ raw arrays.

------------------------------------------------------------------------------
6. WHY THIS MATTERS
------------------------------------------------------------------------------

Understanding arrays in C# is crucial because:

1. They are reference types, so multiple variables can share the same array.
2. Fixed length requires planning.
3. Access is bounds-checked, increasing safety.
4. Arrays form the basis for many other collection types (List, Dictionary, etc.).

------------------------------------------------------------------------------
7. SUMMARY TABLE
------------------------------------------------------------------------------

Feature                | C++ Built-in Array (Compile-time) | C++ Built-in Array (Runtime / dynamic) | C# Array
-----------------------|-----------------------------------|----------------------------------------|-------------------------------
Allocation             | Stack (automatic)                 | Heap (dynamic allocation with new)     | Heap (reference type)
Length                 | Fixed (known at compile-time)     | Fixed (set at runtime)                 | Fixed (set at runtime)
Default values         | Uninitialized (garbage)           | Uninitialized (garbage)                | Initialized (0 / false / null)
Passing to function    | Decays to pointer                 | Decays to pointer                      | Reference is copied
Bounds checking        | None (unsafe)                     | None (unsafe)                          | Yes (IndexOutOfRangeException)
Resizable              | No                                | No                                     | No
------------------------------------------------------------------------------------------------------------------------------------
*/