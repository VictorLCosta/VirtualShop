using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VirtualShop.Libraries.Login;
using VirtualShop.Models;

namespace VirtualShop.Libraries.Filter
{
    /*
     * Tipos de filtros:
     * - Autorização
     * - Recurso
     * - Ação
     * - Exceção
     * - Resultado
     */

    public class ClientAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        LoginClient _loginClient;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginClient = (LoginClient)context.HttpContext.RequestServices.GetService(typeof(LoginClient));

            Client client = _loginClient.GetClient();
            if (client != null)
            {
                context.Result = new ContentResult() { Content = $"Usuário {client.Id}. Email: {client.Email} - Idade: {client.BirthDate} Logado!" };
            }
            else 
            {
                context.Result = new ContentResult() { Content = "Acesso negado!" };
            }

        }
    }
}
