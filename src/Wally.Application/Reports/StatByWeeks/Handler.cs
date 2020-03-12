using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.Reports.StatByWeeks
{
    public class Handler : BaseHandler, IRequestHandler<Query, List<(DateTime, DateTime)>>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public Task<List<(DateTime, DateTime)>> Handle(Query request, CancellationToken cancellationToken)
        {
            var list = new List<(DateTime, DateTime)>();
            var firstMonday = DateTime.Today.AddDays(1 - (int)DateTime.Today.DayOfWeek);
            for (var i = 1; i <= 15; i++)
            {
                var from = firstMonday;
                var to = firstMonday.AddDays(7);
                list.Add((from, to));
                firstMonday = firstMonday.AddDays(-7);
            }

            return Task.FromResult(list);
        }
    }
}
