using Newtonsoft.Json;
using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.Categories.Create
{
    public class CategoryData
    {
        [JsonConstructor]
        public CategoryData(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public static CategoryData FromEntity(Category entity)
        {
            return new CategoryData(entity.Id, entity.Title);
        }

        public Category ToEntity()
        {
            return new Category
            {
                Id = this.Id,
                Title = this.Title,
            };
        }
    }
}