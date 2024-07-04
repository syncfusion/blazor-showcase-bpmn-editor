using BPMNEditor.Components;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;
using BPMNEditor.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSignalR(e =>
            {
                e.MaximumReceiveMessageSize = 102400000;
            });
builder.Services.AddScoped<SfDialogService>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<SampleService>();
            // Register the Syncfusion locale service to customize the SyncfusionBlazor component locale culture
            //services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            // Define the list of cultures your app will support
            List<CultureInfo> supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("en-US"),
                new CultureInfo("de"),
                new CultureInfo("fr"),
                new CultureInfo("ar"),
                new CultureInfo("zh"),
            };
            // Set the default culture
            options.DefaultRequestCulture = new RequestCulture("en-US");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
