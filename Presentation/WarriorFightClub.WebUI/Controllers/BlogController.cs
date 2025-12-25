using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.WebUI.ApiDtos;
using WarriorFightClub.WebUI.ViewModels.Blog;

namespace WarriorFightClub.WebUI.Controllers;

public sealed class BlogController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BlogController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index(Guid? categoryId, int page = 1, int pageSize = 12, CancellationToken ct = default)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 12;
        if (pageSize > 24) pageSize = 24; 

        var client = _httpClientFactory.CreateClient("WarriorApi");

        var categories = await client.GetFromJsonAsync<List<CategoryLookupDto>>("api/categories/lookup", ct)
                         ?? new List<CategoryLookupDto>();

 
        var url = $"api/blogs/public?page={page}&pageSize={pageSize}";
        if (categoryId.HasValue)
            url += $"&categoryId={categoryId.Value}";

        var paged = await client.GetFromJsonAsync<PagedResult<BlogDto>>(url, ct)
                   ?? new PagedResult<BlogDto> { Page = page, PageSize = pageSize, Items = new List<BlogDto>() };

        var vm = new BlogIndexVm
        {
            CategoryId = categoryId,
            Categories = categories,
            Paged = paged,
            CategoryTitle = categoryId.HasValue ? categories.FirstOrDefault(x => x.Id == categoryId.Value)?.Title : null
        };

        return View(vm);
    }


    [HttpGet]
    public async Task<IActionResult> Detail(Guid id, CancellationToken ct)
    {
        var client = _httpClientFactory.CreateClient("WarriorApi");
        var blog = await client.GetFromJsonAsync<BlogDto>($"api/blogs/{id}", ct);
        return blog is null ? NotFound() : View(blog);
    }
}
