using CarBook.Dto.LocationDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart1ComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardChart1ComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7136/api/Cars");

            //TODO: Api bağlantısı kurulacak ve veriler UI da Gösterilecek chartları Hazırla

            if (responseMessage.IsSuccessStatusCode)

            {

                var jsondata = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsondata);

                return View(values);

            }

            return View();
        }
    }
}
