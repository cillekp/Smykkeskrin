using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smykkeskrin.Repo;
using Smykkeskrin.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();

//user
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();
//smykker
builder.Services.AddScoped<IJewleryRepository, JewleryRepository>();
builder.Services.AddScoped<JewleryService>();
//feed
builder.Services.AddScoped<IFeedRepository, FeedRepository>();
builder.Services.AddScoped<FeedService>();

var app = builder.Build();

app.UseRouting();

app.UseSession();
app.UseAuthorization();
