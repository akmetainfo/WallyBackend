using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.Categories.List
{
    public class CategoryDto
    {
        public CategoryDto(Category category)
        {
            this.Id = category.Id;
            this.Title = category.Title;
        }

        public int Id { get; }

        public string Title { get; }
    }
}