using System;
using System.Collections.Generic;   // import this if you want to use lists

// write "cw" then press tab to write Console.WriteLine() easily

namespace ConsoleApplication1
{
    enum Breed { Bulldog, Boxer, Border_Collie };

    class Animal
    {
        // CLASS VARIABLES

        public static int Count = 0;       // you can give variables a default value here, or in class constructor

        public string name;
        public int age;
        public float happiness;

        private int a;          // can only be accessed from the same class
        public int b;           // can be accessed from other classes through class reference
        static int c;           // not bound to one instance, but shared through all instances of the same kind of class
        int d;                  // dafaults to private


        // CLASS CONSTRUCTORS

        public Animal()
        {
            name = "Beni";
            age = 3;
            happiness = 0.5f;

            Count++;
        }

        public Animal(string _name, int _age, float _happiness)
        {
            name = _name;
            age = _age;
            happiness = _happiness;

            Count++;
        }


        // CLASS METHODS 

        public void Print()
        {
            Console.WriteLine("Name: {0}\nAge: {1}\nHappiness: {2}", name, age, happiness);
        }
        
    }
    
        class Dog : Animal
        {
            public int loudness = 1;
            public Breed breed;

            public Dog()
            {
                name = "Beni";
                age = 3;
                happiness = 0.5f;
                Count++;
            }

            public Dog(string _name, int _age, float _happiness, Breed _breed)
            {
                name = _name;
                age = _age;
                happiness = _happiness;
                breed = _breed;
            }

            public void Bark()
            {
                for (int i = 0; i < loudness; i++)
                    Console.Write("WUF! ");
                Console.WriteLine();
                base.happiness += 0.1f;     // if we have an inherited variable, but the class has it's own variable with the same name, thisway we can access the inherited one
            }

            public void Print()
            {
                base.Print();                                           // using base method instead of the new method
                Console.WriteLine("Breed: {0}", breed);
            }
    }       // I used tab to emphasize that it's a child of the Animal Class

        class Cat : Animal
            {
                public float cuteness = 0.5f;

                public void Meow()
                {
                    Console.WriteLine("Meooow!");
                }
            }

    class Player            // this is a demo class for PROPERTIES
    {
        private int _health = 100;
        public int health
        /*
         It ensures that health is always a valid value
         Let's assume that a valid health is between 0 and 100
        */
        {
            get
            {
                return _health;
            }
            set
            {
                if(value<=0) {
                    _health = 0;
                } else if(value>=100) {
                    _health = 100;
                } else {
                    _health = value;
                }
            }
        }


        public void Damage(int _dmg)
        {
            _health -= _dmg;
        }
    }

    class MainClass
    {
        static void Main(string[] args)
        {
            // CHOSE THE FUNCTION HERE:
            int choice = 9;

            Breakpoint:
            switch (choice)
            {
                case 1:
                    random(true);                                           break;
                case 2:
                    arrays();                                               break;
                case 3:
                    lists();                                                break;
                case 4:
                    multi_dimensional_arrays();                             break;
                case 5:
                    classes();                                              break;
                case 6:
                    classes_with_constructor();                             break;
                case 7:
                    inheritance();                                          break;
                case 8:
                    enums();                                                break;
                case 9:
                    properties();                                           break;
                default:
                    Console.WriteLine("Undefined case, try again.");        break;
            }

            Console.WriteLine("\nPress Enter to start again!");
            if (Console.ReadLine() == "") goto Breakpoint;
        }

        static int random(bool output = false) // you can set default values in case of no parameter is passed
        {

            Random Generator = new Random();
            int n, m;

            n = Generator.Next(1, 101);
            m = Generator.Next(1, 101);
            if(output) Console.WriteLine("Your numbers are: {0} and {1}.", n, m);

            return n;
        }

        static void arrays()
        {
            int[] numbers = new int[10];
            numbers[0] = 5; numbers[1] = 7; numbers[2] = 8; numbers[4] = 4;

            foreach(int number in numbers)
                Console.Write(number + ", ");
            
            // OR with a for loop:
            for(int i = 0; i<numbers.Length; i++)         // access the number of elements by ".Length"
                Console.Write(numbers[i] + ", ");
            
            
            string[] names = new string[4] { "Luke", "Hann", "R2D2", "C3PO" };
            foreach(string name in names)
                Console.Write(name + ", ");
            
        }

        static void lists()
        {
            List<int> numbers = new List<int>();
            numbers.Add(13); numbers.Add(4); numbers.Add(7);

            foreach (int number in numbers)
                Console.Write(number + ", ");

            // OR with a for loop:
            for (int i = 0; i < numbers.Count; i++)
                Console.Write(numbers[i] + ", ");

            numbers.RemoveAt(1);    // removes the i+1 th element
            numbers.Remove(13);     // removes the first element with value =13
        }

        static void multi_dimensional_arrays()
        {
            Random randGen = new Random();

            int width = 5,
                height = 5;

            int[,] grid = new int[width, height];       // C#-y way to create an array
            int[][] grid2 = new int[width][];           // jagged array

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    grid[i, j] = randGen.Next(1, 51);

            int x = 0;
            foreach (int i in grid)   // a trick to use FOREACH and still be able to print a matrix
            {
                if (x % width == 0  &&  x != 0)   // use X variable to determine the ends of lines
                    Console.Write("\n");

                Console.Write(i + "\t");
                x++;
            }
        }

        static void classes()
        {
            Animal dog = new Animal();      // creating a new instance
            Animal.Count++;
            Console.WriteLine(dog.name);

            dog.name = "Doctor";            // you can simply set it equal to things
            Console.WriteLine(dog.name);

            dog.Print();                    // calling a method from class

            Animal cat = new Animal();
            Animal.Count++;

            Console.WriteLine("Number of animals: {0}. This line no longer works thanks to modifications in the animal class. ", Animal.Count);
        }

        static void classes_with_constructor()
        {
            Animal dog = new Animal("Dragon", 10, 0.9f);
            Animal cat = new Animal("Linsy", 4, 0.7f);

            dog.Print();
            cat.Print();

            Console.WriteLine("Number of animals: {0}", Animal.Count);
        }

        static void inheritance()
        {
            Dog spotty = new Dog();
            spotty.name = "Spotty";     spotty.age = 6;     spotty.happiness = 0.8f;     spotty.loudness = 3;
            spotty.Bark();
            Console.WriteLine("New happyness: {0}", spotty.happiness);

            Cat heisenberg = new Cat();
            heisenberg.name = "Heisenberg";     heisenberg.age = 9;     heisenberg.happiness = 0.3f;    heisenberg.cuteness = 0.4f;
            heisenberg.Meow();

        }

        static void enums()
        {
            // THE ENUM IS CREATED upp after defining the Main class

            Dog hulk = new Dog("Hulk", 10, 0.8f, Breed.Bulldog);
            hulk.Print();
        }

        static void properties()
        {
            DateTime current_time = DateTime.Now;        // { Get; }   means it's a read only property
            Console.WriteLine(current_time);


            Player hero = new Player();                  // player has a hidden _health and an exposed method health
            hero.Damage(30);
            Console.WriteLine(hero.health);
            hero.health = 300;
            Console.WriteLine(hero.health);
            hero.health -= 200;
            Console.WriteLine(hero.health);


        }
    }
}