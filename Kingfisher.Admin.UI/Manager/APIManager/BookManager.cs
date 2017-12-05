using Kingfisher.Admin.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kingfisher.Admin.UI.Manager.APIManager
{
    public class BookManager
    {
        public async Task<List<BookDTO>> SelectAll(String ApiUrl)
        {

            HttpClient client = new HttpClient();
           
            client.BaseAddress = new Uri(ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            List<BookDTO> model;
            HttpResponseMessage response = await client.GetAsync(ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<BookDTO>>(data);

                return model;
            }

            return null;
        }
        public async Task<List<BookDTO>> Deleteds(string ApiUrl)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            List<BookDTO> model;
            HttpResponseMessage response = await client.GetAsync(ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<BookDTO>>(data);

                return model;
            }



            return null;
        }
        public async Task<bool> Delete(int? id, string ApiUrl)
        {
            ApiUrl += id;
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = await client.GetAsync(ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();


                return true;
            }



            return false;
        }
        public async Task<BookDTO> OneBook(string ApiUrl)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            BookDTO model;
            HttpResponseMessage response = await client.GetAsync(ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<BookDTO>(data);

                return model;
            }

            return null;
        }
        public async Task<int> Insert(BookDTO model,String ApiUrl)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ApiUrl, stringContent);
            int result = 0;
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                result = int.Parse(data);
            }


            return result;
        }

        public async Task<bool> Update(BookDTO model, string ApiUrl)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await client.PutAsync(ApiUrl, stringContent);
            
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                string sonuc = (string)data;
                return true;
            }


            return false;
        }
    }
}