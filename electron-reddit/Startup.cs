using ElectronNET.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using reddit_dot_net;
using System.Threading.Tasks;
using ElectronNET.API.Entities;

namespace electron_reddit
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            InitializeElectronWindow();

            //todo remove this when log in is implemented
            RedditDotNetClient.InitializeRedditClient();
        }

        public async void InitializeElectronWindow()
        {
            var options = new BrowserWindowOptions()
            {
                Show = false
            };
            
            var mainWindow = await Electron.WindowManager.CreateWindowAsync(options);
            mainWindow.OnReadyToShow += () =>
            {
                mainWindow.Show();
            };

            //CreateElectronMenu();
        }

        private static void CreateElectronMenu()
        {
            var menu = new MenuItem[]
            {
                new MenuItem
                {
                    Label = "File",
                    Submenu = new MenuItem[]
                    {
                        new MenuItem
                        {
                            Label = "Exit",
                            Click = () => { Electron.App.Exit(); }
                        }
                    }
                },

                new MenuItem
                {
                    Label = "Info",
                    Click = async () =>
                    {
                        await Electron.Dialog.ShowMessageBoxAsync("I Love Electron.Net");
                    }
                }


            };

            Electron.Menu.SetApplicationMenu(menu);
        }
    }
}
