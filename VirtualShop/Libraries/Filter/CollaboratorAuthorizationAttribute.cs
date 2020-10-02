using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualShop.Libraries.Login;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace VirtualShop.Libraries.Filter
{
    public class CollaboratorAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        CollaboratorLogin collaboratorLogin;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            collaboratorLogin = (CollaboratorLogin)context.HttpContext.RequestServices.GetService(typeof(CollaboratorLogin));
            Models.Collaborator collaborator = collaboratorLogin.GetCollaborator();

            if(collaborator == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
        }
    }
}
