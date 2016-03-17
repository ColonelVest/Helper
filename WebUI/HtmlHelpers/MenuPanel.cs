using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebUI.HtmlHelpers
{
    public static class MenuPanel
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, string currentPage)
        {
            Dictionary<string, string> Pages = new Dictionary<string, string>()
            {
                { "Schedule", "Расписание" },
                {"ToDoList", "To-do List" },
                { "Notes", "Заметки" }
            };

            StringBuilder result = new StringBuilder();
            TagBuilder ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("nav nav-tabs");
            foreach (var page in Pages)
            {
                TagBuilder liTag = new TagBuilder("li");
                if (page.Key == currentPage)
                {
                    liTag.AddCssClass("active");
                };
                TagBuilder aTag = new TagBuilder("a");
                aTag.MergeAttribute("href", page.Key);
                aTag.InnerHtml = page.Value;
                liTag.InnerHtml = aTag.ToString();
                ulTag.InnerHtml += liTag.ToString();
            };
            result.Append(ulTag.ToString());
            return MvcHtmlString.Create(result.ToString());
        }
    }
}