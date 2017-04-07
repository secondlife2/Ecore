using System.Collections.Generic;

namespace Ecore
{
    public class RouteMap
    {
        private static Controller _controller = new Controller();
        public static List<RouteModel> GetRoutes()
        {
            List<RouteModel> list = new List<RouteModel>
            {
                new RouteModel{ method = "GET", patch = "index", handler = _controller.index },
                new RouteModel{ method = "GET", patch = "check", handler = _controller.check },
                new RouteModel{ method = "GET", patch = "user/{id}", handler = _controller.user },
            };

            return list;
        }
    }
}