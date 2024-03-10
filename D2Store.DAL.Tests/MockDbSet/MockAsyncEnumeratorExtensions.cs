using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace D2Store.DAL.Tests.MockDbSet
{
    public class MockAsyncEnumeratorExtensions<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> inner;

        public MockAsyncEnumeratorExtensions(IEnumerator<T> inner)
           => this.inner = inner;

        public T Current
           => this.inner.Current;

        public ValueTask<bool> MoveNextAsync()
             => new ValueTask<bool>(this.inner.MoveNext());

        public ValueTask DisposeAsync()
        {
            this.inner.Dispose();
            return default;
        }
    }
}
