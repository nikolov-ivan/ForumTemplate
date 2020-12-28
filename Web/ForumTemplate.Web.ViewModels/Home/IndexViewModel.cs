namespace ForumTemplate.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class IndexViewModel
    {
        public string SearchString { get; set; }

        public IEnumerable<IndexCategoryViewModel> Categories { get; set; }
    }
}
