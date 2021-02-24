namespace EyowoSDK
{
    internal class EyowoConstant
    {
        internal static readonly string URL_AUTH_INIT = "/users/auth";
        internal static readonly string URL_AUTH_REFRESH_TOKEN = "/users/accessToken";
        internal static readonly string URL_AUTH_VALIDATE = "/users/auth/validate";
        internal static readonly string URL_TRANSFER_EYOWO = "/users/transfers/phone";
        internal static readonly string URL_TRANSFER_BANK = "/users/transfers/bank";
        internal static readonly string URL_TRANSFER_REQUERY_BANK = "/users/transfers/requery/bank/";
        internal static readonly string URL_WELLET_ID = "/apps/wallet/";
        internal static readonly string URL_WELLETS = "/apps/wallets/";
        internal static readonly string URL_QUERY_BVN = "/queries/bvn?bvn=";
        internal static readonly string URL_QUERY_BANK = "/queries/banks";
        internal static readonly string URL_CREATE_USER = "/users/create";
        internal static readonly string URL_DEV_AUTH = "/auth/login";
        internal static readonly string URL_TRANX = "/transactions/";
        internal static readonly string URL_TRANFERS = "/transfers/";
        internal static readonly string URL_VTU_PURCHASE = "/users/payments/bills/vtu";
        internal static readonly string URL_DEV_APP = "/apps/";
        internal static readonly string DEV_APP_TRANX = "transactions";

        internal static readonly string BASE_URL_V1 = "https://api.console.staging-api.eyowo.com/v1";
        internal static readonly string BASE_URL_PROD_V1 = "https://api.console.eyowo.com/v1";
        internal static readonly string BASE_DEV_URL_V1 = "https://api.developer.staging-api.eyowo.com/v1";
        internal static readonly string BASE_DEV_URL_PROD_V1 = "https://api.developer.staging-api.eyowo.com/v1";
    }
}
