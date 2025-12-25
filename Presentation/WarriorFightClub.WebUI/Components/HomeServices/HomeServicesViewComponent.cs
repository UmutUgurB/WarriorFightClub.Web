using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.WebUI.ApiDtos;

namespace WarriorFightClub.WebUI.Components.HomeServices
{
    public sealed class HomeServicesViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeServicesViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int take = 4)
        {
            var client = _httpClientFactory.CreateClient("WarriorApi");
            var ct = HttpContext.RequestAborted;

            var paged = await client.GetFromJsonAsync<PagedResult<ServiceDto>>(
                $"api/services?page=1&pageSize={take}&isActive=true", ct);

            return View(paged?.Items ?? new List<ServiceDto>());
        }
    }
}
