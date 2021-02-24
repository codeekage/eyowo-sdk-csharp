using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EyowoSDK
{
    internal class EyowoUtility
    {
        internal struct Response
        {
            internal bool success;
            internal string error;
            internal JObject data;
            internal string message;
        }

        private readonly HttpClient httpClient;
        private readonly string HTTP_BASE_URL;

        private static object ValidateBaseURL(string httpBaseURL)
        {
            string[] VALID_BASE_URL = new string[] {
                EyowoConstant.BASE_DEV_URL_PROD_V1,
                EyowoConstant.BASE_DEV_URL_V1,
                EyowoConstant.BASE_URL_V1,
                EyowoConstant.BASE_URL_PROD_V1,
            };

            return !Array.Exists(VALID_BASE_URL, url => url == httpBaseURL)
             ? throw new Exception($"The url ({httpBaseURL}) is not a valid URL. Please, check and try again.")
             : null;
        }

        internal EyowoUtility(string httpBaseURL)
        {
            ValidateBaseURL(httpBaseURL);
            HTTP_BASE_URL = httpBaseURL;
            httpClient = new HttpClient();
        }

        internal EyowoUtility(string httpBaseURL, string appKey)
        {
            ValidateBaseURL(httpBaseURL);
            HTTP_BASE_URL = httpBaseURL;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-App-Key", appKey);
        }

        internal static Response HttpMResponse(JObject response)
        {
            Response res;
            res.success = (bool)response.GetValue("success");
            res.data = (JObject)response.GetValue("data");
            res.error = (string)response.GetValue("error");
            res.message = (string)response.GetValue("message");

            return res;
        }

        private static HttpContent ParseRequestBody(object obj)
        {
            object bodyObject = obj;
            string json = JsonConvert.SerializeObject(bodyObject);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            return content;
        }


        internal async Task<JObject> PostAsync(string route, object body)
        {
            try
            {
                HttpContent content = ParseRequestBody(body);
                HttpResponseMessage response = await httpClient
                    .PostAsync($"{HTTP_BASE_URL}{route}", content);
                string result = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(result);
                return json;
            }
            catch (HttpRequestException ex)
            {
                httpClient.Dispose();
                throw new HttpRequestException($"{ex}");
            }
        }

        internal async Task<JObject> GetAsync(string route)
        {
            try
            {
                HttpResponseMessage response = await httpClient
                    .GetAsync($"{HTTP_BASE_URL}{route}");
                string result = await response.Content
                    .ReadAsStringAsync();
                JObject json = JObject.Parse(result);
                return json;
            }
            catch (HttpRequestException ex)
            {
                httpClient.Dispose();
                throw new HttpRequestException($"{ex}");
            }
        }

        internal void SetSecureHeader(string name, string value)
        {
            httpClient.DefaultRequestHeaders.Add(name, value);
        }

        internal void Dispose()
        {
            httpClient.Dispose();
        }

    }
}
