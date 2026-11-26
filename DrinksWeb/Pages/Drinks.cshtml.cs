using DrinkWeb.Models;
using DrinkWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrinkWeb.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ApiService _apiService;

        public SingularDrink? Drink { get; set; }

        public DetailsModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGet(string id)
        {
            Drink = await _apiService.GetDrinkByIdAsync(id);
        }
    }
}