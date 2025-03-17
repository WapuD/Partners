using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Partner_API.Data.Models;
using Partner_WEB.Data;

namespace Partner_WEB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IApiClient _apiClient;

        [BindProperty]
        public string login { get; set; }
        [BindProperty]
        public string password { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task OnGetAsync()
        {

        }
        public void OnPostAsync()
        {
            //bool flag = await _apiClient.VerificateUser(login, password);
        }
    }
}
