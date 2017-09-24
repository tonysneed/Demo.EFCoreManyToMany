using EfCoreManyToMany.Data.Contexts;
using Xunit;

namespace EfCoreManyToMany.Tests.Helpers
{
    [CollectionDefinition("BookstoreContext")]
    public class BookstoreContextCollection : ICollectionFixture<BookstoreContextFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}