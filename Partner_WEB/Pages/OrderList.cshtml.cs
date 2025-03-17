using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Partner_API.Data;
using Partner_API.Data.Models;
using Partner_WEB.Data;

namespace Partner_WEB.Pages
{
    public class OrderHistoryModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public IEnumerable<Order> Orders { get; set; }

        public OrderHistoryModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task OnGetAsync(int id)
        {
            Orders = await _apiClient.GetHistoryAsync(id);
        }
    }
}
