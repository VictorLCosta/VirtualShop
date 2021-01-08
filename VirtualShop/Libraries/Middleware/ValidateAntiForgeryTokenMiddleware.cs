using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace VirtualShop.Libraries.Middleware
{
    public class ValidateAntiForgeryTokenMiddleware
    {
        private RequestDelegate _next;
        private IAntiforgery _anti;

        public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery anti)
        {
            _next = next;
            _anti = anti;
        }

        public async Task Invoke(HttpContext context)
        {
            if(HttpMethods.IsPost(context.Request.Method))
            {
                await _anti.ValidateRequestAsync(context);
            }

            await _next(context);
        }
    }
}