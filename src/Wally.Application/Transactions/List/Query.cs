using System;
using MediatR;
using MetaInfoRu.Common;

namespace Usol.Wally.Application.Transactions.List
{
    public class Query : PagedQuery, IRequest<Result>
    {
        public Query(int? accountId, bool hideChecked, bool hideInternalTransfers, decimal? amountFrom, decimal? amountTo, int? categoryId, DateTime? fromDate, DateTime? toDate, bool? paged, int? pagedOffset, int? pagedLimit)
            : base(paged, pagedOffset, pagedLimit)
        {
            this.AccountId = accountId;
            this.HideChecked = hideChecked;
            this.HideInternalTransfers = hideInternalTransfers;
            this.AmountFrom = amountFrom;
            this.AmountTo = amountTo;
            this.CategoryId = categoryId;
            this.FromDate = fromDate;
            this.ToDate = toDate;
        }

        public static Query WithoutPaging(int? accountId, bool hideChecked, bool hideInternalTransfers, decimal? amountFrom, decimal? amountTo, int? categoryId, DateTime? fromDate, DateTime? toDate)
        {
            return new Query(accountId, hideChecked, hideInternalTransfers, amountFrom, amountTo, categoryId, fromDate, toDate, false, null, null);
        }

        public int? AccountId { get; }

        public bool HideChecked { get; }

        public bool HideInternalTransfers { get; }

        public decimal? AmountFrom { get; }

        public decimal? AmountTo { get; }

        public int? CategoryId { get; }

        public DateTime? FromDate { get; }

        public DateTime? ToDate { get; }
    }
}
