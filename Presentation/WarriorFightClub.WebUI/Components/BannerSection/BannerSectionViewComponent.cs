using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.WebUI.ApiDtos;
using WarriorFightClub.WebUI.ViewModels;

namespace WarriorFightClub.WebUI.Components.BannerSection
{
    public sealed class BannerSectionViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BannerSectionViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int take = 4)
        {
            var client = _httpClientFactory.CreateClient("WarriorApi");

            var paged = await client.GetFromJsonAsync<PagedResult<BannerDto>>(
                $"api/banners?page=1&pageSize={take}&isActive=true");

            var vm = new BannerSectionVm
            {
                Items = paged?.Items ?? new List<BannerDto>()
            };

            return View(vm);
        }
    }
}
