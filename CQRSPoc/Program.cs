using Carter;
using CQRSPoc;
using CQRSPoc.Caching;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<ICacheService, CacheService>();

builder.Services.AddMediatR(ApplicationAssembly.Instance);

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

app.MapCarter();

app.Run();
