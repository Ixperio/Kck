using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Net.Http;
using DB.Entities;
using ProjektArtykuly.Models;

namespace ProjektArtykuly.Pages
{
    public class ArticlesModel : PageModel
    {
        private readonly HttpClient httpClient;

        public List<ArticleModelMini> AllData { get; set; }
        public List<ArticleModelMini> BestData { get; set; }
        public List<ArticleModelMini> NewestData { get; set; }
     //   public List<String> cookieData { get; set; }
        public ArticlesModel(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }
        public async Task OnGet()
        {
            string apiUrl = "https://localhost:7261/api/Article/";
            var allList = await httpClient.GetAsync(apiUrl + "GetList/");
            var bestArticles = await httpClient.GetAsync(apiUrl + "GetList/");
            var newestArticles = await httpClient.GetAsync(apiUrl + "GetList/");

            allList.EnsureSuccessStatusCode();
            bestArticles.EnsureSuccessStatusCode();
            newestArticles.EnsureSuccessStatusCode();

            var allContent = await allList.Content.ReadAsStringAsync();
            var bestContent = await bestArticles.Content.ReadAsStringAsync();
            var newestContent = await allList.Content.ReadAsStringAsync();

            AllData = JsonSerializer.Deserialize<List<ArticleModelMini>>(allContent);
            BestData = JsonSerializer.Deserialize<List<ArticleModelMini>>(bestContent);
            NewestData = JsonSerializer.Deserialize<List<ArticleModelMini>>(newestContent);

            List<ArticleModelMini> ten = new List<ArticleModelMini>();
          
            foreach(var item in AllData)
            {
                string introo = item.intro.ToString();
                var article = new ArticleModelMini();
                if (introo.Length > 150)
                {
                    string wynik = introo.Substring(0, 150) + "...";
                    article.title = item.title;
                    article.intro = wynik;
                    article.id = item.id;
                }
                else
                {
                    article.title = item.title;
                    article.intro = introo;
                    article.id = item.id;
                }
                
                ten.Add(article);
            }

            AllData = ten;
            BestData = AllData;
            NewestData = AllData;

            ViewData["AllArticles"] = AllData;
            ViewData["BestArticles"] = BestData;
            ViewData["NewestArticles"] = NewestData;

            //string serializeCookie = Request.Cookies["WiewedArticle"];

          //  ViewData["ListaWyswietlonych"] = serializeCookie.Split(',').ToList();


        }
    }
}
