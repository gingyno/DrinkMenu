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

Console.WriteLine("Would you like to choose from categories or by " +
    "drink name? Enter 'C' for categories or 'D' for drink name: ");
string choice = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

// Pilot code to display all categories
CategoryWrapper? categoryObj = await apiService.GetAllCategories();
if (categoryObj != null && categoryObj.Drinks != null)
{
    displayService.DisplayCategories(categoryObj);
    Console.WriteLine();
}
Console.WriteLine("Choose a category by typing the category name exactly as it appears above: ");
string categoryName = Console.ReadLine() ?? string.Empty;

DrinksWrapper? drinksWrapper = await apiService.GetDrinksByCategoryAsync(categoryName);
await displayService.DisplayDrinksAccordingToCategory(categoryName, drinksWrapper);
/*
do
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
            drinkObj.DisplayDrinkDetails(drink);
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
