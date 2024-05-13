using Microsoft.EntityFrameworkCore;
using Test.Web.Helper;
using Test.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// veritabani baglantisi
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
    }
);

//singleton için oluşturulacak interface ile hangi nesneyi üreteceğini söylüyoruz.
//builder.Services.AddSingleton<IHelper,Helper> ();

//scoped için
//builder.Services.AddScoped<IHelper, Helper>();

//transient // sp service providerın kısaltması 
// isConfiguration değerini bilmediği için üretemiyor.
//ancak daha önce oluşturulmuş bir şeyse AppDbContext gibi bunu yapmana gerek yok parametreli constructoruna verebilirsin.
builder.Services.AddTransient<IHelper, Helper>(sp =>
{
    return new Helper(true);
});

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
    pattern: "{controller=Ornek}/{action=Index}/{id?}");

app.Run();
