namespace Partner_WEB.Data
{
    using Refit;
    using Partner_API.Data.Models;
    using Microsoft.AspNetCore.Mvc;

    public interface IApiClient
    {
        [Get("/Partners")]
        Task<IEnumerable<Partner>> GetPartnerAsync();
        [Get("/Partners/{id}")]
        Task<Partner> GetPartnerAsync(int id);
        [Put("/Partners/{partner}")]
        Task<IActionResult> PutPartnerAsync(Partner partner);
        [Post("/Partners")]
        Task<IActionResult> AddPartnerAsync(Partner partner);
        [Get("/Partners/Discount/{id}")]
        Task<int> GetPartnerDiscountAsync(int id);


        [Get("/PartnerTypes")]
        Task<IEnumerable<PartnerType>> GetPartnerTypesAsync();

        [Get("/Orders/History/{id}")]
        Task<IEnumerable<Order>> GetHistoryAsync(int id);
        [Get("/Orders")]
        Task<IEnumerable<Order>> GetOrders();


        [Get("/Products")]
        Task<IEnumerable<Product>> GetProductAsync();
        [Get("/ProductTypes")]
        Task<IEnumerable<ProductType>> GetProductTypeAsync();

        /*[Get("/User/Verificate/{id}")]
        Task<bool> VerificateUser(string login, string password);*/

        /*[Post("/roles")]
          Task<Role> CreateRoleAsync([Body] Role newRole);

          [Get("/tests")]
          Task<IEnumerable<Test>> GetTestAsync();

          [Get("/tests/{id}")]
          Task<Test> GetTestAsync(int id);*/
    }
}
