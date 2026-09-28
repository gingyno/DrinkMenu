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
        public async Task<SingularDrink?> GetDrinkByIdAsync(string id)
        {
            try
            {
                var response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}");
                response.EnsureSuccessStatusCode();
                var drinksWrapper = await response.Content.ReadFromJsonAsync<DrinksWrapper>();
                SingularDrink? dr = drinksWrapper?.Drinks?.FirstOrDefault();
                return dr;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching drink by ID: {ex.Message}");
                throw;
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
        public async Task<DrinksWrapper?> GetDrinksByCategory(string category)
        {
            try
            {
                var response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={Uri.EscapeDataString(category)}");
                response.EnsureSuccessStatusCode();
                var drinksWrapper = await response.Content.ReadFromJsonAsync<DrinksWrapper>();
                return drinksWrapper;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching drinks by category: {ex.Message}");
                return null;
            }
        }
        public async Task<CategoryWrapper?> GetAllCategories()
        {
            try
            {
                var response = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
                response.EnsureSuccessStatusCode();
                var categoryWrapper = await response.Content.ReadFromJsonAsync<CategoryWrapper>();
                return categoryWrapper;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching categories: {ex.Message}");
                return null;
            }
        }
        public async Task<DrinksWrapper?> GetDrinksByCategoryAsync(string category)
        {
            try
            {
                var response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={Uri.EscapeDataString(category)}");
                response.EnsureSuccessStatusCode();
                var drinksWrapper = await response.Content.ReadFromJsonAsync<DrinksWrapper>();
                return drinksWrapper;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching drinks by category: {ex.Message}");
                return null;
            }
        }
    }
}
