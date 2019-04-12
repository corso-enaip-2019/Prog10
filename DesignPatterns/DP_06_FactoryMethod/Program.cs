using System;

namespace DP_06_FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.Write("Forma desiderata? ");
                Shape s = GetShape(Console.ReadLine());
                s.AskValue();
                Console.WriteLine($"{nameof(s)} area: {s.GetArea().ToString("#.00")} perimetro: {s.GetPerimeter().ToString("#.00")}");

                Console.ReadKey(); 
            }
        }

        /// <summary>
        /// QUESTO é UN FACTORY METHOD
        /// </summary>
        /// <param name="shapeName"></param>
        /// <returns></returns>
        static Shape GetShape(string shapeName)
        {
            switch (shapeName) {
                case "circle":
                    return new Circle();
                case "rectangle":
                    return new Rectangle();

                default:
                    throw new NotImplementedException("Shape not still existing!");
            }
        }

    }

    abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract void AskValue();

        protected double AskValue(string message)
        {
            Console.Write(message);
            while (true) {
                if (double.TryParse(Console.ReadLine(), out double value)) {
                    return value;
                }
                Console.WriteLine("Valore invalido, reinserisci: ");
            }
        }
    }

    class Circle : Shape
    {
        public double Radius { get; set; }

        public override void AskValue()
        {
            Radius = AskValue("Raggio: ");
        }

        public override double GetArea()
        {
            return Math.PI * (Math.Pow(Radius, 2));
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override void AskValue()
        {
            Width = AskValue("Larghezza: ");
            Height = AskValue("Altezza: ");
        }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetPerimeter()
        {
            return (Width + Height) * 2;
        }
    }
}
