using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Utilities.dll.Contract;

namespace Utilities.dll.Helper
{
    public class APIHelper : IUserContext
    {
        private readonly HttpClient _client;
        public APIHelper()
        {
            _client = new HttpClient();

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<HttpResponseMessage> SendGetRequestAsync(string baseUrl, int size = 12)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            try
            {
                string url = $"{baseUrl}/size={size}";

                return await _client.GetAsync(url);
            }
            catch (Exception)
            {

                throw;
            }
        } 
        
        public async Task<HttpResponseMessage> SendGetRequestBySizeAsync(string baseUrl, int size)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            try
            {
                string url = $"{baseUrl}/{size}";

                return await _client.GetAsync(url);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
        
    

