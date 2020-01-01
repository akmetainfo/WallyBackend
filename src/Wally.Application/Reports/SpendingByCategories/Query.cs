using System;
using System.Collections.Generic;
using MediatR;

namespace Usol.Wally.Application.Reports.SpendingByCategories
{
    public class Query : IRequest<IEnumerable<SpendingByCategoryDto>>
    {
        public Query(DateTime fromDate, DateTime toDate)
        {
            this.FromDate = fromDate;
            this.ToDate = toDate;
        }

        public static Query FirstMonthOfApp()
        {
            var fromDate = new DateTime(2019, 1, 1);
            var toDate = new DateTime(2019, 2, 1);

            return new Query(fromDate, toDate);
        }

        public bool NeedsCorrection()
        {
            return this.FromDate == default(DateTime) || this.ToDate == default(DateTime) || this.FromDate > this.ToDate;
        }

        public DateTime FromDate { get; }

        public DateTime ToDate { get; }
    }
}