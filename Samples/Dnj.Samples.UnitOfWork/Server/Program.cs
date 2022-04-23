using Dnj.Samples.UnitOfWork.Server.Data;
using Dnj.Samples.UnitOfWork.Server.Services;
using Microsoft.AspNetCore.Localization;
using System.Reflection;
using Dnj.Shared.Net.Data.Abstractions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDnjSqLite<UnitOfWorkContext>(connectionString);
builder.Services.AddScoped<UnitOfWorkService>();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddViewLocalization().AddDataAnnotationsLocalization(options =>  
{  
    options.DataAnnotationLocalizerProvider = (type, factory) =>  
    {  
        var assemblyName = new AssemblyName(typeof(Dnj.Samples.UnitOfWork.Shared.UnitOfWorkDto).GetTypeInfo().Assembly.FullName);
        return factory.Create("UnitOfWorkDto", assemblyName.Name);  
    };  
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var serviceScope = app.Services.CreateScope())
    {
        var services = serviceScope.ServiceProvider;
        services.GetRequiredService<UnitOfWorkContext>().Database.EnsureCreated();
        SeedData.Initialize(services);
    }
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture("es-ES")
    .AddSupportedCultures("es-ES", "en-UK", "en-US");
app.UseRequestLocalization(localizationOptions);

app.Run();
