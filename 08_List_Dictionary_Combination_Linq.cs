using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // ==============================================================
        // NESTED DICTIONARY WITH LISTS
        // --------------------------------------------------------------
        // Structure:
        // - Outer key: student name (e.g., "John")
        // - Inner key: subject name (e.g., "Programming")
        // - Value: list of grades (List<int>)
        // ==============================================================
        Console.WriteLine("=== NESTED DICTIONARY WITH LISTS ===");

        // CREATE A COMPLEX STRUCTURE USING 'new' FOR EACH LEVEL
        Dictionary<string, Dictionary<string, List<int>>> grades = new Dictionary<string, Dictionary<string, List<int>>>();

        // Adding first student
        grades["John"] = new Dictionary<string, List<int>>();       // new inner dictionary for John's subjects
        grades["John"]["Programming"] = new List<int> { 5, 5 };      // new list for Programming grades
        grades["John"]["Networking"] = new List<int> { 3, 4, 5 };   // new list for Networking grades

        // Adding second student
        grades["Emily"] = new Dictionary<string, List<int>>();       // new inner dictionary for Emily's subjects
        grades["Emily"]["Programming"] = new List<int> { 4, 4, 5 }; // new list for Programming grades
        grades["Emily"]["Databases"] = new List<int> { 5, 5, 4 };       // new list for Databases grades

        // use helper method to add grades without repeating 'new' logic
        addGrade(grades, "Emily", "Programming", 3); // helper method to add grade  
        
        // Display data
        //foreach (var student in grades.where(s => s.Key.StartsWith("A"))) // filter students by name starting with 'J'
        foreach (var student in grades)
        {
            Console.WriteLine($"\nStudent: {student.Key}");
            
            foreach (var subject in student.Value)
            {
                foreach (var grade in subject.Value)
                {
                    Console.WriteLine($"  Subject: {subject.Key} -> Grade: {grade}");
                }
                Console.WriteLine($"    Count for {subject.Key}: {subject.Value.Count}"); // count number of grades for subject
                Console.WriteLine($"    Average for {subject.Key}: {subject.Value.Average()}"); // calculate average grade for subject
            }
        }
        foreach (var student in grades)
        {
            Console.WriteLine($"\nStudent: {student.Key}");
            
            foreach (var subject in student.Value)
            {
                foreach (var grade in subject.Value)
                {
                    Console.WriteLine($"  Subject: {subject.Key} -> Grade: {grade}");
                }
                Console.WriteLine($"    Count for {subject.Key}: {subject.Value.Count()}");// count number of grades for subject by using LINQ Count() method
                Console.WriteLine($"    Average for {subject.Key}: {subject.Value.Average()}"); // calculate average grade for subject by using LINQ Average() method
            }
        }
    }
    static private void addGrade(Dictionary<string, Dictionary<string, List<int>>> grades, string studentName, string subjectName, int grade)
    {
        if(!grades.ContainsKey(studentName))
        {
            grades[studentName] = new Dictionary<string, List<int>>();
        }
        if(!grades[studentName].ContainsKey(subjectName))
        {
            grades[studentName][subjectName] = new List<int>();
        }
        if (grades.ContainsKey(studentName) && grades[studentName].ContainsKey(subjectName))
        {
            grades[studentName][subjectName].Add(grade);
        }
    }
}

/*
================================================================================
C# COMBINED COLLECTIONS: LISTS AND DICTIONARIES
Using 'new' to create nested structures
================================================================================

1. CREATING A NESTED DICTIONARY WITH LISTS
------------------------------------------------------------------------------

- To create a nested structure like Dictionary<string, Dictionary<string, List<int>>>, 
  you need to explicitly instantiate each level with 'new':

      Dictionary<string, Dictionary<string, List<int>>> grades = new Dictionary<string, Dictionary<string, List<int>>>();
      grades["John"] = new Dictionary<string, List<int>>();       // inner dictionary
      grades["John"]["Programming"] = new List<int> { 5, 5 };      // list of grades

- Explanation:
    * Outer dictionary stores student names
    * Each student gets a new dictionary (inner) for subjects
    * Each subject gets a new List<int> for grades

- Key point:
    * In C#, **reference types must be instantiated with 'new'** before use
    * Otherwise, accessing them results in NullReferenceException

------------------------------------------------------------------------------
2. C++ ANALOGY
------------------------------------------------------------------------------

- In C++, similar structure can be created with STL:

      std::map<std::string, std::map<std::string, std::vector<int>>> grades;
      grades["John"]["Programming"].push_back(5);

- Differences:
    * In C++, default constructors are invoked automatically
    * No explicit 'new' required for each nested container
    * In C#, you must call 'new' for each level (dictionary/list)

------------------------------------------------------------------------------
3. VALUE VS REFERENCE SEMANTICS
------------------------------------------------------------------------------

- All dictionaries and lists are reference types in C#.
- Copying a variable only copies the reference:

      var copy = grades;
      copy["John"]["Programming"].Add(6); // affects original

------------------------------------------------------------------------------
4. DESIGN NOTES
------------------------------------------------------------------------------

- This pattern ('new', 'new', 'new') is common for building hierarchical collections
- Use loops or helper methods if creating many students or subjects
- Always ensure each level is initialized with 'new' before accessing

------------------------------------------------------------------------------
5. SUMMARY
------------------------------------------------------------------------------

Feature                     | C++ analogy                          | C# implementation
----------------------------|--------------------------------------|----------------------------
Nested collections          | std::map<std::string,std::vector>    | Dictionary<string,List<T>>
Reference semantics         | vector/map value vs pointer          | Reference types (modification affects all references)
Initialization required     | STL auto-initialize containers       | Must use 'new' for each level
Iteration                   | iterators                            | foreach / for loops
------------------------------------------------------------------------------------------------
6.  LINQ – LANGUAGE INTEGRATED QUERY
------------------------------------------------------------------------------

- LINQ (Language Integrated Query) is a built-in set of methods and syntax
  that allows easy filtering, sorting, grouping, and aggregating data
  in C# collections (e.g., List<T>, Dictionary<K,V>, arrays, IEnumerable<T>).

- To use LINQ, include:
      using System.Linq;

- Common LINQ methods:

    * Count() – counts the number of elements
        List<int> numbers = new List<int> { 1, 2, 3 };
        int count = numbers.Count(); // 3

    * Where(predicate) – filters a collection
        var bigNumbers = numbers.Where(n => n > 1);
        // result: 2,3

    * Average() – computes the average value
        double avg = numbers.Average(); // 2.0

    * Select(func) – projects values
        var doubled = numbers.Select(n => n * 2); // 2,4,6
    * OrderBy(keySelector) – sorts a collection
        var sorted = numbers.OrderBy(n => n); // 1,2,3
    * GroupBy(keySelector) – groups elements by a key
        var groups = numbers.GroupBy(n => n % 2 == 0 ? "Even" : "Odd");
        // groups: "Even" -> 2, "Odd" -> 1,3
-------------------------------------------------------------------------------
7. LINQ WITH NESTED DICTIONARY
-------------------------------------------------------------------------------

Practical examples on our `grades` Dictionary:

    // Filter students whose name starts with "E"
    var eStudents = grades.Where(s => s.Key.StartsWith("E"));

    // Count of grades for "Programming" subject for "Emily"
    int countProg = grades["Emily"]["Programming"].Count();

    // Average grade for "Programming" subject for "Emily"
    double avgProg = grades["Emily"]["Programming"].Average();

    // Flatten all "Programming" grades for all students
    var allProgGrades = grades.SelectMany(
        s => s.Value.Where(sub => sub.Key == "Programming")
                    .SelectMany(sub => sub.Value)
    );

- LINQ makes processing complex data structures more readable
-------------------------------------------------------------------------------
*/