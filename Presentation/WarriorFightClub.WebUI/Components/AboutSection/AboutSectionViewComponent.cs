using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.WebUI.ApiDtos;

namespace WarriorFightClub.WebUI.Components.AboutSection
{
    public sealed class AboutSectionViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutSectionViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("WarriorApi");
            var ct = HttpContext.RequestAborted;

            // WebApi: GET /api/abouts/active
            var about = await client.GetFromJsonAsync<AboutDto>("api/abouts/active", ct);

            return View(about); 
        }
    }
}
