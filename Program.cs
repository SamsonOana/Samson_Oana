using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Samson_Oana.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Samson_OanaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Samson_OanaContext") ?? throw new InvalidOperationException("Connection string 'Samson_OanaContext' not found.")));

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
