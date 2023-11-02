using Microsoft.EntityFrameworkCore;
using SchoolManagement.MVC.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//黑人添加:

//1. when the application starts up, grab me the connection string
//builder 在上面有var by電腦
//.configuration>>會去找所有app settings
//使用GetConnectionString方法
var conn= builder.Configuration.GetConnectionString("SchoolManagementDbConnection");

//2. 用剛剛那個ConnectionString
//開始建立跟資料庫“實際的”連線
//這個DB context是一個model of
//後面說的這個是該用的connection string (conn)
builder.Services.AddDbContext<SchoolManagementDbContext>(q=>q.UseSqlServer(conn));
//黑人添加止

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
