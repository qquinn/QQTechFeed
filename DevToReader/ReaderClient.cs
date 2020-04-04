using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using System.Linq;

namespace DevToReader
{
    public class ReaderClient
    {
        static HttpClient _client = new HttpClient();

        public ReaderClient()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Article> GetArticles()
        {
            List<Article> articles = new List<Article>();
            var task = Task.Run(() => _client.GetAsync("https://dev.to/api/articles"));
            task.Wait();
            var response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                List<DevToResponse> stuff = JsonConvert.DeserializeObject<List<DevToResponse>>(content);
                foreach (DevToResponse item in stuff)
                {
                    Article article = new Article();
                    article.ArticleID = Guid.NewGuid().ToString();
                    article.Description = item.description;
                    article.Title = item.title;
                    article.Source = "DEV.TO";
                    article.Url = item.url;
                    article.PublishDate = ConvertToUnixTimestamp(item.published_timestamp);
                    articles.Add(article);

                }
            }
            
            return articles;
        }

        public static double ConvertToUnixTimestamp(DateTime dateTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (dateTime.ToUniversalTime() - unixStart).Ticks;
            return (double)unixTimeStampInTicks / TimeSpan.TicksPerSecond;
        }
    }

}
