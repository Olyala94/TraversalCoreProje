using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.Models;

namespace TraversalCoreProje
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<GetAllDestinationQueryHandler>();
            services.AddScoped<GetDestinationByIDQueryHandler>();
            services.AddScoped<CreateDestinationCommandHandler>();
            services.AddScoped<RemoveDestinationCommandHandler>();
            services.AddScoped<UpdateDestinationCommandHandler>();

            services.AddMediatR(typeof(Startup)); //typeof(startup) dediðimiz kýsýmda startup dosyasýyla ayný namespacede olan dosyalar için verdiðimiz dependency injection çalýþsýn demek istiyoruz. .Net6 için typeof(Program) diyoruz.

             //typeof:                                    
            //typeof bir JavaScript operatörüdür. Bu operatör, belirli bir deðerin veri türünü döndürmek için kullanýlýr. JavaScript'te typeof operatörü genellikle deðiþkenlerin veya deðerlerin veri türünü kontrol etmek veya karþýlaþtýrmak için kullanýlýr.
           // typeof operatörü, bir argüman olarak alýnan deðerin veri türünü bir dize olarak döndürür.


                        services.AddLogging(x=> 
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);  
                x.AddDebug();   
            });

            services.AddDbContext<Context>();
            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();

            services.AddHttpClient();

            services.ContainerDependencies();

            services.AddAutoMapper(typeof(Startup));
            //burada kaldýk
            // services.AddTransient<IValidator<AnnouncementAddDto>, AnnouncementValidator>();

            services.CustomerValidator();

            services.AddControllersWithViews().AddFluentValidation();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddMvc();
//Eðer bir kullanýcý Authenticate olmadan giriþ yapmýþsa buraya yönlendir  anlamý taþýyor!!!!!
            services.ConfigureApplicationCookie(options => 
            {
                options.LoginPath = "/Login/SignIn/";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            var suppertedCultures = new[] { "en", "fr", "es", "gr", "tr", "de" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(suppertedCultures[1]).AddSupportedCultures(suppertedCultures).AddSupportedUICultures(suppertedCultures);
            app.UseRequestLocalization(localizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
