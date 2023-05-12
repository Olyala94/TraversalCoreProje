using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using System.Threading.Tasks;
using System.Collections.Generic;
using TraversalCoreProje.Areas.Admin.Models;
using Newtonsoft.Json;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]

    public class ApiMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieViewModel> apiMovies = new List<ApiMovieViewModel>();   
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies1.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "81f0d65b89msh617c0b7117b6887p1fdd73jsn54dd8866fe8b" },
        { "X-RapidAPI-Host", "imdb-top-100-movies1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovies=JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(apiMovies);   
            }
        }
    }
}
