using Drinks.App_Data_Classes;
using Drinks.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;


Console.WriteLine("Welcome to the Drink Finder!");

ApiService apiService = new ApiService();
DisplayService displayService = new DisplayService();
string loopInput = string.Empty;


// Pilot code to display all categories
CategoryWrapper? categoryWrapper = await apiService.GetAllCategories();
if (categoryWrapper?.Categories != null)
{
    int i = 1;
    foreach (var category in categoryWrapper.Categories)
    {
        if (category.StrCategory != null)
        {
            Console.WriteLine($"{i}. {category.StrCategory}");
        }
        i++;
    }
}
/*do
{
    Console.Write("Do you want to search for another drink? (yes/no): ");
    loopInput = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
}
while (loopInput == "yes" || loopInput == "y");
/*do
{
    Console.Write("Enter the name of a drink to search for: ");
    string drinkName = Console.ReadLine() ?? string.Empty;
    if(string.IsNullOrWhiteSpace(drinkName))
    {
        Console.WriteLine("Please enter a valid drink name.");
        continue;
    }
    
    DrinksWrapper? drinkObj = await apiService.GetDrinksByNameAsync(drinkName);
    if (drinkObj != null && drinkObj.Drinks != null && drinkObj.Drinks.Count > 0)
    {
        foreach (var drink in drinkObj.Drinks)
        {
            displayService.DisplayDrinkDetails(drink);
            Console.WriteLine(new string('=', 40));
            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine("No drinks found with that name.");
    }
    Console.Write("Do you want to search for another drink? (yes/no): ");
    loopInput = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
}
while (loopInput == "yes" || loopInput == "y");*/

Console.WriteLine();
Console.WriteLine();
AnsiConsole.Write(new Text("Thank you for using the Drink Finder! Goodbye!", 
                  new Style(Color.Yellow)).Centered());
