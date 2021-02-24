# eyowo-sdk-csharp
Eyowo Developer SDK extends Eyowo core features to third party engineers to build products that contribute to solve financial exclusion in Nigeria and beyond Africa.

# Introduction
The SDK allows you to build CSharp fintech applications seamlessly while relying on Eyowo's Curated Developer Toolkit.


# Getting Started

## Installation
You can either install the NuGet package directly from Visual Studio or use the `Install-Package` command.

[NuGet Package](https://www.nuget.org/packages/codeekage.eyowo.sdk/0.0.2)

```shell
Install-Package codeekage.eyowo.sdk -Version 0.0.2
```

## Usage
The SDK covers a range of useful features to make building a custom fintech application in CSharp easy.

First, complete the [signup](https://eyowo.gitbook.io/eyowo-developer-apis/getting-started/user-account-and-developer-mode) follow here and head back to start building your custom make fintech application.

Note: This SDK is functionality governed by the Federal Republic of Nigeria, do not be consume this SDK if you're not in Nigeria.

### Creating An App

```csharp

using System;
using System.Threading.Tasks;
using EyowoSDK.EyowoDeveloper;

namespace EyowoTestFlight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            EyowoDeveloper eyowoDeveloper = new EyowoDeveloper(
                   httpBaseURL: "https://api.developer.staging-api.eyowo.com/v1",
                   email: "codeekage@xxx.ng",
                   password: "xxxxxxx"
                );

            (string error, object data) = await eyowoDeveloper.CreateAppAsync(
                appName: "Test Flight Application");
            
            if(error != null)
            {
                Console.WriteLine($"Failed to create application. Here's why: {error}");
                return;
            }
            Console.WriteLine($"Application {data}");
        }
    }
}
```
> #### Console Output
```json
Application {
  "app": {
    "disabled": false,
    "settings": {
      "cardProcessingEnabled": false,
      "userCreationEnabled": false,
      "bvnCheckAmount": 1500,
      "developerMode": "test",
      "appTags": [],
      "_id": "6036a708xxxxxxxx"
    },
    "_id": "6036a70xxxxxxxxx",
    "deleted": false,
    "developerID": "5cxxxxxxx",
    "name": "Test Flight Application",
    "key": "pk_live_xxxxxxxx",
    "sandboxKey": "sk_test_xxxxxx",
    "wallets": [],
    "createdAt": "2021-02-24T19:20:40.241Z",
    "updatedAt": "2021-02-24T19:20:40.241Z",
    "__v": 0
  }
}
```

### Send Authentication Request

```csharp
using System;
using EyowoSDK.EyowoAuth;
using System.Threading.Tasks;

namespace EyowoTestFlight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Clear();
            EyowoAuthAppWallet eyowoAuthApp = new EyowoAuthAppWallet(
                   httpBaseURL: "https://api.console.staging-api.eyowo.com/v1",
                   appKey: "pk_live_3c23ssss"
                );

            (string error, string message) = await eyowoAuthApp.SendAuthRequestAsync(
                accountNumber: "70662xxxx",
                factor: "sms"
               );

            if (error != null)
            {
                Console.WriteLine($"Failed to send authentication Request. Here's why: {error}");
                return;
            }
            Console.WriteLine($"Message {message}");
        }
    }
}

```

> #### Console Output

```json
Message Please enter passcode sent to 234XXXXXXX
```

### Add Account Wallet to App

```csharp
using System;
using EyowoSDK.EyowoAuth;
using System.Threading.Tasks;

namespace EyowoTestFlight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            EyowoAuthAppWallet eyowoAuthApp = new EyowoAuthAppWallet(
                   httpBaseURL: "https://api.console.staging-api.eyowo.com/v1",
                   appKey: "pk_live_3c232xxxxxx"
                );

            (string error, string message, object data) = await eyowoAuthApp.AuthAccount(
                accountNumber: "70xxxxxx",
                factor: "sms",
                passcode: "505xxx"
                );

            if (error != null)
            {
                Console.WriteLine($"Failed to add application wallet. Here's why: {error}");
                return;
            }
            Console.WriteLine($"Application {data}");
            Console.WriteLine($"Message {message}");
        }
    }
}
 ```
 
> #### Console Output

```json

Application
{
  "refreshToken": "6036ac9b8c260878xxxxxxxxx",
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.exxxxxxxxx",
  "expiresIn": 86400
}
Message Wallet added successfully

```

### Eyowo Transfer

```csharp
using System;
using System.Threading.Tasks;
using EyowoSDK.EyowoApp;

namespace EyowoTestFlight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Clear();
            EyowoApp eyowoApp = new EyowoApp(
                   httpBaseURL: "https://api.console.staging-api.eyowo.com/v1",
                   appKey: "pk_live_3c2328dd21c64xxxxxx",
                   refreshToken: "6036ac9b8c2608xxxxxxx"
                );

            (string error, object data) = await eyowoApp.EyowoTransferAsync(
                accountNumber: "70662xxxx",
                amount: "33300"
             );

            if (error != null)
            {
                Console.WriteLine($"Failed to create application. Here's why: {error}");
                return;
            }
            Console.WriteLine($"Application {data}");
        }
    }
}
```
> #### Console Output
```shell
Application {
 "transaction": {
    "reference": "6036b7648xxxxxx",
    "amount": 3333
  }
}
````

### Bank Transfer

```csharp
using System;
using EyowoSDK.EyowoAuth;
using System.Threading.Tasks;
using EyowoSDK.EyowoApp;

namespace EyowoTestFlight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Clear();
            EyowoApp eyowoApp = new EyowoApp(
                   httpBaseURL: "https://api.console.staging-api.eyowo.com/v1",
                   appKey: "pk_live_3c2328dd2xxxxxxxxx",
                   refreshToken: "6036ac9b8c2608xxxxxxxxxx"
                );

            (string error, object data) = await eyowoApp.BankTransferAsync(
                accountName: "CODEEKAGE BUILDS",
                accountNumber: "30849xxxx",
                amount: 33300,
                bankCode: "000016"
             ) ;

            if (error != null)
            {
                Console.WriteLine($"Failed to create application. Here's why: {error}");
                return;
            }
            Console.WriteLine($"Application {data}");
        }
    }
}

```

> #### Console Output

```json
Application {
  "transaction": {
    "amount": 33300,
    "accountName": "DAMBATTA MARYAM LAMI",
    "transactionReference": "6036b0f5xxxxxxx",
    "statusCode": "000002"
  }
}
```

### Requery Bank Transfer (GetBankTransferStatus)

```csharp

using System;
using EyowoSDK.EyowoAuth;
using System.Threading.Tasks;
using EyowoSDK.EyowoApp;

namespace EyowoTestFlight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Clear();
            EyowoApp eyowoApp = new EyowoApp(
                   httpBaseURL: "https://api.console.staging-api.eyowo.com/v1",
                   appKey: "pk_live_3cxxxxxx",
                   refreshToken: "6036ac9b8cxxxxxxxxxxxxx"
                );

            (string error, object data) = await eyowoApp.GetBankTransferStatus(
              transactionRef: "6036b0f5xxxxxxxx"
             ) ;

            if (error != null)
            {
                Console.WriteLine($"Failed to create application. Here's why: {error}");
                return;
            }
            Console.WriteLine($"Application {data}");
        }
    }
}
```

> #### Console Output 
```shell
Application 
{
  "transaction": {
    "statusMessage": "success",
    "statusCode": "000000"
  }
}
```

### Query BVN Number

```csharp
using System;
using EyowoSDK.EyowoAuth;
using System.Threading.Tasks;
using EyowoSDK.EyowoApp;

namespace EyowoTestFlight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Clear();
            EyowoApp eyowoApp = new EyowoApp(
                   httpBaseURL: "https://api.console.staging-api.eyowo.com/v1",
                   appKey: "pk_live_3c2328xxxxxxxx",
                   refreshToken: "6036ac9b8cxxxxxx"
                );

            (string error, object data) = await eyowoApp.QueryBVNAsync(
              bvnNumber: "2235xxxxx"
             ) ;

            if (error != null)
            {
                Console.WriteLine($"Failed to create application. Here's why: {error}");
                return;
            }
            Console.WriteLine($"Application {data}");
        }
    }
}
```
> #### Console Output
```shell
 Application {
  "firstName": "RASHEED",
  "surname": "AJALA",
  "mobileNumber": "080xxxxxxx",
  "middleName": "UCHE",
  "dateOfBirth": "1998-04-29"
}

```

### VTU (Virtual Top-Up) Purchase

```csharp
using System;
using EyowoSDK.EyowoAuth;
using System.Threading.Tasks;
using EyowoSDK.EyowoApp;

namespace EyowoTestFlight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Clear();
            EyowoApp eyowoApp = new EyowoApp(
                   httpBaseURL: "https://api.console.staging-api.eyowo.com/v1",
                   appKey: "pk_live_3c2328dd2xxxxxxxx",
                   refreshToken: "6036ac9b8c260xxxxxx"
                );

            (string error, object data) = await eyowoApp.VtuPurchaseAsync(
              amount: "2260",
              mobile: "234706xxxxxx",
              provider: "mtn"
             ) ;

            if (error != null)
            {
                Console.WriteLine($"Failed to purchase airtime. Here's why: {error}");
                return;
            }
            Console.WriteLine($"Application {data}");
        }
    }
}
```

> #### Console Output
```shell
Application
 "transaction": {
    "reference": "6036b45b8c2xxxxxxx",
    "amount": 2260
  }
```

### Get Wallet Transaction by TransactionRef

```csharp
using System;
using EyowoSDK.EyowoAuth;
using System.Threading.Tasks;
using EyowoSDK.EyowoApp;

namespace EyowoTestFlight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Clear();
            EyowoApp eyowoApp = new EyowoApp(
                   httpBaseURL: "https://api.console.staging-api.eyowo.com/v1",
                   appKey: "pk_live_3c2328dxxxx",
                   refreshToken: "6036ac9b8xxxxxxx"
                );

            (string error, object data) = await eyowoApp.GetWalletTransaction(
              transactionRef: "6036b45b8cxxxxxx"
             ) ;

            if (error != null)
            {
                Console.WriteLine($"Failed to get this wallet transaction. Here's why: {error}");
                return;
            }
            Console.WriteLine($"Application {data}");
        }
    }
}
```

> #### Console Output

```shell
  "transaction": {
    "_id": "6036b45b8xxxxxx",
    "amount": 2260,
    "reference": "6036b45xxxxxxx",
    "type": "bills",
    "recipient": {
      "metadata": {
        "billerName": "mtn",
        "billCustomerID": "23470xxxxxxxxx",
        "billType": "vtu"
      }
    },
    "createdAt": "2021-02-24T20:17:31.657Z",
    "updatedAt": "2021-02-24T20:17:31.657Z"
  }
```


Other Functionalities

| Namespace | Class | MethodName | Parameters| Description |
|-----------| ------ | ---------- | --------| ------------ |
| EyowoSDK.EyowoApp | EyowoApp | GetWalletTransactionsAsync | `none` | Gets all application transaction done with the wallet token |
| EyowoSDK.EyowoApp | EyowoApp | GetBanksAsync | `none` | Get all banks and their respective CBN bank codes in Nigeria |
| EyowoSDK.EyowoApp | EyowoApp | GetWalletsAsync | `none` | Get all wallets associated with the `appKey` |
| EyowoSDK.EyowoApp | EyowoApp | GetWalletByIdAsync | `string walletID` | Get wallet with the assoicated `appKey` and `walletID` |
| EyowoSDK.EyowoDeveloper | EyowoDeveloper | GetAppsAysnc | `none` | Get all apps with the assoicated developer account | 
| EyowoSDK.EyowoDeveloper | EyowoDeveloper | GetAppAysnc | `string appID` | Get all apps with the assoicated developer account and `appID` |
| EyowoSDK.EyowoDeveloper | EyowoDeveloper | GetAppTransaction | `string appID` `string transactionID` | Get transaction with the specified `appID` and `transactionID` | 
| EyowoSDK.EyowoDeveloper | EyowoDeveloper | GetAppTransactions | `none` | Get all transactions with the specified `appID` | 
| EyowoSDK.EyowoDeveloper | EyowoDeveloper | GetAppTransfer | `none` | Get all transfers with the specified `appID`. Both eyowo and bank transfers. | 


## Final Notes

Please, contributions are welcomed. 

- See a bug? 🐛  : File an issue
- Have an idea? 💡 : Send a PR
- Have a question? 🙋 : 📧  codeekagebuilds@gmail.com
- CSharp doesn't fit my use-case 😥 : Check out [Eyowo's RESTFul](eyowo.gitbook.io)

**I'll love to see what you build. ❤️ 🍾 **


