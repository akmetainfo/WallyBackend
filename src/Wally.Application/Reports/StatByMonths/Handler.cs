using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.Reports.StatByMonths
{
    public class Handler : BaseHandler, IRequestHandler<Query, Dictionary<int, IEnumerable<int>>>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public Task<Dictionary<int, IEnumerable<int>>> Handle(Query request, CancellationToken cancellationToken)
        {
            const int firstYearWithStatistic = 2019;

            var data = Enumerable.Range(firstYearWithStatistic, DateTime.Today.Year - firstYearWithStatistic + 1)
                                 .Reverse()
                                 .ToDictionary(x => x, x => Enumerable.Range(1, 12));

            return Task.FromResult(data);
        }
    }
}
