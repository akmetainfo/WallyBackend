using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.Categories.Details
{
    public class DetailsDto
    {
        public DetailsDto(Category category)
        {
            this.Id = category.Id;
            this.Title = category.Title;
        }

        public int Id { get; }

        public string Title { get; }
    }
}