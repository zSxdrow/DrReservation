using Dr.Application.Interfaces.DbContext;
using Dr.Application.Interfaces.FacadeDesignPattern.AppoinmentFacade;
using Dr.Application.Interfaces.FacadeDesignPattern.CategoryFacade;
using Dr.Application.Interfaces.FacadeDesignPattern.UsersFacade;
using Dr.Application.Services.Appoinments.Command;
using Dr.Application.Services.Appoinments.Facade;
using Dr.Application.Services.Categories.Facade.CategoryFacade;
using Dr.Application.Services.Users.FacadePattern;
using Dr.Domain.Entities.Reserves;
using Dr.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//DI

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IUsersFacade, UserFacade>();
builder.Services.AddScoped<ICategoryFacade, CategoryFacade>();
builder.Services.AddScoped<IAppoinmentFacade, AppoinmentFacade>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
