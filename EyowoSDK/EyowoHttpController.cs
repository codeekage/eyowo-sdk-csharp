using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EyowoSDK.EyowoApp
{
    public class EyowoHttpController : EyowoUtility
    {
        private readonly string refreshToken;
        internal EyowoHttpController(string httpBaseURL, string appKey, string refreshToken)
            : base(httpBaseURL, appKey)
        {
            this.refreshToken = refreshToken;
        }

        protected internal async Task<(string error, string accessToken)> GetAccessToken()
        {
            try
            {
                object body = new { refreshToken };

                JObject response = await PostAsync(EyowoConstant.URL_AUTH_REFRESH_TOKEN, body);
                Response json = HttpMResponse(response);

                if (!json.success)
                {
                    Console.WriteLine(json.error);
                    return (json.error, accessToken: null);
                }
                return (error: null, accessToken: (string)json.data.GetValue("accessToken"));
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        public async Task<JObject> SecuredPostAsync(string route, object body)
        {
            try
            {
                (string error, string accessToken) = await GetAccessToken();
                if (error != null)
                {
                    throw new Exception($"An error occured: {error}");
                }

                SetSecureHeader("X-App-Wallet-Access-Token", accessToken);

                JObject response = await PostAsync(route, body);
                Dispose();
                return response;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        public async Task<JObject> SecuredGetAsync(string route)
        {
            try
            {
                (string error, string accessToken) = await GetAccessToken();
                if (error != null)
                {
                    throw new Exception($"An error occured: {error}");
                }
                SetSecureHeader("X-App-Wallet-Access-Token", accessToken);
                JObject response = await GetAsync(route);
                Dispose();
                return response;
            }
            catch (Exception ex)
            {
                Dispose();
                throw new HttpRequestException($"{ex}");
            }
        }
    }
}
