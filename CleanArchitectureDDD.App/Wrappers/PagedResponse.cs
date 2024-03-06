namespace CleanArchitectureDDD.App.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public PagedResponse(T data, int pageNumber, int pageSize, int totalPages)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Succeeded = true;
            TotalPages = totalPages;
        }
    }
}
