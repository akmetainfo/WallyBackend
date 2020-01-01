using System.Collections.Generic;

namespace Usol.Wally.Application.Categories.List
{
    public class Result
    {
        public Result(IEnumerable<CategoryDto> categories, int totalElements)
        {
            this.Categories    = categories;
            this.TotalElements = totalElements;
        }

        public IEnumerable<CategoryDto> Categories { get; }

        public int TotalElements { get; }
    }
}
