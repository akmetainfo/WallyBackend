using System;
using System.Collections.Generic;
using MediatR;

namespace Usol.Wally.Application.Reports.StatByWeeks
{
    public class Query : IRequest<List<(DateTime, DateTime)>>
    {
    }
}
