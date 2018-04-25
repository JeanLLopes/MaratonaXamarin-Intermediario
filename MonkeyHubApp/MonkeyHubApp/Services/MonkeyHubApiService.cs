using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MonkeyHubApp.Models;
using Newtonsoft.Json;

namespace MonkeyHubApp.Services
{
    public class MonkeyHubApiService : IMonkeyHubApiService
    {
        private const string BaseUrl = "http://jsonplaceholder.typicode.com/";

        public async Task<List<PostModel>> GetPostsAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync($"{BaseUrl}posts").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        return JsonConvert.DeserializeObject<List<PostModel>>(
                            await new StreamReader(responseStream)
                                .ReadToEndAsync().ConfigureAwait(false));
                    }
                }

                return null;

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public Task<PostModel> GetPostByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
