using GeraAdvantage.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace GeraAdvantage.WebServices
{
    class NCWebServices
    {
        public async Task<List<NC>> GetNCAsync()
        {
            List<NC> NCList = new List<NC>();
            HttpClient client = UtilServices.GetHttpClient();
            Uri uri = new Uri(URLManager.GetNCURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                NCList = JsonConvert.DeserializeObject<List<NC>>(content);
                return NCList;
            }
            else
            {
                return new List<NC>();
            }
        }

        public async Task<bool> PostNCAsync(NC nc)
        {
            HttpClient client = UtilServices.GetHttpClient();
            Uri uri = new Uri(URLManager.GetNCURL());
            string parameters = JsonConvert.SerializeObject(nc);
            
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            if (parameters != null)
                request.Content = new StringContent(parameters, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

    }
}
