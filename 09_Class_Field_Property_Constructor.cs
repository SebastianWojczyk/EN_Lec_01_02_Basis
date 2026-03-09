using System;

namespace OOPDemo
{
    class AccessDemo
    {
        // FIELD (private by convention)
        private int internalCounter;

        // PUBLIC FIELD (rare in good design, shown only for demonstration)
        public string PublicField;

        // PROPERTY - automatic property with public getter and setter
        //automatically creates a hidden private field
        public string Name { get; set; }
        
        // PROPERTY WITH CUSTOM GETTERS
        public string NameUpperCase
        {
            get { return Name.ToUpper(); }
        }

        // PROPERTY WITH PRIVATE SETTER
        public int Id { get; private set; }

        // PROTECTED FIELD (visible in derived classes)
        protected int protectedValue;

        // CONSTRUCTOR
        public AccessDemo(int id, string name)
        {
            Id = id;
            Name = name;
            internalCounter = 0;
        }

        // PUBLIC METHOD
        public void Increment()
        {
            internalCounter++;
            Console.WriteLine($"Counter = {internalCounter}");
        }

        // PRIVATE METHOD (only inside this class)
        private void ResetCounter()
        {
            internalCounter = 0;
        }

        // PROTECTED METHOD (visible in derived classes)
        protected void ShowProtected()
        {
            Console.WriteLine($"Protected value: {protectedValue}");
        }

        // INTERNAL METHOD (visible only inside the same assembly)
        internal void InternalMethod()
        {
            Console.WriteLine("Internal method called.");
        }
    }

    class DerivedDemo : AccessDemo
    {
        public DerivedDemo(int id, string name) : base(id, name)
        {
            protectedValue = 10;
        }

        public void Test()
        {
            ShowProtected(); // accessible because it is protected
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AccessDemo obj = new AccessDemo(1, "Alice");

            obj.PublicField = "Example";
            obj.Increment();
            obj.InternalMethod();

            DerivedDemo d = new DerivedDemo(2, "Bob");
            d.Test();
        }
    }
}

/*
===============================================================================
FIELDS, PROPERTIES, CONSTRUCTORS AND ACCESS MODIFIERS IN C#
===============================================================================

1. FIELD
-------------------------------------------------------------------------------
A field is a variable stored inside a class.

Example:
    private int counter;

Fields usually store internal state of the object.

Convention:
Fields are typically private to preserve encapsulation.

Bad practice (usually avoided):
    public int counter;

Because it exposes internal implementation.

-------------------------------------------------------------------------------
2. PROPERTY
-------------------------------------------------------------------------------

A property is a controlled way to access data.
A property looks like a field from the outside but can have logic behind it.
It is a pair of getter and setter methods - equvalent of setter and getter in C++.s

Examples:
    public string Name { get; set; }
    public int Id { get; private set; }
    public int Name
    {
        get { return name; }
        //first lette upper case and the rest lower case
        set { name = value[0].ToString().ToUpper() + value.Substring(1).ToLower(); }
    }


This is syntactic sugar for hidden getter and setter methods.

Equivalent conceptual form:

    private string name;

    public string GetName()
    {
        return name;
    }

    public void SetName(string value)
    {
        name = value;
    }

Properties allow:

    public int Id { get; private set; }

Meaning:
- readable everywhere
- writable only inside the class

-------------------------------------------------------------------------------
3. CONSTRUCTOR
-------------------------------------------------------------------------------

Constructor is a special method executed when an object is created.

Example:

    AccessDemo obj = new AccessDemo(1, "Alice");

Constructor syntax:

    public AccessDemo(int id, string name)

Properties:
- same name as class
- no return type
- used for initialization

Constructor chaining:

    public DerivedDemo(...) : base(...)

calls constructor of the base class.

-------------------------------------------------------------------------------
4. METHODS
-------------------------------------------------------------------------------

Methods define behavior of a class.

Example:

    public void Increment()

Methods may be:

- instance methods
- static methods
- virtual / override (polymorphism)
- abstract methods

-------------------------------------------------------------------------------
5. ACCESS MODIFIERS
-------------------------------------------------------------------------------

C# provides several access modifiers controlling visibility.

PRIVATE
-------
Accessible only inside the same class.

Example:
    private int counter;

Most restrictive level.

PROTECTED
---------
Accessible inside the class AND derived classes.

Example:
    protected int value;

Used in inheritance scenarios.

PUBLIC
------
Accessible everywhere.

Example:
    public void Print()

Used for the external interface of the class.

INTERNAL
--------
Accessible only inside the same assembly (project).

Example:
    internal void Helper()

Useful for library design.

PROTECTED INTERNAL
------------------
Accessible in derived classes OR same assembly.

PRIVATE PROTECTED
-----------------
Accessible only in derived classes within the same assembly.

-------------------------------------------------------------------------------
6. ENCAPSULATION
-------------------------------------------------------------------------------

Encapsulation means hiding internal implementation details
and exposing only a controlled interface.

Example:

    private int balance;

    public void Deposit(int amount)
    {
        balance += amount;
    }

Users cannot modify "balance" directly.

-------------------------------------------------------------------------------
7. BEST PRACTICES
-------------------------------------------------------------------------------

Typical C# class design:

    private fields (encapsulated data)
    public properties (controlled access to fields)
    public and private methods (behavior outside and inside the class)
    public constructors (initialization)

Example structure:

    class Example
    {
        private int counter;

        public int Counter { get; private set; }

        public Example()
        {
        }

        public void Increment()
        {
        }
    }

This pattern ensures maintainability and safety.

-------------------------------------------------------------------------------
8. RELATION TO C++ DESIGN
-------------------------------------------------------------------------------

C# design strongly encourages:

- properties instead of public fields
- controlled access via modifiers
- strict encapsulation

===============================================================================
*/