using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using System.Text;


namespace Ecore
{
    public class Controller : ControllerBase
    {
        public Controller() { }
        public async Task user(HttpContext context)
        {
            string id = (string)context.GetRouteData().Values["id"];
            await context.Response.WriteAsync(id);
        }

        public async Task check(HttpContext context)
        {
            await context.Response.WriteAsync("ok");
        }

        public async Task config(HttpContext context)
        {
            string key = (string)context.GetRouteData().Values["key"];
            var value = GetConfig(key).ToString();
            // Encoding.UTF8
            
            
            await context.Response.WriteAsync(get_uft8(value));
        }

        public async Task index(HttpContext context)
        {
            await SetTemplete("index.html", context.Response);
        }


    }
}
