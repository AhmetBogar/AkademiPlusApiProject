using AkademiPlusApiProject.RapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AkademiPlusApiProject.RapidApi.Controllers
{
    public class RapidApiImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<RapidApiImdbViewModel> rapidImdbViewModels = new List<RapidApiImdbViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "646eaf26e4msh30a010d5c8bebcep115bc6jsn6cc3e20bfb2a" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                rapidImdbViewModels = JsonConvert.DeserializeObject<List<RapidApiImdbViewModel>>(body);
                return View(rapidImdbViewModels);
            }
            
        }
    }
}
