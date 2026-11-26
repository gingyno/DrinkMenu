using DrinkWeb.Models;
using DrinkWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrinkWeb.Pages
{
    public class CategoriesModel : PageModel
    {
        private readonly ApiService _apiService;

        public List<Category> Categories { get; set; } = new();
        public string? ErrorMessage { get; set; }

        public CategoriesModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGet()
        {
            var result = await _apiService.GetAllCategories();
            if (result?.Drinks == null)
            {
                ErrorMessage = "Couldn't load categories. Try again later.";
                return;
            }
            Categories = result.Drinks;
        }
    }
}