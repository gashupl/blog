using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pg.SfGridCustomButtons.Client;
using Pg.SfGridCustomButtons.Client.Data;
using Syncfusion.Blazor;
using System.ComponentModel.Design;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSyncfusionBlazor();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ISectionRepository, SectionRepository>();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration["Licensing:Syncfusion"]);

await builder.Build().RunAsync();
