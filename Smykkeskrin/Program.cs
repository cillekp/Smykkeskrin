using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smykkeskrin.Repo;
using Smykkeskrin.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrer dine repositories og services i DI-containeren
builder.Services.AddTransient<IFeedRepository, FeedRepository>();
builder.Services.AddTransient<FeedService>();

// (Husk også denne, hvis du bruger UserRepository i din service)
builder.Services.AddTransient<IUserRepository, UserRepository>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();