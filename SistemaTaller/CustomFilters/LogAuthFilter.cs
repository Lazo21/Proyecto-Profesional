using System.Web.Mvc;

namespace SistemaTaller.CustomFilters
{
    public class AuthLogAttribute : AuthorizeAttribute
    {
        public AuthLogAttribute()
        {
            View = "AuthorizeFailed";
        }

        public string View { get; set; }
        
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }

      
        private void IsUserAuthorized(AuthorizationContext filterContext)
        {
            //  Si el resultado devuelve nulo, el usuario está autorizado
            if (filterContext.Result == null)
                return;

            // Si el usuario no está autorizado, navegue a la vista de autorización fallida
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
               
                var vr = new ViewResult();
                vr.ViewName = View;

                ViewDataDictionary dict = new ViewDataDictionary();
                dict.Add("Message", "Lo sentimos, no está autorizado para realizar esta acción");

                vr.ViewData = dict;

                var result = vr;
                
                filterContext.Result = result;
            }
        }
    }
}
