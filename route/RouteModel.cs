using Microsoft.AspNetCore.Http;

namespace Ecore
{
    public class RouteModel
    {
        public string method { get; set; }
        public string patch { get; set; }
        public RequestDelegate handler { get; set; }
    }
}