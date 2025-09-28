using CarBook.Dto.LocationDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart3ComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardChart3ComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //TODO: Api bağlantısı kurulacak ve veriler UI da Gösterilecek chartları Hazırla
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7136/api/Locations");

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
