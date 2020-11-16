using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class RouteControllerAttribute : RouteAttribute
    {
        public RouteControllerAttribute() : base("api/[controller]/[action]")
        {
        }
    }
}
