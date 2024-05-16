namespace D2Store.DAL.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T>Paginate<T>(this IQueryable<T> sourse, int page, int pageSize)
        {
            return sourse.Skip((page)*pageSize).Take(pageSize);
        }
    }
}
