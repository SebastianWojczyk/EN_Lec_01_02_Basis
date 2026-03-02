using System;
using System.Collections.Generic; // required for Dictionary<TKey, TValue>

class Program
{
    static void Main(string[] args)
    {
        // ==============================================================
        // DICTIONARY (Dictionary<TKey, TValue>)
        // --------------------------------------------------------------
        // A dictionary stores key-value pairs.
        // Keys are unique, and values can be easily retrieved by key.
        // ==============================================================
        Console.WriteLine("\n=== DICTIONARY<TKey, TValue> ===");

        Dictionary<string, int> ages = new Dictionary<string, int>();
        ages.Add("Alice", 25);
        ages["Bob"] = 30;
        ages["Charlie"] = 35;

        Console.WriteLine("Dictionary elements:");
        foreach (KeyValuePair<string, int> pair in ages)
        {
            Console.WriteLine($"{pair.Key} -> {pair.Value}");
        }

        // Check if a key exists:
        if (ages.ContainsKey("Alice"))
        {
            Console.WriteLine($"\nAlice is {ages["Alice"]} years old.");
        }

        // Add a new element or modify existing one:
        ages["Diana"] = 28;

        // Remove an element by key:
        ages.Remove("Bob");

        Console.WriteLine("\nAfter modification:");
        foreach (KeyValuePair<string, int> pair in ages)
        {
            Console.WriteLine($"{pair.Key} -> {pair.Value}");
        }
        foreach (var air in ages)
        {
            Console.WriteLine($"{air.Key} -> {air.Value}");
        }
    }
}

/*
================================================================================
C# DICTIONARY<TKey, TValue> – KEY-VALUE COLLECTIONS
Explanation for Developers with C++ Background
================================================================================

This file demonstrates the use of Dictionary<TKey, TValue> in C#.
A dictionary is a generic collection that stores key-value pairs
with fast lookup by key.

------------------------------------------------------------------------------
1. BASIC CONCEPT
------------------------------------------------------------------------------

- Dictionary<TKey, TValue> is a generic type.
- TKey defines the type of the key (values must be unique).
- TValue defines the type of the value.
- Provides fast retrieval of values based on keys.

C++ analogy:

- std::map<Key, Value> or std::unordered_map<Key, Value> from the STL
  are very similar:
      std::map<std::string,int> ages;
      ages["Alice"] = 25;

- Differences in C#:
    * Dictionary<TKey,TValue> is reference type, allocated on the managed heap
    * Automatic memory management
    * Built-in methods for checking existence, adding, removing elements

------------------------------------------------------------------------------
2. ADDING AND REMOVING ELEMENTS
------------------------------------------------------------------------------

- Add a new key-value pair: ages.add("Alice", 25);
- Add also works with indexer syntax: ages["Diana"] = 28;

- Modify existing value: ages["Alice"] = 26;

- Remove a key: ages.Remove("Bob");

- Key must be unique. Adding a duplicate key throws an exception.
- Use ContainsKey() to check existence before adding.

------------------------------------------------------------------------------
3. ITERATION
------------------------------------------------------------------------------

- Use foreach over KeyValuePair<TKey, TValue>:
      foreach (KeyValuePair<string,int> pair in ages) { ... }

- KeyValuePair contains:
      pair.Key
      pair.Value

- You can also iterate over Keys or Values collections:
      foreach (string key in ages.Keys) { ... }
      foreach (int value in ages.Values) { ... }

------------------------------------------------------------------------------
4. VALUE VS REFERENCE SEMANTICS
------------------------------------------------------------------------------

- Dictionary<TKey, TValue> is a reference type.
- Assigning one dictionary variable to another copies the reference:

      var d1 = new Dictionary<string,int>();
      var d2 = d1;
      d2["X"] = 42;  // affects d1 as well

- This is different from value types (structs, primitives).

------------------------------------------------------------------------------
5. MEMORY AND SAFETY
------------------------------------------------------------------------------

- Automatically resizes as elements are added.
- Safe access: bounds and key checks, no undefined behavior like in C++ raw arrays.

------------------------------------------------------------------------------
6. DESIGN RECOMMENDATIONS
------------------------------------------------------------------------------

- Use Dictionary<TKey,TValue> when you need **fast key-based lookup**.
- Use it when keys are unique and you want to associate values with them.

------------------------------------------------------------------------------
8. SUMMARY TABLE
------------------------------------------------------------------------------

Feature                  | C++ std::map / std::unordered_map | C# Dictionary<TKey,TValue>
-------------------------|-----------------------------------|----------------------------------
Key uniqueness           | Yes                               | Yes
Insertion/removal        | Yes                               | Yes
Iteration                | iterator                          | foreach KeyValuePair/Keys/Values
Reference type           | No (value type)                   | Yes
Bounds checking          | Manual                            | Automatic
------------------------------------------------------------------------------------------------
*/