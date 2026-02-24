using System;

class Program
{
    static void Main(string[] args)
    {
        // ==============================================================
        // 1. JAGGED ARRAY
        // --------------------------------------------------------------
        // An array in which each element is a separate array.
        // Each row can have a different length.
        // ==============================================================
        Console.WriteLine("\n=== JAGGED ARRAY ===");

        string[][] data2D = new string[3][];
        data2D[0] = new string[3] { "A1", "A2", "A3" };
        data2D[1] = new string[4] { "B1", "B2", "B3", "B4" };
        data2D[2] = new string[2] { "C1", "C2" };

        for (int i = 0; i < data2D.Length; i++)
        {
            Console.Write($"Row {i}: ");
            for (int j = 0; j < data2D[i].Length; j++)
            {
                Console.Write(data2D[i][j] + " ");
            }
            Console.WriteLine();
        }

        // ==============================================================
        // 2. MULTIDIMENSIONAL ARRAY
        // --------------------------------------------------------------
        // Classic rectangular array, e.g., 3x4x5.
        // All dimensions have fixed length.
        // ==============================================================
        Console.WriteLine("\n=== MULTIDIMENSIONAL ARRAY (3D) ===");

        string[,,] data3D = new string[3, 4, 5];
        data3D[0, 0, 0] = "15";
        data3D[2, 3, 4] = "X";

        for (int i = 0; i < data3D.GetLength(0); i++)
        {
            for (int j = 0; j < data3D.GetLength(1); j++)
            {
                for (int k = 0; k < data3D.GetLength(2); k++)
                {
                    if (data3D[i, j, k] != null)
                    {
                        Console.WriteLine($"[{i},{j},{k}] = {data3D[i, j, k]}");
                    }
                }
            }
        }
    }
}

/*
================================================================================
C# ADVANCED ARRAYS – JAGGED AND MULTIDIMENSIONAL
Explanation for Developers with C++ Background
================================================================================

This file demonstrates two advanced forms of arrays in C#:
1. Jagged arrays (arrays of arrays) - each row can have a different length
2. Multidimensional arrays (rectangular arrays)

------------------------------------------------------------------------------
1. JAGGED ARRAYS
------------------------------------------------------------------------------

- Syntax: type[][] arrayName;
- Each element of the outer array is itself an independent array.
- Rows can have different lengths.
- Commonly used when the data structure is irregular (e.g., triangle, varying row sizes).

C++ analogy:

- C++ supports arrays of pointers to arrays for a similar effect:
      int* arr[3];  // array of 3 pointers
      arr[0] = new int[3];
      arr[1] = new int[4];
- In C#, jagged arrays simplify this pattern and handle memory automatically.
- Common example is main function arguments: char[][] args is a jagged array of characters.

------------------------------------------------------------------------------
2. MULTIDIMENSIONAL ARRAYS
------------------------------------------------------------------------------

- Syntax: type[,,] arrayName; // for 3D, type[,] for 2D
- All dimensions have fixed length.
- Memory is contiguous for the entire array object.
- Access via array[i,j,k] (indices for each dimension).

C++ analogy:

- C++ supports true multidimensional arrays:
      int arr[3][4][5];  // rectangular 3x4x5 array
- Key difference:
    * C# arrays are objects on the managed heap
    * Bounds checking is performed at runtime
    * Automatic initialization (null for reference types)

------------------------------------------------------------------------------
3. MEMORY AND SAFETY
------------------------------------------------------------------------------

- All arrays are allocated on the managed heap.
- C# runtime enforces bounds checking, throwing IndexOutOfRangeException
  for invalid access.
- No manual memory management is required.

------------------------------------------------------------------------------
4. ITERATION
------------------------------------------------------------------------------

- Jagged array: nested loops, inner loop length may vary.
- Multidimensional array: nested loops over all dimensions using GetLength(dim).
- array.GetLength(dim) → zwraca liczbę elementów w danym wymiarze.
    dim = 0 → pierwszy wymiar (np. wiersze)
    dim = 1 → drugi wymiar (np. kolumny)
    dim = 2 → trzeci wymiar itd.
- array.Rank → zwraca liczbę wymiarów tablicy.

------------------------------------------------------------------------------
5. DESIGN CHOICES
------------------------------------------------------------------------------

- Use jagged arrays for irregular data (rows of different lengths).
- Use multidimensional arrays for regular, rectangular data (all rows same length).

------------------------------------------------------------------------------
6. SUMMARY TABLE
------------------------------------------------------------------------------

Feature                | Jagged Array (type[][]) | Multidimensional Array (type[,])
-----------------------|------------------------|--------------------------------
Allocation             | Heap (reference type)  | Heap (reference type)
Row lengths            | Each row can differ    | All dimensions fixed
Access                 | array[i][j]            | array[i,j]
Copy semantics         | Reference copy         | Reference copy
Bounds checking        | Yes                    | Yes
------------------------------------------------------------------------------
*/