using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConfigSample
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var cfgBuilder = new ConfigurationBuilder();
            cfgBuilder.SetBasePath(env.ContentRootPath);
            cfgBuilder.AddJsonFile("configCore.json", false, true);
            cfgBuilder.AddJsonFile("configMaster.json", false, true);
            cfgBuilder.AddJsonFile("configSlave.json", false, true);
            //cfgBuilder.AddXmlFile

            Configuration = cfgBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
