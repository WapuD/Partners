using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Partner_API.Data.Models;
using Partner_WEB.Data;

namespace Partner_WEB.Pages
{
    public class PartnerListModel : PageModel
    {
        private readonly ILogger<PartnerListModel> _logger;
        private readonly IApiClient _apiClient;

        [BindProperty]
        public IEnumerable<Partner> Partners { get; set; }
        [BindProperty]
        public List<int> Discount { get; set; }

        public PartnerListModel(ILogger<PartnerListModel> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task OnGetAsync()
        {
            Discount = new List<int>();
            Partners = await _apiClient.GetPartnerAsync();
            var z = 0;
            foreach (var partner in Partners)
            {
                var zero = await _apiClient.GetPartnerDiscountAsync(partner.Id);
                Discount.Add(zero);
            }
        }
    }
}
