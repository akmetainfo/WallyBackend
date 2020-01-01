namespace MetaInfoRu.Common
{
    public class PagedQuery
    {
        protected PagedQuery(bool? paged, int? pagedOffset, int? pagedLimit)
        {
            this.Paged = paged;
            this.PagedOffset = pagedOffset;
            this.PagedLimit = pagedLimit;
        }

        #region

        public bool? Paged { get; }

        public int? PagedOffset { get; }

        public int? PagedLimit { get; }

        #endregion

        public bool IsPaged => this.Paged ?? DefaultPaged;

        public int PageOffset => this.PagedOffset ?? DefaultPagedOffset;

        public int PageLimit => this.PagedLimit ?? DefaultPagedLimit;

        private const bool DefaultPaged = true;

        private const int DefaultPagedOffset = 0;

        private const int DefaultPagedLimit = 10;
    }
}