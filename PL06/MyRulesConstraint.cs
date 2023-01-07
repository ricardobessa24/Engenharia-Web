using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace PL06
{
    public class MyRulesConstraint:IRouteConstraint
    {
        public bool Match(HttpContext httpcontext,  IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(routeKey != "letter")
            {
                return false; //reject any other key than letter
            }
            return values[routeKey] is null || Regex.IsMatch((values[routeKey] as string), @"[A-ZÂÁÉóÓ]");
        }

    }
}
