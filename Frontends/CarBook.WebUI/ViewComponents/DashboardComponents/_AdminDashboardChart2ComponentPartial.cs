using CarBook.Dto.BrandDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart2ComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardChart2ComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();


            //TODO: Api bağlantısı kurulacak ve veriler UI da Gösterilecek chartları Hazırla

            var responseMessage = await client.GetAsync("https://localhost:7136/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(values);
            }
    
            return View();

        }

    }
}