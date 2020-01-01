using System;
using System.Collections.Generic;
using Usol.Wally.Application.Transactions.List;
using MediatR;

namespace Usol.Wally.Application.Reports.SpendingForCategory
{
    public class Query : IRequest<IEnumerable<TransactionDto>>
    {
        public Query(int categoryId, DateTime fromDate, DateTime toDate)
        {
            this.CategoryId = categoryId;
            this.FromDate = fromDate;
            this.ToDate = toDate;
        }

        public int CategoryId { get; }

        public DateTime FromDate { get; }

        public DateTime ToDate { get; }
    }
}