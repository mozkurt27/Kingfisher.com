using Kingfisher.Admin.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Kingfisher.Admin.UI.Manager.APIManager
{
    public class CategoryManager
    {
        public async Task<List<CategoryDTO>> SelectAll(String ApiUrl)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            List<CategoryDTO> model;
            HttpResponseMessage response = await client.GetAsync(ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CategoryDTO>>(data);

                return model;
            }

            return null;
        }
    }
}