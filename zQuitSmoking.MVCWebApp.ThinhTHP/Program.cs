using zQuitSmoking.Repositories.ThinhTHP;
using zQuitSmoking.Services.ThinhTHP;

var builder = WebApplication.CreateBuilder(args);

// DI
builder.Services.AddScoped<IServiceProviders, ServiceProviders>();
//builder.Services.AddScoped<zQuitSmoking.Repositories.ThinhTHP.DBContext.SE18_PRN222_SE1809_G6_QuitSmokingDBContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services to the container.
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
