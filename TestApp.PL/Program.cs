using TestApp.BLL.Dependency_Injection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//Custom dependency injection
builder.Services.AddDependencies();
var app = builder.Build();

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
    pattern: "{controller=Product}/{action=Get}/{id?}");

app.Run();
