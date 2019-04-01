using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Enities
{
    abstract class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        private string name;
        public string Name {
            get {
                return name;
            }
            protected set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentNullException("The name can not be empty or wade with black spaces");
                }
                name = value;
            }
        }
    }

    class Baby : Person
    {
        private List<IComforter> comforters;

        public Baby(string name) : base(name)
        {
            comforters = new List<IComforter>();
        }

        internal void StartCrying()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} ha cominciato a piangere in modo assordante");
            if (comforters.Count > 0)
            {
                foreach (IComforter p in comforters.ToList())
                {
                    p.ComfortChild(this);
                }
            }
            else
            {
                Console.WriteLine($"{Name} passa al lato oscuro e cambia nome in {Name = "Kylo Ren"}");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal void RemoveComforter(IComforter parent)
        {
            comforters.Remove(parent);
        }

        internal void AddComforter(IComforter r2d2)
        {
            comforters.Add(r2d2);
        }
    }

    abstract class Parent: Person, IComforter
    {
        public Parent(string name): base(name)
        {
        }

        public Baby Child { get; set; }

        public abstract void ComfortChild(Baby baby);
    }

    interface IComforter
    {
        void ComfortChild(Baby baby);
    }

    class Mum : Parent
    {
        public Mum(string name) : base(name)
        {
            Patience = 3;
        }

        public int Patience { get; private set; }

        public override void ComfortChild(Baby baby)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (Patience > 0)
            {
                Console.WriteLine($"{Name} prende in braccio {baby.Name} e lo culla");
                Patience--;
            }
            else
            {
                Console.WriteLine($"{Name} affida {baby.Name} allo zio Luke");
                baby.RemoveComforter(this);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal Baby MakeBaby(Dad dad, string childName)
        {
            Child = new Baby(childName);
            dad.Child = Child;
            Child.AddComforter(this);
            Child.AddComforter(dad);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name} ha fatto un figlio con {dad.Name} che si chiama {Child.Name}");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Child;
        }
    }

    class Dad : Parent
    {
        public Dad(string name) : base(name)
        {
        }

        public override void ComfortChild(Baby baby)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Name} compra un biglietto per Yavin4 e scappa");
            baby.RemoveComforter(this);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    class Robot : IComforter
    {
        public Robot(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void ComfortChild(Baby baby)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Name} genera una sequenza armonica per tranquillizzare il bambino");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
