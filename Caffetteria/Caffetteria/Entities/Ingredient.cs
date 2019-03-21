using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffetteria.Entities {
	class Ingredient : IIngredient {
		public string Description { get; }

		public double Price { get; }

		public Ingredient(string description, double price) {
			Description = description;
			Price = price;
		}
	}
}
