using System;
using System.Collections.Generic;

namespace DesignPatterns.Interpreter
{
	class Program
	{
		static void Main(string[] args)
		{
			var sandwich = new Sandwich(
				new WheatBread(),
				new CondimentList(
					new List<ICondiment> { new MayoCondiment(), new MustardCondiment() }),
				new IngredientList(
					new List<IIngredient> { new LettuceIngredient(), new ChickenIngredient() }),
				new CondimentList(
					new List<ICondiment> { new KetchupCondiment() }),
				new WheatBread());

			sandwich.Interpret(new Context());

			Console.ReadKey();
		}
	}
}
