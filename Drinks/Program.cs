using Drinks;
using Drinks.App_Data_Classes;
using System;
using System.Collections.Generic;
using System.Text;


Console.WriteLine("Welcome to the Drink Finder!");

string loopInput = string.Empty;
do
{
    Console.Write("Enter the name of a drink to search for: ");
    string drinkName = Console.ReadLine() ?? string.Empty;
    ApiService apiService = new ApiService();
    DrinksWrapper? drinkObj = await apiService.GetDrinksByNameAsync(drinkName);
    if (drinkObj != null && drinkObj.Drinks != null && drinkObj.Drinks.Count > 0)
    {
        DisplayService displayService = new DisplayService();
        foreach (var drink in drinkObj.Drinks)
        {
            displayService.DisplayDrinkDetails(drink);
            Console.WriteLine(new string('=', 40));
        }
    }
    else
    {
        Console.WriteLine("No drinks found with that name.");
    }
    Console.Write("Do you want to search for another drink? (yes/no): ");
    loopInput = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
}
while (loopInput == "yes" || loopInput == "y");
