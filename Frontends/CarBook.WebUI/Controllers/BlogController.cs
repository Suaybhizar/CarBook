using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarPricingDtos;
using CarBook.Dto.CommentDtos;
using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.V1 = "Bloglar";
            ViewBag.V2 = "Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7136/api/Blogs/GetAllBlogsWithAuthorList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();

        }
        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.V1 = "Bloglar";
            ViewBag.V2 = "Blog Detayı ve Yorumlar";
            ViewBag.blogId = id;

            var client = _httpClientFactory.CreateClient();

            var responseMessage2 = await client.GetAsync($"https://localhost:7136/api/Comments/CommentCountByBlog?id=" + id);

            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.commentCount = jsonData2;
            return View();
        }
        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.blogId = id;
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7136/api/Comments/CreateCommentWithMediator", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
