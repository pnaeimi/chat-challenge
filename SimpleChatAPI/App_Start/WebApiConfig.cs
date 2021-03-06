﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SimpleChatAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           /* config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/

            config.Routes.MapHttpRoute(
                name: "login",
                routeTemplate: "api/users/{action}",
                defaults: new { controller = "Users"}
            );

           /* config.Routes.MapHttpRoute(
                name: "register",
                routeTemplate: "api/users/{register}",
                defaults: new { controller = "Users"}
            );*/

            config.Routes.MapHttpRoute(
                name: "UserApi",
                routeTemplate: "api/users/{id}",
                defaults: new { controller = "Users", id = RouteParameter.Optional }
            );
          
            config.Routes.MapHttpRoute(
                name: "ChatApi",
                routeTemplate: "api/users/{userId}/chats",
                defaults: new {controller = "Chats", userId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "MessageApi",
                routeTemplate: "api/users/{userId}/chats/{chatId}/messages",
                defaults: new { controller = "Messages" }
            );

            /*config.Routes.MapHttpRoute(
                name: "login",
                routeTemplate: "api/users/login",
                defaults: new { controller = "users",  action = "Login"}
            );

            config.Routes.MapHttpRoute(
                name: "register",
                routeTemplate: "api/users/register",
                defaults: new { controller = "users", action = "Register" }
            );*/


            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
