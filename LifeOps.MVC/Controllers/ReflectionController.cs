using LifeOps.Application.Common;
using LifeOps.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Net.Http;

namespace LifeOps.MVC.Controllers
{
    [Route("/Reflection")]
    public class ReflectionController : Controller
    {
        private readonly HttpClient _http;

        public ReflectionController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient();
            _http.BaseAddress = new Uri("https://localhost:7299/");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetReflections")]
        public async Task<IActionResult> GetReflections()
        {
            var response = await _http.GetAsync($"api/reflection");
            return Json(await response.Content.ReadFromJsonAsync<ApiResponse<IReadOnlyList<ReflectionDTO>>>());
        }


        [HttpGet("CreatePartial")]
        public async Task<IActionResult> CreatePartial()
        {
            var dto = new CreateReflectionDTO();
            return PartialView("_ReflectionForm", dto);
        }

        [HttpGet("EditPartial/{id}")]
        public async Task<IActionResult> EditPartial(Guid id)
        {
            var response = await _http.GetAsync($"api/reflection/{id}");
            var dto = await response.Content.ReadFromJsonAsync<ApiResponse<ReflectionDTO?>>();
            return PartialView("_ReflectionForm", dto.Data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateReflectionDTO dto)
        {
            var response = await _http.PostAsJsonAsync($"api/reflection", dto);
            return Json(await response.Content.ReadFromJsonAsync<ApiResponse<Guid>>());
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateReflectionDTO dto)
        {
            var response = await _http.PutAsJsonAsync($"api/reflection/{id}", dto);
            return Json(await response.Content.ReadFromJsonAsync<ApiResponse<bool>>());
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _http.DeleteAsync($"api/reflection/{id}");
            return Json(await response.Content.ReadFromJsonAsync<ApiResponse<bool>>());
        }
    }
}
