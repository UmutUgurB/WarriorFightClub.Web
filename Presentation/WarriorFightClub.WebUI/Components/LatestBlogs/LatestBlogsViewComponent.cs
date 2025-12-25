using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.WebUI.ApiDtos;

namespace WarriorFightClub.WebUI.Components.LatestBlogs
{
    public class LatestBlogsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LatestBlogsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int take = 3, Guid? excludeId = null)
        {
            var client = _httpClientFactory.CreateClient("WarriorApi");
            var ct = HttpContext.RequestAborted;

            var paged = await client.GetFromJsonAsync<PagedResult<BlogDto>>(
                $"api/blogs/public?page=1&pageSize={take + 1}", ct);

            var items = (paged?.Items ?? new List<BlogDto>())
                .OrderByDescending(x => x.CreatedDate)
                .ToList();

            if (excludeId.HasValue)
                items = items.Where(x => x.Id != excludeId.Value).ToList();

            items = items.Take(take).ToList();

            return View(items);
        }
    }
}
