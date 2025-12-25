using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.WebUI.ApiDtos;

namespace WarriorFightClub.WebUI.Components.PackagesSection
{
    public sealed class PackagesSectionViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PackagesSectionViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int take = 3)
        {
            var client = _httpClientFactory.CreateClient("WarriorApi");
            var ct = HttpContext.RequestAborted;

            var paged = await client.GetFromJsonAsync<PagedResult<PackagesDto>>(
                $"api/packages?page=1&pageSize={take}&isActive=true", ct);

            return View(paged?.Items ?? new List<PackagesDto>());
        }
    }
}
