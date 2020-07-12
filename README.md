# 1ot

## Introduction

1ot makes it easy to maintain SIM cards and their data plans/usage all over the world. More about 1ot on the [website](https://1ot.mobi).

The 1ot dotnet NuGet package makes it easier to use the 1ot API from your dotnet projects (netstandard2.0+) projects without having to build your own API calls. You can get your credentials (username and password from the API app in the 1ot terminal) token at [https://terminal.1ot.mobi/terminal-api](https://terminal.1ot.mobi/terminal-api).

The documentation that this Client is built on is available on the 1ot terminal [https://terminal.1ot.mobi/terminal-api-doc](https://terminal.1ot.mobi/terminal-api-doc).

### Notes

>You cannot access the api documentation without logging into the terminal which means you need to buy some SIM cards or be invited by someone who has bought some SIM cards.

To use the API you must first enable the API app in the App Store. Enabling the API App attracts an additional cost of 0.04 EUR/active SIM per month. All active SIMs are counted even if they are not accessed via the API.

To enable the API app:

1. Login to your terminal [https://terminal.1ot.mobi/login](https://terminal.1ot.mobi/login)
2. Go to the `App Store` tab [https://terminal.1ot.mobi/addons](https://terminal.1ot.mobi/addons)
3. Find `API` and toggle the switch to enable it.

To get your API credentials (username and password)

1. Ensure API app is enabled
2. From the top access the `Apps` tab and click on `API` or directly go to [https://terminal.1ot.mobi/terminal-api](https://terminal.1ot.mobi/terminal-api)
3. The Username displayed is the value to use for the `username`. Copy it
4. Click on `Generate new password` to get a new password. Copy it and keep it safe and hidden because it shall not be show again.

To use the diagnostics feature via the API, in addition to enabling the API App above, you also need to enable the Diagnostics App. This attracts and additional cost of 0.03 EUR/active SIM per month.

To enable the Diagnostics app:

1. Login to your terminal [https://terminal.1ot.mobi/login](https://terminal.1ot.mobi/login)
2. Go to the `App Store` tab [https://terminal.1ot.mobi/addons](https://terminal.1ot.mobi/addons)
3. Find `Diagnostics` and toggle the switch to enable it.

### Issues

Some APIs are documented as returning `application/json` content types and the model even specified. However, this is not the case when you make a request. For example, setting the name using https://api.1ot.mobi/v1/set_name or `client.SetNameAsync(...)` results in `text/plain` and the body is just `OK`. This does nto change even if you set the `Accept` header to `application/json`.

In such cases, you should not read the `Resource` property in the reponse because the client does not attempt to deserialize the response into an object. Instead, only check if the request has been successful using the `IsSuccessful` property.

I will update the  library once the API is updated to behave as documented.

### Naming

The product and company name is 1ot. However, in C# (generally all programming languages), names for types, methods, variables,  and properties can only start with a letter or underscore. .NET further recommends that names of types, methods and properties start with a capital letter. This is why I chose to name the types in reverse domain, i.e. Mobi1ot is gotten from iot.mobi reversed.

### Installation

To install using Package Manager Console use:
> Install-Package 1ot  
> Install-Package 1ot.Extensions.DependencyInjection

To install using dotnet cli use:
> dotnet add 1ot  
> dotnet add 1ot.Extensions.DependencyInjection

Alternatively, you can use the NuGet package manager in Visual Studio by searching for `1ot` or `1ot.Extensions.DependencyInjection` and then click install.

### Usage

```csharp
var options = new Mobi1otClientOptions
{
    Username = "your-username-here",
    Password = "your-password-here"
};
var client = new Mobi1otClient(options);

var response = await client.GetAccountSimsAsync();
var resource = response.Resource;
Console.WriteLine($"Found {resource.Found} of {resource.Total} from {resource.Offset} offset");
var simcards = resource.Sims;
foreach (var sim in simcards)
{
    Console.WriteLine($"MSISDN: {sim.MSISDN}");
    Console.WriteLine($"Name: {sim.Name}");
    Console.WriteLine($"IMEI: {sim.IMEI}");
    Console.WriteLine($"IMSI: {sim.IMSI}");
    Console.WriteLine($"Status: {sim.Status.GetDescription()}");
    Console.WriteLine("=====================");
}
```

See [examples](./examples/) for more.

### Issues &amp; Comments

Please leave all comments, bugs, requests, and issues on the Issues page. We'll respond to your request ASAP!

### License

The Library is licensed under the [MIT](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form") license. Refere to the [LICENSE](./LICENSE.md) file for more information.
