using Kingfisher.Admin.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Kingfisher.Admin.UI.Manager.APIManager
{
    public class UserManager
    {
        public async Task<bool> CheckByCredentials(String ApiUrl)
        {

            HttpClient client = new HttpClient();
            bool isExist = false;
            client.BaseAddress = new Uri(ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                //  model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VM>>(data);

                isExist = bool.Parse(data);

            }
            
            return isExist;
        }

        public async Task<UserDTO> FindByUser(String ApiUrl)
        {
            HttpClient client = new HttpClient();
            
            client.BaseAddress = new Uri(ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                UserDTO currentUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDTO>(data);
                if (!currentUser.IsActive) return null;
                return currentUser;
            }

            return null;
        }
    }
}