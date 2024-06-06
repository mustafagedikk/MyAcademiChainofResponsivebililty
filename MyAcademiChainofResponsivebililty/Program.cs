using Microsoft.EntityFrameworkCore;
using MyAcademiChainofResponsivebililty.ChainOfResponsivibility;
using MyAcademiChainofResponsivebililty.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<Clerk>();
builder.Services.AddScoped<AssistantManager>();
builder.Services.AddScoped<Manager>();
builder.Services.AddScoped<RegionalManager>();
// Add services to the container.
builder.Services.AddDbContext<CoFContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});
builder.Services.AddControllersWithViews();

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

app.Run();
