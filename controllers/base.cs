using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace Ecore
{
    public class ControllerBase
    {
        protected Task SetTemplete(string patch, HttpResponse w)
        {
            string html = File.ReadAllText(@"./wwwroot/views/" + patch, Encoding.UTF8);
            return w.WriteAsync(html);
        }
    }
}
