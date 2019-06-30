using System.Collections.Generic;

namespace Hospital.BusinessLogic.Pagination
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