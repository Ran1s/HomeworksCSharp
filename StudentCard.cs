using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCard
{
    class Student
    {
        string name;

        public string Name { get { return this.name; } }

        public Student(string name)
        {
            this.name = name;
        }

        public bool EnterBuilding(Building building, Card card)
        {
            return UseCard(card, building.Tourniquet);
        }

        public bool UseCard(Card card, Tourniquet tourniquet)
        {
            return tourniquet.Allow(card);
        }
    }

    class Card
    {
        int id;
        string holder;
        public int ID { get { return this.id; } }

        public Card(int id, string holder)
        {
            this.id = id;
            this.holder = holder;
        }
    }

    class Tourniquet
    {
        public bool Allow(Card card)
        {
            if (DataBase.Check(card.ID.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Building
    {
        string address;

        Tourniquet tourniquet;

        public Tourniquet Tourniquet { get { return this.tourniquet; } }
        public string Address { get { return this.address; } }

        //List<Tourniquet> tourniquets = new List<Tourniquet>();

        //public void AddTourniquet(Tourniquet tourniquet)
        //{
        //    tourniquets.Add(tourniquet);
        //}

        //public void AddTourniquet(List<Tourniquet> tourniquets)
        //{
        //    foreach (Tourniquet tourniquet in tourniquets)
        //    {
        //        tourniquets.Add(tourniquet);
        //    }            
        //}

        public Building(string address, Tourniquet tourniquet)
        {
            this.address = address;
            this.tourniquet = tourniquet;
        }

    }

    class DataBase
    {
        public static bool Check(string data)
        {
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Building dvoyka = new Building("Кремлёвская 35", new Tourniquet());
            Student petya = new Student("Петя");
            Card card = new Card(1, petya.Name);

            if (petya.EnterBuilding(dvoyka, card))
            {
                Console.WriteLine("{0} успешно ушёл вошёл в здание по адресу: {1}", petya.Name, dvoyka.Address);
            }
            else
            {
                Console.WriteLine("{0} не смог войти в здание по адресу: {1}", petya.Name, dvoyka.Address);
            }

        }
    }
}
