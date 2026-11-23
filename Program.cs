using Microsoft.EntityFrameworkCore;
using VolchukRazorGames.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("VolchukRazorGamesContext") ?? throw new InvalidOperationException("Connection string 'VolchukRazorGamesContext' not found.");

builder.Services.AddDbContext<VolchukRazorGamesContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // вимагає від браузерів спілкуватися з сервером виключно через безпечне з'єднання HTTPS
    app.UseHsts();
}

// автоматично перенаправляє будь-які незахищені HTTP-запити на безпечний протокол HTTPS
app.UseHttpsRedirection();

// активує систему маршрутизації, яка допомагає додатку визначити, який шлях має обробити вхідний запит
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
