using FECoffeeShop.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
//Intentando agregar inyecci�n de dependencias para un HttpClient como antes se hac�a en startup.cs, validar c�mo cambiar esta URI para cuando ya est� arriba el API
builder.Services.AddSingleton(new HttpClient
{
    //BaseAddress = new Uri("https://localhost:44369")
    BaseAddress = new Uri("https://coffeeshopbackend.somee.com")
});

//truco para ignorar el certificado por el https NOTA: Validar si debo removerlo una vez en producci�n
var myHttpClientHandler = new HttpClientHandler();
myHttpClientHandler.ServerCertificateCustomValidationCallback =
    (message, cert, chain, errors) => true;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
