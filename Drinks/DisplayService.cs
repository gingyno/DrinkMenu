using System;
using System.Collections.Generic;
using System.Text;

namespace Drinks.App_Data_Classes
{
    internal class DisplayService
    {
        public void DisplayDrinkDetails(SingularDrink drink)
        {
            Console.WriteLine($"Name: {drink.StrDrink}");
            Console.WriteLine($"Category: {drink.StrCategory}");
            Console.WriteLine($"Alcoholic: {drink.StrAlcoholic}");
            Console.WriteLine($"Glass: {drink.StrGlass}");
            Console.WriteLine($"Instructions: {drink.StrInstructions}");
            Console.WriteLine("Ingredients:");
            for (int i = 1; i <= 15; i++)
            {
                var ingredient = (string?)drink.GetType().GetProperty($"StrIngredient{i}")?.GetValue(drink);
                var measure = (string?)drink.GetType().GetProperty($"StrMeasure{i}")?.GetValue(drink);
                if (!string.IsNullOrEmpty(ingredient))
                {
                    Console.WriteLine($"{measure} {ingredient}");
                }
            }
        }
    }
}
