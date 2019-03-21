using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffetteria.Entities {
	interface IProduct {
		string Description { get; set; }
		List<IIngredient> Ingredients { get; }
		double CalculatePrice();
		void AddIngredient(IIngredient ingredient);
		void RemoveIngredient(IIngredient ingredient);
	}
}
