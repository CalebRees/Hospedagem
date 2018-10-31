using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospedagem.Repositories.Authentication
{
    public class GestaoCookie
    {
        public static void CriarCookie(int IDUsuario)
        {
            HttpCookie cookieUsuario = new HttpCookie("CookieUsuario");
            cookieUsuario.Values["IDUsuario"] = IDUsuario.ToString();
            cookieUsuario.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cookieUsuario);
        }
    }
}