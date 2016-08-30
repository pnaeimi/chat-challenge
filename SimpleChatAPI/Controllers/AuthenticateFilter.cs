using SimpleChatAPI.Repository;
using SimpleChatAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SimpleChatAPI.Controllers
{
    public class AuthenticateFilter : ActionFilterAttribute
    {

        private IUserRepository userRepository = null;

        public AuthenticateFilter()
        {
            userRepository = new UserRepository();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            
            var authorization = actionContext.Request.Headers.Authorization;
            var token = authorization == null ? string.Empty : authorization.ToString();

            if( !userRepository.CheckByToken(token))
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));

            base.OnActionExecuting(actionContext);
        }
       
    }
}