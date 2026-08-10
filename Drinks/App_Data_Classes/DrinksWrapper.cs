using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drinks.App_Data_Classes
{
    internal class DrinksWrapper
    {
        public List<SingularDrink>? Drinks { get; set; }
        public void DisplayDrinkDetails(SingularDrink drink)
        {
            var table1 = new Table()
                            .RoundedBorder()
                            .BorderColor(Color.DeepPink1);
            table1.AddColumn("Name");
            table1.AddColumn("Category");
            table1.AddColumn("Alcoholic");
            table1.AddColumn("Glass");
            table1.AddRow(drink.StrDrink ?? string.Empty,
                        drink.StrCategory ?? string.Empty,
                        drink.StrAlcoholic ?? string.Empty,
                        drink.StrGlass ?? string.Empty);
            AnsiConsole.Write(table1);
            Console.WriteLine();

            var table2 = new Table()
                            .RoundedBorder()
                            .BorderColor(Color.BlueViolet);

            table2.AddColumn("Measures");
            table2.AddColumn("Ingredients");

            for (int i = 1; i <= 15; i++)
            {
                var ingredient = (string?)drink.GetType().GetProperty($"StrIngredient{i}")?.GetValue(drink);
                var measure = (string?)drink.GetType().GetProperty($"StrMeasure{i}")?.GetValue(drink);
                if (!string.IsNullOrEmpty(ingredient))
                {
                    table2.AddRow(measure ?? string.Empty, ingredient);
                }
            }
            AnsiConsole.Write(table2);
            Console.WriteLine();
            AnsiConsole.Write(new Text("Instructions: ", new Style(decoration: Decoration.Bold)));
            Console.Write(drink.StrInstructions);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
