using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace Ecore
{
    public class ControllerBase
    {
        public static IConfigurationRoot Configuration;
        protected Task SetTemplete(string patch, HttpResponse w)
        {
            string html = File.ReadAllText(@"./wwwroot/views/" + patch, Encoding.UTF8);
            return w.WriteAsync(html);
        }

        protected object GetConfig(string key)
        {
            Configuration.Reload();
            return Configuration[key];
        }

        protected string get_uft8(string unicodeString)
        {
           // return WebUtility.UrlDecode(unicodeString);
           return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(unicodeString));
        }
    }
}
