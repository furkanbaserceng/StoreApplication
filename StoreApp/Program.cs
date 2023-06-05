using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RepositoryContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("mssqlserverconnection"),
        b=>b.MigrationsAssembly("StoreApp"));
    //options.EnableSensitiveDataLogging();
    
});

builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();

builder.Services.AddAutoMapper(typeof(Program));




var app = builder.Build();

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

app.UseEndpoints(endpoints =>
{

    endpoints.MapAreaControllerRoute(

            name: "Admin",
            areaName: "Admin",
            pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"

        );

    endpoints.MapControllerRoute(

            name:"default",
            pattern: "{controller=Home}/{action=Index}/{id?}"

        );


});


app.Run();
