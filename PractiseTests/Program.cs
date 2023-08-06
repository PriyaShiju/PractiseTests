using PractiseTests.Services;
using PractiseTests.Data;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Identity;
using PractiseTests.Data.Entities;
using Microsoft.EntityFrameworkCore;
using PractiseTests.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDbContext"); 
builder.Services.AddDbContext<CertificationDbContext>(options => options.UseSqlServer(connectionString)); 
builder.Services.AddDefaultIdentity<PractiseTestsUser>()
                                            .AddEntityFrameworkStores<CertificationDbContext>();

//builder.Services.AddDbContext<CertificationDbContext>();
//builder.Services.AddTransient<CertificationSeeder>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IMailService,MailService>();
//builder.Services.AddIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<CertificationDbContext>();

//builder.Services.TryAddScoped<UserManager<StoreUser>>();
//builder.Services.TryAddScoped<SignInManager<StoreUser>>();
builder.Services.AddScoped<ICertificationRepository,CertificationRepository>();
builder.Services.AddScoped<IPractiseTestListRepository, PractiseTestListRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();

//.addNewtonsoft

builder.Services.AddRazorPages();
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
