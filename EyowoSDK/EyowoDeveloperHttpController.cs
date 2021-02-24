using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EyowoSDK.EyowoDeveloper
{
    public class EyowoDeveloperHttpController : EyowoUtility
    {
        private readonly string email;
        private readonly string password;

        protected internal EyowoDeveloperHttpController(string httpBaseURL, string email, string password) : base(httpBaseURL)
        {
            this.email = email;
            this.password = password;
        }

        public async Task<(string error, string token)> GetToken()
        {
            try
            {
                JObject response = await PostAsync(EyowoConstant.URL_DEV_AUTH, body: new { email, password });
                Response jsonRes = HttpMResponse(response);

                return !jsonRes.success ?
                    (jsonRes.error, token: null)
                    : (error: null, token: (string)jsonRes.data.GetValue("token"));

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public async Task<JObject> SecuredPostAsync(string route, object body)
        {
            try
            {
                (string error, string token) = await GetToken();
                if (error != null)
                {
                    throw new Exception($"An error occured: {error}");
                }

                SetSecureHeader("Authorization", $"Bearer {token}");
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
                (string error, string token) = await GetToken();
                if (error != null)
                {
                    throw new Exception($"An error occured: {error}");
                }
                SetSecureHeader("Authorization", $"Bearer {token}");
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
