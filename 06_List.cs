using System;
using System.Collections.Generic; // required for List<T>

class Program
{
    static void Main(string[] args)
    {
        // ==============================================================
        // LISTS (List<T>)
        // --------------------------------------------------------------
        // A list is dynamic — you can add and remove elements.
        // Works like a "flexible array".
        // Uses the generic <T> so you can specify the element type.
        // ==============================================================
        Console.WriteLine("\n=== LIST<T> ===");

        List<string> names = new List<string>();
        names.Add("Alice");   //index 0
        names.Add("Bob");     //index 1
        names.Add("Charlie"); //index 2

        Console.WriteLine("List elements:");
        for (int i = 0; i < names.Count; i++)
        {
            Console.WriteLine($"Index {i}: {names[i]}");
        }

        names.Remove("Bob"); // remove element by value (Bob is removed and after it index 1 is now Charlie)
        names.RemoveAt(1);   // remove element by index (Charlie now has index 1)

        names.Add("Eve");      // add a new element
        names.Insert(1, "Diana");  // insert element at specific position

        names[0] = "Alice Smith"; // modify element

        Console.WriteLine("After modification:");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}

/*
================================================================================
C# LIST<T> – DYNAMIC COLLECTIONS
Explanation for Developers with C++ Background
================================================================================

This file demonstrates the use of List<T> in C#, a flexible, resizable collection
that behaves like a dynamic array. It is intended for developers familiar with C++ arrays
who want to understand how C# provides safe, dynamic alternatives.

------------------------------------------------------------------------------
1. BASIC CONCEPT
------------------------------------------------------------------------------

- List<T> is a generic collection.
- The type parameter <T> defines the type of elements.
- The list automatically resizes as elements are added or removed.
- Elements are accessed by index, similar to arrays.

C++ analogy:

- std::vector<T> is conceptually similar:
      std::vector<std::string> names;
      names.push_back("Alice");

- Key differences:
    * C# List<T> is managed by the CLR (automatic memory management)
    * Bounds checking is performed (IndexOutOfRangeException)

------------------------------------------------------------------------------
2. ADDING AND REMOVING ELEMENTS
------------------------------------------------------------------------------

- Add(T item) → append at the end
- Insert(int index, T item) → insert at a specific position
- Remove(T item) → remove by value (first occurrence)
- RemoveAt(int index) → remove by index

Example:

    names.Add("Diana");
    names.Insert(1, "Eve");
    names.Remove("Bob");
    names.RemoveAt(0);

------------------------------------------------------------------------------
3. ACCESSING AND MODIFYING ELEMENTS
------------------------------------------------------------------------------

- Access by index: names[0], names[1], ...
- Modify by index: names[0] = "Alice Smith";

- Use Count property instead of Length (like arrays)
      for (int i = 0; i < names.Count; i++) { ... }

- foreach loop is convenient for read-only iteration:
      foreach (string name in names) { ... }

------------------------------------------------------------------------------
4. VALUE VS REFERENCE SEMANTICS
------------------------------------------------------------------------------

- List<T> is a **reference type**, so copying the list variable copies the reference.
- Modifying one reference affects the same list object:

    List<string> list1 = new List<string> { "A", "B" };
    List<string> list2 = list1;
    list2.Add("C");   // list1 also contains "C"

------------------------------------------------------------------------------
5. MEMORY AND SAFETY
------------------------------------------------------------------------------

- Elements of the list are stored on the managed heap.
- Automatic resizing is handled internally.
- Bounds checking is enforced: accessing invalid indices throws exceptions.
- No manual memory management is required.

------------------------------------------------------------------------------
6. DESIGN RECOMMENDATIONS
------------------------------------------------------------------------------

- Use List<T> when the number of elements changes dynamically.
- Use arrays if the size is fixed and performance is critical.

------------------------------------------------------------------------------
7. SUMMARY TABLE
------------------------------------------------------------------------------

Feature                  | C++ std::vector<T>             | C# List<T>
-------------------------|--------------------------------|---------------------------
Allocation               | Heap (managed manually)        | Heap (managed by CLR)
Resizable                | Yes                            | Yes
Type safety              | Yes (template <T>)             | Yes (generic <T>)
Access                   | [] operator                    | [] operator
Insert/Remove            | push_back, insert, erase       | Add, Insert, Remove, RemoveAt
Bounds checking          | No (unsafe)                    | Yes (IndexOutOfRangeException)
Copy semantics           | Copying vector copies elements | Copying variable copies reference

------------------------------------------------------------------------------
*/