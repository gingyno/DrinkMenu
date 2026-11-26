using DrinkWeb.Models;
using DrinkWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrinkWeb.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty(SupportsGet = true)]
        public string? Name { get; set; }

        public List<SingularDrink> Results { get; set; } = new();
        public bool Searched { get; set; }
        public string? ErrorMessage { get; set; }

        public SearchModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return;
            }

            Searched = true;
            var result = await _apiService.GetDrinksByNameAsync(Name);
            if (result == null)
            {
                ErrorMessage = "Something went wrong. Try again later.";
                return;
            }
            Results = result.Drinks ?? new();
        }
    }
}