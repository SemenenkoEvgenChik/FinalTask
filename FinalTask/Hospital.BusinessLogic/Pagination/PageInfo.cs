using System;

namespace Hospital.BusinessLogic.Pagination
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)(TotalItems / PageSize) + (TotalItems % PageSize == 0 ? 0 : 1)  ; }
        }
    }
}