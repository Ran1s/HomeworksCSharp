using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHumans
{
    class Human
    {
        private string name;
        private int age;

        public Human(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public Human()
        {
            this.name = "";
            this.age = 0;
        }

        public string Name { get { return this.name; } }
        public int Age { get { return this.age; } }

        public static LinkedList<Human>[] Sort(LinkedList<Human> humans)
        {
            LinkedList<Human>[] sorted = new LinkedList<Human>[200];

            for (int i = 0; i < sorted.Length; i++)
            {
                sorted[i] = new LinkedList<Human>();
            }
            
            foreach(Human human in humans)
            {
                sorted[human.Age].AddLast(human);
            }
            return sorted;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            LinkedList<Human> humans = new LinkedList<Human>();
            humans.AddLast(new Human("Petya", 13));
            humans.AddLast(new Human("Vasya", 12));
            humans.AddLast(new Human("Masha", 11));
            humans.AddLast(new Human("Katya", 5));
            humans.AddLast(new Human("Vanya", 100));
            humans.AddLast(new Human("Ildus", 12));
            humans.AddLast(new Human("Gulchachak", 11));

            LinkedList<Human>[] sortedHumans = Human.Sort(humans);

            foreach(LinkedList<Human> humansSameAge in sortedHumans)
            {
                foreach(Human human in humansSameAge)
                {
                    Console.WriteLine("Name: {0}, Age: {1}", human.Name, human.Age);
                }
            }
            
        }
    }
}
