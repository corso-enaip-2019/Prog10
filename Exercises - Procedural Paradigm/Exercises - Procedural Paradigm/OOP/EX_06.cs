using PlugInSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_Procedural_Paradigm.OOP
{
    class EX_06 : AExercise
    {
        public override string Description => "SmartPhones";

        public override Version VersionNumber => new Version(6, 0);

        public override void Run(IGUI guiHandler)
        {
            List<Smartphone> smartphones = InitMockList();

            guiHandler.PrintList(smartphones, "Telefoni disponibili", true);
            guiHandler.WriteMessage();

            //var grayPhones = smartphones.FilterBy(new FilterByColor(Color.DarkGray));
            var grayPhones = smartphones.FilterBy(x => x.Color == Color.DarkGray);
            guiHandler.PrintList(grayPhones, "Telefoni grigi", true);
            guiHandler.WriteMessage();

            //var economicPhones = smartphones.FilterBy(new FilterByCost(300m));
            var economicPhones = smartphones.FilterBy(x => x.Cost < 300m);
            guiHandler.PrintList(economicPhones, "Telefoni sotto i 300€", true);
        }

        List<Smartphone> InitMockList()
        {
            List<Smartphone> list = new List<Smartphone>()
            {
                new Smartphone(){ Model = "OnePlus", Version = 2, Cost = 299.99m, Color = Color.DarkGray},
                new Smartphone(){ Model = "Mi A2", Version = 2, Cost = 249.99m, Color = Color.Red},
                new Smartphone(){ Model = "Galaxy", Version = 10, Cost = 849.99m, Color = Color.Aquamarine},
                new Smartphone(){ Model = "Nokia 7", Version = 7, Cost = 399.99m, Color = Color.Yellow},
            };
            return list;
        }
    }

    class Smartphone : IColored, IPriced
    {
        public string Model { get; set; }
        public int Version { get; set; }
        public decimal Cost { get; set; }
        public Color Color { get; set; }

        public override string ToString()
        {
            return $"Model: {Model}; Version: {Version}; Price: {Cost}; Color: {Color}";
        }
    }

    #region Interface system
    interface IPriced
    {
        decimal Cost { get; set; }
    }

    interface IColored
    {
        Color Color { get; set; }
    }

    interface IFilter<T>
    {
        bool Filter(T item);
    }

    static class Extensions
    {
        public static IEnumerable<T> FilterBy<T>(this IEnumerable<T> input, IFilter<T> condition)
        {
            List<T> output = new List<T>();
            foreach (var item in input)
            {
                if (condition.Filter(item))
                {
                    output.Add(item);
                }
            }
            return output;
        }
    }

    class FilterByColor : IFilter<IColored>
    {
        Color _color;
        public FilterByColor(Color color)
        {
            _color = color;
        }

        public bool Filter(IColored item)
        {
            return (item.Color == _color);
        }
    }

    class FilterByCost : IFilter<IPriced>
    {
        decimal _maxPrice;

        public FilterByCost(decimal maxPrice)
        {
            _maxPrice = maxPrice;
        }

        public bool Filter(IPriced item)
        {
            return (item.Cost < _maxPrice);
        }
    }
    #endregion Interface system

    /// ###############
    /// DELEGATE SYSTEM 
    /// ###############

    delegate bool Filter<TInput>(TInput item);

    static class Filters
    {
        public static IEnumerable<T> FilterBy<T>(this IEnumerable<T> input, Filter<T> filter)
        {
            List<T> output = new List<T>();

            foreach (var item in input)
            {
                if (filter(item))
                    output.Add(item);
            }

            return output;
        }
    }
}
