using System.Collections.Generic;

namespace MarketPlace.Query.Contract.Category
{
    public class CategoryQueryVM
    {
        public long Id { get; set; }
        public long? ParentId { get;  set; }
        public string Name { get;  set; }
        public string UrlName { get; set; }

        public List<CategoryQueryVM> Categories { get; set; }

        public CategoryQueryVM()
        {
            Categories = new List<CategoryQueryVM>();
        }
    }
}
