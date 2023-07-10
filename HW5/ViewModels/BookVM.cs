using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW5.ViewModels
{
    public class BookVM
    {
        public int bookId { get; set; }
        public string name { get; set; }
        public Nullable<int> pagecount { get; set; }
        public Nullable<int> point { get; set; }
        public Nullable<int> authorId { get; set; }
        public Nullable<int> typeId { get; set; }
        public string authorName { get; set; }
        public string typeName { get; set; }
        public bool available { get; set; }

        public List<TypeVM> types { get; set; }
        public List<AuthorVM> authors { get; set; }

    }
}