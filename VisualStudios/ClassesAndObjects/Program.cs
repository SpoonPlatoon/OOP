using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class Color
    {
        public float r, g, b;
    }
    class Dog
    {
        public string name;
        public int size;
        public string breed;
        public ConsoleColor color;

        private string LastEatenFood;

        public void Eat(string food)
        {
            LastEatenFood = food;
            Console.ForegroundColor = color;
            Console.WriteLine(name + " is eating " + food);
        }
        public void Sleep()
        {
            Console.WriteLine(name + " is sleeping");
        }
        public void Shit()
        {
            Console.WriteLine(name + " is shitting " + LastEatenFood);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Color red = new Color();
            red.r = 1;
            red.g = 0;
            red.b = 0;
            // Create instance of Dog
            Dog dog1 = new Dog();
            // Set properties of instance
            dog1.name = "Lassie";
            dog1.size = 2;
            dog1.breed = "Dalmation";
            dog1.color = ConsoleColor.Cyan;

            Dog dog2 = new Dog();
            // Set properties of instance
            dog2.name = "Rodney";
            dog2.size = 2;
            dog2.breed = "Rat";
            dog2.color = ConsoleColor.Green;

            dog2.Eat("Himself");
            dog2.Shit();

            dog1.Eat(dog2.name);
            dog1.Shit();

            Console.ReadLine();
        }
    }
}
