using Drinks.App_Data_Classes;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using Drinks.Services;

namespace Drinks.Services
{
    internal class DisplayService
    {
        ApiService apiService = new ApiService();
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
        public async Task DisplayDrinksAccordingToCategory(string? category, DrinksWrapper? drinksWrapper)
        {
            if (drinksWrapper?.Drinks == null || drinksWrapper.Drinks.Count == 0)
            {
                AnsiConsole.MarkupLine($"[red]No drinks found for category '{category}'.[/]");
                return;
            }

            AnsiConsole.MarkupLine($"Drinks from {category}");
            foreach (var drink in drinksWrapper.Drinks)
            {
                if (!string.IsNullOrEmpty(drink.IdDrink))
                {
                    SingularDrink? drinkReal = await apiService.GetDrinkByIdAsync(drink.IdDrink);
                    if (drinkReal != null)
                    {
                        drinksWrapper.DisplayDrinkDetails(drinkReal);
                    }
                }
            }
        }
    }
}
