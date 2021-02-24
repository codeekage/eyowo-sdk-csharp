using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EyowoSDK.EyowoDeveloper
{
   public class EyowoDeveloper : EyowoDeveloperHttpController
    {
        public EyowoDeveloper(string httpBaseURL, string email, string password)
            : base(httpBaseURL, email, password)
        {
        }

        public async Task<(string error, object data)> CreateAppAsync(string appName)
        {
            try
            {
                JObject response = await SecuredPostAsync(EyowoConstant.URL_DEV_APP, body: new { name = appName });
                Response jsonRes = HttpMResponse(response);

                return !jsonRes.success ?
                    (jsonRes.error, data: null)
                    : (error: null, jsonRes.data);

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetAppsAsync()
        {
            try
            {
                JObject response = await SecuredGetAsync(EyowoConstant.URL_DEV_APP);
                Response jsonRes = HttpMResponse(response);

                return !jsonRes.success ?
                    (jsonRes.error, data: null)
                    : (error: null, jsonRes.data);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetAppAsync(string appID)
        {
            try
            {
                JObject response = await SecuredGetAsync($"{EyowoConstant.URL_DEV_APP}{appID}");
                Response jsonRes = HttpMResponse(response);

                return !jsonRes.success ?
                    (jsonRes.error, data: null)
                    : (error: null, jsonRes.data);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetAppTransactions(string appID)
        {
            try
            {
                JObject response = await SecuredGetAsync($"{EyowoConstant.URL_DEV_APP}{appID}{EyowoConstant.URL_TRANX}");
                Response jsonRes = HttpMResponse(response);

                return !jsonRes.success ?
                    (jsonRes.error, data: null)
                    : (error: null, jsonRes.data.GetValue("transactions"));
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetAppTransaction(string appID, string transactionID)
        {
            try
            {
                JObject response = await SecuredGetAsync($"{EyowoConstant.URL_DEV_APP}{appID}{EyowoConstant.URL_TRANX}{transactionID}");
                Response jsonRes = HttpMResponse(response);

                return !jsonRes.success ?
                    (jsonRes.error, data: null)
                    : (error: null, jsonRes.data.GetValue("transaction"));
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetAppTransfers(string appID)
        {
            try
            {
                JObject response = await SecuredGetAsync($"{EyowoConstant.URL_DEV_APP}{appID}{EyowoConstant.URL_TRANFERS}");
                Response jsonRes = HttpMResponse(response);

                return !jsonRes.success ?
                    (jsonRes.error, data: null)
                    : (error: null, jsonRes.data.GetValue("transfers"));
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetAppTransfer(string appID, string transactionID)
        {
            try
            {
                JObject response = await SecuredGetAsync($"{EyowoConstant.URL_DEV_APP}{appID}{EyowoConstant.URL_TRANFERS}{transactionID}");
                Response jsonRes = HttpMResponse(response);

                return !jsonRes.success ?
                    (jsonRes.error, data: null)
                    : (error: null, jsonRes.data.GetValue("transfer"));
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetBankTransfers(string appID)
        {
            try
            {
                JObject response = await SecuredGetAsync($"{EyowoConstant.URL_DEV_APP}{appID}{EyowoConstant.URL_TRANFERS}?type=bank");
                Response jsonRes = HttpMResponse(response);

                return !jsonRes.success ?
                    (jsonRes.error, data: null)
                    : (error: null, jsonRes.data.GetValue("transfers"));
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetEyowoTransfers(string appID)
        {
            try
            {
                JObject response = await SecuredGetAsync($"{EyowoConstant.URL_DEV_APP}{appID}{EyowoConstant.URL_TRANFERS}?type=phone");
                Response jsonRes = HttpMResponse(response);

                return !jsonRes.success ?
                    (jsonRes.error, data: null)
                    : (error: null, jsonRes.data.GetValue("transfers"));
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
    }
}
