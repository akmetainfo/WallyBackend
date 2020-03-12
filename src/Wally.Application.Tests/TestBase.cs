using System.Threading;
using Usol.Wally.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Usol.Wally.Application
{
    public class TestBase
    {
        protected CancellationToken GetCancellationToken()
        {
            return new CancellationTokenSource().Token;
        }

        protected DbContextOptions<ApplicationDbContext> GetDbOptions()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                   .UseInMemoryDatabase(databaseName: "MemoryDb1")
                   .Options;
        }
    }
}