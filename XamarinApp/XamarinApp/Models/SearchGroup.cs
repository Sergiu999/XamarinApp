using System.Collections.Generic;

namespace XamarinApp.Models
{
    public class SearchGroup : List<Search>
    {
        public string Title { get; set; }

        public SearchGroup(string title, IEnumerable<Search> searches = null)
            : base(searches)
        {
            Title = title;
        }
    }
}
