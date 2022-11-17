using Microsoft.EntityFrameworkCore;
using WalletPlus_Inc.Web.Data;
using WalletPlus_Inc.Web.Data.Repositories;
using WalletPlus_Inc.Web.Data.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(c =>
                c.UseSqlServer("Server=DESKTOP-VOKVPSM; Database=WalletPlusIncDb; Trusted_Connection=True;"));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


var serviceProvider = app.Services.GetRequiredService<IServiceProvider>();
using (var scope = serviceProvider.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await SeedHelper.InitializeData(context);

}

app.Run();
