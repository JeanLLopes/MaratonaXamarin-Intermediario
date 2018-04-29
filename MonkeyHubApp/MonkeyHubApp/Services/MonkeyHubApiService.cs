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

        public async Task<List<PostModel>> GetPostsByUserIdAsync(int idUser)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync($"{BaseUrl}posts?userId={idUser}").ConfigureAwait(false);

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

        public async Task<PostModel> GetPostByIdAsync(int idPost)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync($"{BaseUrl}posts/{idPost.ToString()}").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        return JsonConvert.DeserializeObject<PostModel>(
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

        public async Task<List<CommentsModel>> GetCommentsByIdAsync(int idPost)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync($"{BaseUrl}posts/{idPost.ToString()}/comments").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        return JsonConvert.DeserializeObject<List<CommentsModel>>(
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

        public async Task<List<UserModel>> GetUsersAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync($"{BaseUrl}users").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        return JsonConvert.DeserializeObject<List<UserModel>>(
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
    }
}
