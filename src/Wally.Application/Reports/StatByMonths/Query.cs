using System.Collections.Generic;
using MediatR;

namespace Usol.Wally.Application.Reports.StatByMonths
{
    public class Query : IRequest<Dictionary<int, IEnumerable<int>>>
    {
    }
}
