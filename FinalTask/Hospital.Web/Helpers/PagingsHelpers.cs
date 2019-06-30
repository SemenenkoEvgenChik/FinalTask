using Hospital.BusinessLogic.Pagination;
using System;
using System.Text;
using System.Web.Mvc;

namespace Hospital.Web.Helpers
{
    public static class PagingsHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
           PageInfo pageInfo, Func<int, string> func)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                if (pageInfo.PageNumber != i)
                    tag.MergeAttribute("href", func(i));
                tag.InnerHtml = i.ToString();
                // если текущая страница, то выделяем ее,
                // например, добавляя класс
                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

    }
}