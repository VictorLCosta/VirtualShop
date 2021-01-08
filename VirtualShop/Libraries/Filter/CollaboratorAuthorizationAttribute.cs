using System;
using VirtualShop.Libraries.Constants;
using VirtualShop.Libraries.Login;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace VirtualShop.Libraries.Filter
{
    public class CollaboratorAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private char _collaboratorType;

        public CollaboratorAuthorizationAttribute(char collaboratorType = CollaboratorTypeConst.Common)
        {
            _collaboratorType = collaboratorType;
        }

        CollaboratorLogin collaboratorLogin;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            collaboratorLogin = (CollaboratorLogin)context.HttpContext.RequestServices.GetService(typeof(CollaboratorLogin));
            Models.Collaborator collaborator = collaboratorLogin.GetCollaborator();

            if(collaborator == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
            else
            {
                if(collaborator.Type == 'C' && _collaboratorType == CollaboratorTypeConst.Manager)
                {
                    context.Result = new ForbidResult(); 
                }
            }
        }
    }
}
