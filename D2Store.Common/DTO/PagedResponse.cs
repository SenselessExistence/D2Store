namespace D2Store.Common.DTO
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int TotalCount { get; set; }
    }
}
