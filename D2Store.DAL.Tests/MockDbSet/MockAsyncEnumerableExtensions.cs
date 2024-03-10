using System.Linq.Expressions;

namespace D2Store.DAL.Tests.MockDbSet
{
    public class MockAsyncEnumerableExtensions<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public MockAsyncEnumerableExtensions(IEnumerable<T> enumerable)
            : base(enumerable)
        {
        }

        public MockAsyncEnumerableExtensions(Expression expression)
            : base(expression)
        {
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            => new MockAsyncEnumeratorExtensions<T>(this.AsEnumerable().GetEnumerator());

        public IAsyncEnumerator<T> GetEnumerator()
            => new MockAsyncEnumeratorExtensions<T>(this.AsEnumerable().GetEnumerator());

#pragma warning disable SA1201 // Elements must appear in the correct order
        IQueryProvider IQueryable.Provider
#pragma warning restore SA1201 // Elements must appear in the correct order
            => new MockAsyncDbSetExtensions<T>(this);
    }
}
