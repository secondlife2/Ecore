using System.Text;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using React.AspNet;
using Swashbuckle.AspNetCore.Swagger;

namespace Ecore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // 读取配置文件
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("./conf/appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"./conf/appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            ControllerBase.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            // });


            // services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            // Encoding支持gb2312
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
            /// add swagger
            // app.UseSwagger();
            // app.UseSwaggerUI(c =>
            // {
            //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            // });


            RouteMap.GetRoutes().ForEach(delegate (RouteModel m)
            {
                app.UseRouter(builder => builder.MapVerb(m.method, m.patch, m.handler));
            });
        }
    }
}
