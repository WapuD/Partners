using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Partner_API.Data.Models;
using Partner_WEB.Data;
using System.ComponentModel;

namespace Partner_WEB.Pages
{
    public class PAModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IApiClient _apiClient;

        [BindProperty]
        public Partner Partner { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> TypeList { get; set; }

        public PAModel(ILogger<IndexModel> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task OnGetAsync(int id)
        {
            var typeList = await _apiClient.GetPartnerTypesAsync();
            if (typeList == null || !typeList.Any())
            {
                throw new InvalidOperationException("Список типов партнёров пуст.");
            }
            TypeList = typeList.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.TypeName
            });
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Повторное заполнение TypeList при ошибке валидации
                var typeList = await _apiClient.GetPartnerTypesAsync();
                if (typeList == null || !typeList.Any())
                {
                    throw new InvalidOperationException("Список типов партнёров пуст.");
                }
                TypeList = typeList.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.TypeName
                });

                return Page();
            }

            _apiClient.AddPartnerAsync(Partner);
            return RedirectToPage("/Index");
        }
    }
}
