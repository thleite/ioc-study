using ioc_container.Interfaces;
using ioc_container.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IScopedOperation,Operation>();
builder.Services.AddTransient<ITransientOperation,Operation>();
builder.Services.AddSingleton<ISingletonOperation,Operation>();
builder.Services.AddSingleton<ISingletonInstanceOperation>(new Operation(Guid.Empty));

builder.Services.AddScoped<OperationService>();

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
