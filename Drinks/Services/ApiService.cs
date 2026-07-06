using Drinks.App_Data_Classes;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace Drinks.Services
{
    internal class ApiService
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<DrinksWrapper?> GetDrinkByIdAsync(string id)
        {
            try
            {
                var response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}");
                response.EnsureSuccessStatusCode();
                var drinksWrapper = await response.Content.ReadFromJsonAsync<DrinksWrapper>();
                return drinksWrapper;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching drink by ID: {ex.Message}");
                return null;
            }
        }
        public async Task<DrinksWrapper?> GetDrinksByNameAsync(string name)
        {
            try
            {
                var response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={Uri.EscapeDataString(name)}");
                response.EnsureSuccessStatusCode();
                var drinksWrapper = await response.Content.ReadFromJsonAsync<DrinksWrapper>();
                return drinksWrapper;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching drink by name: {ex.Message}");
                return null;
            }
        }
    }
}
