using Microsoft.EntityFrameworkCore;
using NewToDoListApp.Data;

var builder = WebApplication.CreateBuilder(args);

// افزودن سرویس‌ها به کانتینر
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// پیکربندی مسیرهای HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}"); // تغییر مسیر پیش‌فرض به TaskController و اکشن Index

app.Run();
