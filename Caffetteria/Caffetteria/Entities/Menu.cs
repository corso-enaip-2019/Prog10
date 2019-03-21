using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffetteria.Entities {
	class Menu {
		public List<IProduct> Coffees = new List<IProduct>();

		public Menu() {

			IProduct macchiato = new Product();
			macchiato.Description = "Macchiato";
			macchiato.AddIngredient(new Ingredient("Caffè", 0.9));
			macchiato.AddIngredient(new Ingredient("Latte", 0.5));
			Coffees.Add(macchiato);



		}
	}
}
