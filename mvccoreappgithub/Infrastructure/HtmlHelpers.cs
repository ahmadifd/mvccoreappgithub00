using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using mvccoreappgithub.Models;
using System;
using System.Collections.Generic;
using System.Linq;



namespace Infrastructure
{
    public static class HtmlHelpers
    {
        public static IHtmlContent Button_Submit(this IHtmlHelper helper, string name , string value)
        {
            string strResult =
                string.Format("<input id=\"{0}\" name=\"{0}\" type=\"submit\" value=\"{1}\" class=\"button\" />", name, value);

            return (helper.Raw(strResult));
        }

    }
}