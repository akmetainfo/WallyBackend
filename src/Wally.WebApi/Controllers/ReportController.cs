using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reports = Usol.Wally.Application.Reports;

namespace Usol.Wally.WebApi.Controllers
{
    public class ReportController : BaseApiController
    {
        public ReportController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<object> NonCategorizedTransactions(Reports.NonCategorizedTransactions.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> CrookedCategorizedTransactions(Reports.CrookedCategorizedTransactions.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> StatByMonths(Reports.StatByMonths.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> StatByWeeks(Reports.StatByWeeks.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> SpendingByCategories(Reports.SpendingByCategories.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }
    }
}