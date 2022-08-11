using AdminDiplomacyAPP.Concrete;
using AdminDiplomacyAPP.Concrete.BoldReport;
using AdminDiplomacyAPP.Contract;
using AdminDiplomacyAPP.Contract.BoldReport;
using AdminDiplomacyAPP.Data;
using AdminDiplomacyAPP.Services;
using Blazored.SessionStorage;
using BlazorStrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;



namespace AdminDiplomacyAPP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient(client => new HttpClient { BaseAddress = new Uri(Configuration.GetValue<string>("APIURL1:BaseUrl")) });
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredSessionStorage();
            services.AddSyncfusionBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddTransient<ILogin, LoginUser>();
            services.AddTransient<AccountService>();
            services.AddTransient<IJobRegister, JobRegister>();
            services.AddTransient<ISMSManager, SMSManager>();
            services.AddBootstrapCss();
            services.AddScoped<ClipboardService>();
            services.AddTransient<IBoldReportManager, BoldReportManager>();
            services.AddTransient<IItemMasterManager, ItemMasterManager>();
            services.AddTransient<IOrderingCartManager, OrderingCartManager>();
            services.AddTransient<GeneralServices>();
            // Services.AddBootstrapCss();
            services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjUzMTA0QDMyMzAyZTMxMmUzMFJHdVFabnZ4M3BhdnpzMDQrbDhBWG5QYktmcEwxOS9qRExZRFdYTUljME09");
            //Register BoldReport license
            Bold.Licensing.BoldLicenseProvider.RegisterLicense("H35tjXWi+KGAe+ZrSbc99mpX8AihM/x/3yr6iak0JWY=");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            app.UseFileServer(new FileServerOptions
            {
                //FileProvider = new PhysicalFileProvider(@"D:\Blazor\Out Source\Afshad\Diplomacy\Test\wwwroot\uploads\"),
                //FileProvider = new PhysicalFileProvider(@"D:\Orison\Blazor\Diplomacy\Test\wwwroot\uploads\"),
             FileProvider = new PhysicalFileProvider(@"E:/Orison Android/ApiWS/wwwroot/uploads/"),
                 // FileProvider = new PhysicalFileProvider(@"D:\SPMS\Diplomacy (1)\Diplomacy\Test\wwwroot\uploads\"),
                RequestPath = new PathString("/Muploads"),
                EnableDirectoryBrowsing = false
            });
        }
    }
}
