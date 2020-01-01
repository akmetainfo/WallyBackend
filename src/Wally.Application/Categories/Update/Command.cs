using MediatR;

namespace Usol.Wally.Application.Categories.Update
{
    public class Command : IRequest<CategoryData>
    {
        public Command(CategoryData category)
        {
            this.Category = category;
        }

        public CategoryData Category { get; }
    }
}