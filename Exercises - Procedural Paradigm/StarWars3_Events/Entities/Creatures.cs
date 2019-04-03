using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace StarWars3_Events.Entities
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
        protected ConsoleColor TextColor = ConsoleColor.Gray;

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

        public bool DarkSide = false;
        public event ComfortBaby StartedCrying;

        int CryCounter = 20;

        public Baby(string name) : base(name)
        {
            TextColor = ConsoleColor.Green;
            GenerateRandomTimer();
        }

        private void GenerateRandomTimer()
        {
            Timer timer = new Timer(new Random().Next(1, 10) * 1000);
            timer.AutoReset = false;
            timer.Elapsed += StartCrying;
            timer.Start();
        }

        private void StartCrying(object sender, ElapsedEventArgs e)
        {
            if (CryCounter > 0)
            {
                Console.WriteLine("---");
                Console.ForegroundColor = TextColor;
                Console.WriteLine($"{Name} ha cominciato a piangere in modo assordante");
                if (StartedCrying != null)
                {
                    StartedCrying(this);
                    if (StartedCrying.GetInvocationList().Count() <= 0)
                    {
                        ConvertToDarkSide();
                    }
                }
                //GenerateRandomTimer();                
                CryCounter--;
                if (CryCounter < 5)
                {
                    ConvertToDarkSide();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                GenerateRandomTimer();
            }
        }

        private void ConvertToDarkSide()
        {
            TextColor = ConsoleColor.Red;
            Console.ForegroundColor = TextColor;
            if (!DarkSide)
            {
                Console.WriteLine($"{Name} passa al lato oscuro e cambia nome in {Name = "Kylo Ren"}");
                CryCounter = 1;
                DarkSide = true;
            }
            if (CryCounter <= 0)
            {
                Console.WriteLine($"{Name} ora è cattivo e non piagerà mai più!");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
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

    class Uncle: Person
    {
        public Uncle(string name): base(name)
        {
            Patience = 2;
            TextColor = ConsoleColor.DarkGreen;
        }
        public int Patience { get; private set; }

        public void Educate(Baby baby)
        {
            Console.ForegroundColor = TextColor;
            if (Patience > 0)
            {
                Console.WriteLine($"{Name} prova a trasmettere insegnamenti Jedi a {baby.Name}");
                Patience--;
            }
            else
            {
                Console.WriteLine($"{Name} si è stufato e cerca di uccidere {baby.Name}");
                baby.StartedCrying -= Educate;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    class Mum : Parent
    {
        public Mum(string name) : base(name)
        {
            Patience = 3;
            TextColor = ConsoleColor.Magenta;
        }

        public int Patience { get; private set; }

        public override void ComfortChild(Baby baby)
        {
            Console.ForegroundColor = TextColor;
            if (Patience > 0)
            {
                Console.WriteLine($"{Name} prende in braccio {baby.Name} e lo culla");
                Patience--;
            }
            else
            {
                Console.WriteLine($"{Name} affida {baby.Name} allo zio Luke");
                Uncle luke = new Uncle("Luke Skywalker");
                baby.StartedCrying += luke.Educate;
                baby.StartedCrying -= ComfortChild;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal Baby MakeBaby(Dad dad, string childName)
        {
            Child = new Baby(childName);
            dad.Child = Child;
            Child.StartedCrying += ComfortChild;
            Child.StartedCrying += dad.ComfortChild;

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
            TextColor = ConsoleColor.Cyan;
        }

        public override void ComfortChild(Baby baby)
        {
            Console.ForegroundColor = TextColor;
            Console.WriteLine($"{Name} compra un biglietto per Yavin4 e scappa");
            baby.StartedCrying -= ComfortChild;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    class Robot
    {
        protected ConsoleColor TextColor = ConsoleColor.DarkYellow;
        public Robot(string name)
        {
            Name = name;
            Patience = 8;
        }

        public string Name { get; }
        public int Patience { get; private set; }

        public void Comfort(Baby baby)
        {
            if (Patience > 0)
            {
                Console.ForegroundColor = TextColor;
                Console.WriteLine($"{Name} genera una sequenza armonica per tranquillizzare {baby.Name}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Patience--;
            }
            else
            {
                Console.ForegroundColor = TextColor;
                Console.WriteLine($"{Name} si è definitivamente stufato! Da la scossa a {baby.Name} e se ne va!");
                Console.ForegroundColor = ConsoleColor.Gray;
                baby.StartedCrying -= Comfort;
            }
        }

        public void Comfort(Dad dad)
        {
            Console.ForegroundColor = TextColor;
            Console.WriteLine($"{Name} da una leggera scossa di conforto a {dad.Name}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Comfort(Mum mum)
        {
            Console.ForegroundColor = TextColor;
            Console.WriteLine($"{Name} cinguetta cose dolci a {mum.Name}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
