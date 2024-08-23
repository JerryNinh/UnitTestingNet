using FutureVision.Portal.Client;
using FutureVision.Portal.Client.Handlers;
using FutureVision.Portal.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Preconfigure an HttpClient for web API calls
builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Configuration.Bind("BOSSGateway", RestClient.BOSSGateway);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
builder.Services.AddSingleton<IStorageService, StorageService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IMailingService, MailingService>();

await builder.Build().RunAsync();
