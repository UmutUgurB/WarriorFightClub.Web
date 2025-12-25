using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.WebUI.ApiDtos;

namespace WarriorFightClub.WebUI.Components.TrainersList
{
    public class TrainersListViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TrainersListViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int page = 1, int pageSize = 12, bool? isActive = true)
        {
            var client = _httpClientFactory.CreateClient("WarriorApi");
            var ct = HttpContext.RequestAborted;

            var url = $"api/trainers?page={page}&pageSize={pageSize}";
            if (isActive.HasValue)
                url += $"&isActive={isActive.Value.ToString().ToLower()}";

            var paged = await client.GetFromJsonAsync<PagedResult<TrainerDto>>(url, ct);

            return View(paged); 
        }
    }
}
