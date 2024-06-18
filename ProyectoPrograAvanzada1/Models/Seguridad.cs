using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProyectoPrograAvanzada1.Controllers;

namespace ProyectoPrograAvanzada1.Models
{
    public class Seguridad : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Session.GetString("Login") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller","Home" },
                    {"action","IniciarSesion" }
                 });
            }

            base.OnActionExecuted(context);
        }

    }
}
