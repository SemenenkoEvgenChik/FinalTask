using Models.ViewModels;
using System.Collections.Generic;

namespace Models.Pagination
{
    public class PaginationViewModel<TModel> where TModel : class
    {
        public PaginationViewModel()
        {
            PageInfo = new PageInfo();
        }
        public IEnumerable<TModel> Data { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}