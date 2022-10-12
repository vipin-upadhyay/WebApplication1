using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using WebApplication1.Data;
using WebApplication1.Repository.IRepository;
using WebApplication1.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")
                ));
            services.AddAuthentication(options => options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/GoogleLogin";
                }).AddGoogle(option =>
                {
                    option.ClientId = "186608638772-jd94sjg8n3cqposmgcm11dr800imnrin.apps.googleusercontent.com";
                    option.ClientSecret = "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";
                    option.AccessDeniedPath = "/AccessDeniedPath";
                }).AddFacebook(options =>
                {
                    options.AppId = "768398517723364";
                    options.AppSecret = "e0a50b46b60fa8aa19f18f9ee9998761";
                    options.AccessDeniedPath = "/AccessDeniedPathInfo";
                });
            services.AddScoped<IRegistration, RegistrationRepository>();
            services.AddMvc(options => options.EnableEndpointRouting = false);

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMvc();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();

            app.UseAuthorization();

            // app.MapRazorPages();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute().RequireAuthorization();
                endpoints.MapRazorPages();
            });

        }
    }
}
