using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffetteria.Entities {
	class Product : IProduct {
		public enum Dimension {
			Normal,
			Double,
			Small,
			Big,
		}
		
		public List<IIngredient> Ingredients { get; }
		public string Description { get; set; }		
		
		public Product() {
			Ingredients = new List<IIngredient>();
		}
		
		public void AddIngredient(IIngredient ingredient) {
			Ingredients.Add(ingredient);
		}

		public void RemoveIngredient(IIngredient ingredient) {
			Ingredients.Remove(ingredient);
		}

		public double CalculatePrice() {
			double _price = 0D;
			foreach (IIngredient ingredient in Ingredients) {
				_price += ingredient.Price;
			}			
			return _price;
		}
	}
}
