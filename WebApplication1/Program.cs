using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<WebApplication1Context>((Action<DbContextOptionsBuilder>?)(options =>
    options.UseSqlServer((string)(NewMethod(builder) ?? throw new InvalidOperationException("Connection string 'WebApplication1Context' not found.")))));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();

static string? NewMethod(WebApplicationBuilder builder)
{
    return builder.Configuration.GetConnectionString("WebApplication1Context");
}