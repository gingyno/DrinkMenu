using DrinkWeb.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace DrinkWeb.Services
{
    public class ApiService
    {
        private readonly HttpClient client;

        public ApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<SingularDrink?> GetDrinkByIdAsync(string id)
        {
            try
            {
                var response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={Uri.EscapeDataString(id)}");
                response.EnsureSuccessStatusCode();
                var drinksWrapper = await response.Content.ReadFromJsonAsync<DrinksWrapper>();
                return drinksWrapper?.Drinks?.FirstOrDefault();
            }
            catch (HttpRequestException)
            {
                return null;
            }
            catch (JsonException)
            {
                return null;
            }
        }

        public async Task<DrinksWrapper?> GetDrinksByNameAsync(string name)
        {
            try
            {
                var response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={Uri.EscapeDataString(name)}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<DrinksWrapper>();
            }
            catch (HttpRequestException)
            {
                return null;
            }
            catch (JsonException)
            {
                return null;
            }
        }

        public async Task<DrinksWrapper?> GetDrinksByCategory(string category)
        {
            try
            {
                var response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={Uri.EscapeDataString(category)}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<DrinksWrapper>();
            }
            catch (HttpRequestException)
            {
                return null;
            }
            catch (JsonException)
            {
                return null;
            }
        }

        public async Task<CategoryWrapper?> GetAllCategories()
        {
            try
            {
                var response = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CategoryWrapper>();
            }
            catch (HttpRequestException)
            {
                return null;
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}