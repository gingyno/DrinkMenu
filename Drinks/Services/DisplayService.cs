using Drinks.App_Data_Classes;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drinks.Services
{
    internal class DisplayService
    {
        public void DisplayCategories(CategoryWrapper categoryWrapper)
        {
            var table = new Table()
                            .RoundedBorder()
                            .BorderColor(Color.GreenYellow);
            int i = 1;
            table.AddColumn("Categories");
            if(categoryWrapper?.Drinks != null)
            {
                foreach (var category in categoryWrapper.Drinks)
                {
                    if (!string.IsNullOrEmpty(category.StrCategory))
                    {
                        table.AddRow(i + ". " + category.StrCategory ?? string.Empty);
                    }
                    i++;
                }
            }
            AnsiConsole.Write(table);
        }
        public void DisplayDrinksAccordingToCategory(string category, DrinksWrapper? drinksWrapper)
        {
            var table = new Table()
                            .RoundedBorder()
                            .BorderColor(Color.Orange1);
            int i = 1;
            table.AddColumn($"Drinks from {category}");
            if (drinksWrapper?.Drinks != null)
            {
                foreach (var drink in drinksWrapper.Drinks)
                {
                    if (!string.IsNullOrEmpty(drink.StrDrink) && drink.StrCategory == category)
                    {
                        drinksWrapper.DisplayDrinkDetails(drink);
                    }
                    i++;
                }
            }
            AnsiConsole.Write(table);
        }
    }
}
