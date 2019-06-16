using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;

using Newtonsoft.Json;

using MusicMobile.Helpers;

namespace MusicMobile.Services
{
    public static class MusicService<T>
    {
        private static readonly HttpClient httpClient = CreateClient();

        private static HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Constants.MusicWebApiUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async static Task<List<T>> GetData(string controller)
        {
            var response = await httpClient.GetAsync(controller);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }

            return default(List<T>);
        }

        public async static Task<bool> InsertData(string controller, T item)
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(controller, content);
            return response.IsSuccessStatusCode;
        }

        public async static Task<bool> UpdateData(string controller, T item, Guid id)
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"{controller}/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async static Task<bool> DeleteData(string controller, Guid id)
        {
            var response = await httpClient.DeleteAsync($"{controller}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
