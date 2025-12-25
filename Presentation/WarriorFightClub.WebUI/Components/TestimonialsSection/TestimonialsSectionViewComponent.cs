using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.WebUI.ApiDtos;

namespace WarriorFightClub.WebUI.Components.TestimonialsSection
{
    public class TestimonialsSectionViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialsSectionViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int take = 6)
        {
            var client = _httpClientFactory.CreateClient("WarriorApi");
            var ct = HttpContext.RequestAborted;

            var paged = await client.GetFromJsonAsync<PagedResult<TestimonialDto>>(
                $"api/testimonials?page=1&pageSize={take}&isShown=true", ct);

            return View(paged?.Items ?? new List<TestimonialDto>());
        }
    }
}
