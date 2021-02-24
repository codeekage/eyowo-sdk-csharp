using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EyowoSDK.EyowoApp
{
    public class EyowoApp : EyowoHttpController
    {
        public EyowoApp(string httpBaseURL, string appKey, string refreshToken)
            : base(httpBaseURL, appKey, refreshToken)
        {
        }

        public async Task<(string error, object data)> BankTransferAsync(
           string accountNumber,
           long amount, string accountName, string bankCode)
        {
            try
            {
                object body = new { accountNumber, amount, bankCode, accountName };
                JObject response = await SecuredPostAsync(EyowoConstant.URL_TRANSFER_BANK, body);
                Response json = HttpMResponse(response);

                return !json.success ?
                   (json.error, data: null)
                  : (error: null, json.data);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetBankTransferStatus(string transactionRef)
        {
            try
            {
                JObject response = await SecuredGetAsync($"{EyowoConstant.URL_TRANSFER_REQUERY_BANK}{transactionRef}");
                Response json = HttpMResponse(response);

                return !json.success ?
                (json.error, data: null)
               : (error: null, json.data);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetWalletByIdAsync(string walletID)
        {
            try
            {
                JObject response = await SecuredGetAsync($"{EyowoConstant.URL_WELLET_ID}{walletID}");
                Response json = HttpMResponse(response);

                return !json.success ?
                (json.error, data: null)
                : (error: null, json.data.GetValue("wallet"));

            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetWalletsAsync()
        {
            try
            {
                JObject response = await SecuredGetAsync(EyowoConstant.URL_WELLETS);
                Response json = HttpMResponse(response);

                return !json.success ?
                (json.error, data: null)
                : (error: null, json.data.GetValue("wallets"));
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        public async Task<(string error, object data)> QueryBVNAsync(string bvnNumber)
        {
            try
            {
                JObject response = await SecuredGetAsync($"{EyowoConstant.URL_QUERY_BVN}{bvnNumber}");
                Response json = HttpMResponse(response);

                return !json.success ?
                (json.error, data: null)
               : (error: null, json.data);

            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetBanksAsync()
        {
            try
            {
                JObject response = await SecuredGetAsync(EyowoConstant.URL_QUERY_BANK);
                Response json = HttpMResponse(response);

                return !json.success ?
                 (json.error, data: null)
                : (error: null, json.data);

            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        public async Task<(string error, object data)> CreateUserAsync(string accountNumber)
        {
            try
            {
                var content = new { mobile = $"234{accountNumber}" };
                JObject response = await SecuredPostAsync(EyowoConstant.URL_CREATE_USER, content);
                Response json = HttpMResponse(response);

                return !json.success ?
                 (json.error, data: null)
                : (error: null, json.data);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        public async Task<(string error, object data)> EyowoTransferAsync(string accountNumber, string amount)
        {
            try
            {
                string mobile = $"234{accountNumber}";
                object body = new { mobile, amount };
                JObject response = await SecuredPostAsync(EyowoConstant.URL_TRANSFER_EYOWO, body);
                Response json = HttpMResponse(response);

                return !json.success ?
                 (json.error, data: null)
                : (error: null, json.data);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        public async Task<(string error, object data)> VtuPurchaseAsync(
                string mobile,
                string amount,
                string provider
            )
        {
            try
            {
                object body = new { mobile, amount, provider };
                JObject response = await SecuredPostAsync(EyowoConstant.URL_VTU_PURCHASE, body);
                Response json = HttpMResponse(response);

                return !json.success ?
                 (json.error, data: null)
                : (error: null, json.data);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetWalletTransactions()
        {
            try
            {
                JObject response = await SecuredGetAsync(EyowoConstant.URL_TRANX);
                Response json = HttpMResponse(response);

                return !json.success ?
                 (json.error, data: null)
                : (error: null, json.data);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }

        public async Task<(string error, object data)> GetWalletTransaction(string transactionRef)
        {
            try
            {
                JObject response = await SecuredGetAsync($"{EyowoConstant.URL_TRANX}{transactionRef}");
                Response json = HttpMResponse(response);

                return !json.success ?
                 (json.error, data: null)
                : (error: null, json.data);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex}");
            }
        }
    }
}
