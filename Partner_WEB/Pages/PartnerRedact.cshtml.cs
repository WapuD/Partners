using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Partner_API.Data;
using Partner_API.Data.Models;
using Partner_WEB.Data;
using System.ComponentModel;

namespace Partner_WEB.Pages
{
    public class PRModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IApiClient _apiClient;

        [BindProperty]
        public Partner Partner { get; set; }
        [BindProperty]
        public Partner partner { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> TypeList { get; set; }

        public PRModel(ILogger<IndexModel> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task OnGetAsync(int id)
        {
            partner = await _apiClient.GetPartnerAsync(id);
            var typeList = await _apiClient.GetPartnerTypesAsync();
            if (typeList == null || !typeList.Any())
            {
                throw new InvalidOperationException("Список типов партнёров пуст.");
            }
            TypeList = typeList.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.TypeName,
                Selected = t.Id == partner.Type
            });
        }

        // Обновление данных партнера
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
                    Text = t.TypeName,
                    Selected = t.Id == partner.Type
                });

                return Page();
            }

            _apiClient.PutPartnerAsync(Partner);

            return RedirectToPage("/Index"); // Перенаправление на список партнеров
        }
    }
}