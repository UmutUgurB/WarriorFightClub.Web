using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.WebUI.ApiDtos;

namespace WarriorFightClub.WebUI.Components.ServicesList
{
    public class ServicesListViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServicesListViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int page = 1, int pageSize = 12, bool? isActive = true)
        {
            var client = _httpClientFactory.CreateClient("WarriorApi");
            var ct = HttpContext.RequestAborted;

            var url = $"api/services?page={page}&pageSize={pageSize}";
            if (isActive.HasValue)
                url += $"&isActive={isActive.Value.ToString().ToLower()}";

            var paged = await client.GetFromJsonAsync<PagedResult<ServiceDto>>(url, ct);


            var vm = new ServicesListVm
            {
                Page = paged?.Page ?? page,
                PageSize = paged?.PageSize ?? pageSize,
                TotalCount = paged?.TotalCount ?? 0,
                TotalPages = paged?.TotalPages ?? 0,
                Items = paged?.Items ?? new List<ServiceDto>(),
                IsActive = isActive
            };

            return View(vm);
        }
    }

    public sealed class ServicesListVm
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public IReadOnlyList<ServiceDto> Items { get; set; } = new List<ServiceDto>();
        public bool? IsActive { get; set; }
    }
}
