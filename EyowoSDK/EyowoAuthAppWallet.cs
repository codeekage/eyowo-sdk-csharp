using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EyowoSDK.EyowoAuth
{
    internal class EyowoAuthAppWallet : EyowoUtility
    {
        internal EyowoAuthAppWallet(string httpBaseURL, string appKey) : base(httpBaseURL, appKey)
        {
        }

        internal async Task<(string error, string message)> SendAuthRequestAsync(string accountNumber, string factor)
        {
            try
            {
                string mobile = $"234{accountNumber}";
                dynamic body = new { mobile, factor };
                JObject response = await PostAsync(EyowoConstant.URL_AUTH_INIT, body);
                Response json = HttpMResponse(response);

                return !json.success ?
                   (json.error, message: null)
                  : (error: null, json.message);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        internal async Task<(string error, string message, object data)> AuthAccount(string accountNumber, string factor, string passcode)
        {
            try
            {
                string mobile = $"234{accountNumber}";
                object body = new { mobile, factor, passcode };
                JObject response = await PostAsync(EyowoConstant.URL_AUTH_INIT, body);

                Response json = HttpMResponse(response);
                return !json.success ? (json.error, message: null, data: null)
                : (error: null, json.message, json.data);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        internal async Task<bool> ValidateAccount(string accountNumber)
        {
            try
            {
                dynamic body = new { mobile = $"234{accountNumber}" };
                JObject response = await PostAsync(EyowoConstant.URL_AUTH_VALIDATE, body);
                return HttpMResponse(response).success;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }
    }
}
