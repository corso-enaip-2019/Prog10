using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaRucola = new PizzaBuilder(PizzaBase.Tomato)
                .AddMozzarella()
                .AddHam()
                .AddRocketSalad()
                .Create();

            var pizzaChips = new PizzaBuilder(PizzaBase.White)
                .AddMozzarella()
                .AddChips()
                .Create();

            var pizzaHawaii = new PizzaBuilder(PizzaBase.Tomato)
                .AddMozzarella()
                .AddHam()
                .AddAnanas()
                .Create();

            Console.Read();
        }
    }

    enum PizzaBase
    {
        White,
        Tomato
    }

    enum IngredientType
    {
        Tomato,
        Mozzarella,
        Ham,
        Mushroom,
        RocketSalad,
        Chips,
        Ananas,
    }

    class Ingredient
    {
        public IngredientType Type { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Ingrediend type: {Type}, quantity: {Quantity}";
        }
    }

    class Pizza
    {
        PizzaConfiguration _config;
        bool _isMignon;
        public Pizza(PizzaBase baseType, bool isMignon)
        {
            Ingredients = new List<Ingredient>();
            _config = PizzaConfiguration.Configurations[isMignon];
            _isMignon = isMignon;
            switch (baseType) {
                case PizzaBase.Tomato:
                    Ingredients.Add(new Ingredient() { Type = IngredientType.Tomato, Quantity = _config.Tomato });
                    break;

                default:
                    break;
            }
        }

        public List<Ingredient> Ingredients { get; }

        public override string ToString()
        {
            string size = _isMignon ? "piccola" : "grande";
            return $"Pizza {size}";
        }
    }

    interface IPizzaBuilder
    {
        Pizza Create();
    }
       
    class PizzaConfiguration
    {
        public static Dictionary<bool, PizzaConfiguration> Configurations = new Dictionary<bool, PizzaConfiguration>
        {
            {
                true, //small pizza
                new PizzaConfiguration
                {
                    Mozzarella = 10,
                    Tomato = 10,
                    Ham = 30,
                    Chips = 30,
                    Mushrooms = 15,
                    RocketSalad = 10,
                }
            },
            {
                false, //big pizza
                new PizzaConfiguration
                {
                    Mozzarella = 20,
                    Tomato = 15,
                    Ham = 50,
                    Chips = 50,
                    Mushrooms = 25,
                    RocketSalad = 15,
                }
            },
        };

        PizzaConfiguration()
        {

        }

        public int Tomato { get; set; }
        public int Mozzarella { get; set; }
        public int Ham { get; set; }
        public int RocketSalad { get; set; }
        public int Mushrooms { get; set; }
        public int Chips { get; set; }
    }

    class PizzaBuilder : IPizzaBuilder
    {
        private readonly PizzaBase _baseType;
        private List<Ingredient> _ingredients;
        private bool _isMignon = false;
        private PizzaConfiguration _config;

        public PizzaBuilder(PizzaBase baseType, bool isMignon = false)
        {
            _baseType = baseType;
            _isMignon = isMignon;
            _config = PizzaConfiguration.Configurations[isMignon];
            _ingredients = new List<Ingredient>();
        }

        public Pizza Create()
        {
            var ingredientClones = _ingredients
                .Select(x => new Ingredient { Type = x.Type, Quantity = x.Quantity });

            var pizza = new Pizza(_baseType, _isMignon);
            pizza.Ingredients.AddRange(ingredientClones);
            return pizza;
        }

        public PizzaBuilder AddMozzarella()
        {
            _ingredients.Add(new Ingredient() { Type = IngredientType.Mozzarella, Quantity = _config.Mozzarella });
            return this;
        }

        public PizzaBuilder AddHam()
        {
            _ingredients.Add(new Ingredient() { Type = IngredientType.Ham, Quantity = _config.Ham });
            return this;
        }

        public PizzaBuilder AddRocketSalad()
        {
            _ingredients.Add(new Ingredient() { Type = IngredientType.RocketSalad, Quantity = _config.RocketSalad });
            return this;
        }

        public PizzaBuilder AddMushrooms()
        {
            _ingredients.Add(new Ingredient() { Type = IngredientType.Mushroom, Quantity = _config.Mushrooms });
            return this;
        }

        public PizzaBuilder AddChips()
        {
            _ingredients.Add(new Ingredient() { Type = IngredientType.Chips, Quantity = _config.Chips });
            return this;
        }

        public PizzaBuilder AddAnanas()
        {
            // do nothing, ananas can't go on pizza
            //_ingredients.Add(new Ingredient() { Type = IngredientType.Ananas, Quantity = 0 });
            throw new InvalidOperationException("NUN CE PROVA' L'ANANAS NON VA SULLA PIZZA!!!");
        }
    }
}
