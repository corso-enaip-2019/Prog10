using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars2_Delegates.Entities
{
    delegate void ComfortBaby(Baby baby);

    static class TheForce
    {
        static public void ComfortChild(Baby baby)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"La forza mostra a {baby.Name} il fantasma di Obi-Wan Kenobi.");
            if (baby.DarkSide)
            {
                Console.WriteLine($"Ma ormai è troppo tardi.");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name can not be empty or wade with black spaces");
                }
                name = value;
            }
        }
    }

    class Baby : Person
    {
        private List<ComfortBaby> comforters;
        public bool DarkSide = false;

        public Baby(string name) : base(name)
        {
            comforters = new List<ComfortBaby>();
        }

        internal void StartCrying()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} ha cominciato a piangere in modo assordante");
            if (comforters.Count > 0)
            {
                foreach (ComfortBaby cb in comforters.ToList())
                {
                    cb(this);
                }
            }
            else
            {
                Console.WriteLine($"{Name} passa al lato oscuro e cambia nome in {Name = "Kylo Ren"}");
                DarkSide = true;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal void RemoveComforter(ComfortBaby cb)
        {
            comforters.Remove(cb);
        }

        internal void AddComforter(ComfortBaby cb)
        {
            comforters.Add(cb);
        }
    }

    abstract class Parent : Person
    {
        public Parent(string name) : base(name)
        {
        }

        public Baby Child { get; set; }

        public abstract void ComfortChild(Baby baby);
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
                baby.RemoveComforter(ComfortChild);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal Baby MakeBaby(Dad dad, string childName)
        {
            Child = new Baby(childName);
            dad.Child = Child;
            Child.AddComforter(ComfortChild);
            Child.AddComforter(dad.ComfortChild);

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
            baby.RemoveComforter(ComfortChild);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    class Robot
    {
        public Robot(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Comfort(Baby baby)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Name} genera una sequenza armonica per tranquillizzare il bambino");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Comfort(Dad dad)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Name} da una leggera scossa di conforto a {dad.Name}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        
        public void Comfort(Mum mum)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Name} cinguetta cose dolci a {mum.Name}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
