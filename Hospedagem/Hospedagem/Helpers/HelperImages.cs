using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospedagem.Helpers
{
    public static class HelperImages
    {
        public static MvcHtmlString ExibeImagens(this HtmlHelper hp) {
            string str = "<div style=\"width:100%; text-align:center;padding:10px\">" +
                       "<div style=\"width:300px;height:168px;margin:5px;display:inline-block\">" +
                       "<img src=\"Images/1.jpg\" /></div>" +
                       "<div style=\"width:300px;height:168px;margin:5px;display:inline-block\">" +
                       "<img src=\"Images/2.jpg\" /></div>" +
                       "<div style=\"width:300px;height:168px;margin:5px;display:inline-block\">" +
                       "<img src=\"Images/3.jpg\" /></div>" +
                       "</div>";
            return new MvcHtmlString(str);
        }
    }
}