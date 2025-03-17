using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Partner_API.Data.Models;
using Partner_WEB.Data;

namespace Partner_WEB.Pages
{
    public class PHModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IApiClient _apiClient;

        [BindProperty]
        public IEnumerable<Order> Sells { get; set; }

        public PHModel(ILogger<IndexModel> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task OnGetAsync(int id)
        {
            Sells = await _apiClient.GetHistoryAsync(id);
        }
    }
}
