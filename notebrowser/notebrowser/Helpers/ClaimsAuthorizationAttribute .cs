using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace notebrowser.Helpers
{
    public class ClaimsAuthorizationAttribute : AuthorizeAttribute
    {
        private string claimType;
        private string claimValue;

        public ClaimsAuthorizationAttribute(string type, string value)
        {
            this.claimType = type;
            this.claimValue = value;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.User as ClaimsPrincipal;
            if (user != null &&  user.Identity.IsAuthenticated && user.HasClaim(claimType, claimValue))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                //base.HandleUnauthorizedRequest(filterContext);
                filterContext.Result = new RedirectResult("~/Home/NotAuthorized");
            }
        }

        //public override void OnAuthorization(AuthorizationContext actionContext, System.Threading.CancellationToken cancellationToken)
        //{
        //    var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

        //    if (!principal.Identity.IsAuthenticated)
        //    {
        //        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        return Task.FromResult<object>(null);
        //    }

        //    if (!(principal.HasClaim(x => x.Type == ClaimType && x.Value == ClaimValue)))
        //    {
        //        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        return Task.FromResult<object>(null);
        //    }

        //    //User is Authorized, complete execution
        //    return Task.FromResult<object>(null);

        //}
    }
}