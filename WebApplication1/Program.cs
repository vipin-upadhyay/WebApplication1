using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Repository;
using WebApplication1.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddAuthentication(options=>options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
{
    options.LoginPath = "/Login/GoogleLogin";
}).AddGoogle(option =>
{
    option.ClientId = "186608638772-jd94sjg8n3cqposmgcm11dr800imnrin.apps.googleusercontent.com";
    option.ClientSecret = "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";
    option.AccessDeniedPath = "/AccessDeniedPath";
}).AddFacebook(options => {
    options.AppId = "768398517723364";
    options.AppSecret = "e0a50b46b60fa8aa19f18f9ee9998761";
    options.AccessDeniedPath = "/AccessDeniedPathInfo";
});
builder.Services.AddScoped<IRegistration, RegistrationRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseMvc();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization(); 
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
