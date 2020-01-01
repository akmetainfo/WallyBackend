using MediatR;

namespace Usol.Wally.Application.Categories.Details
{
    public class Query : IRequest<DetailsDto>
    {
        public Query(int categoryId)
        {
            this.CategoryId = categoryId;
        }

        public int CategoryId { get; }
    }
}