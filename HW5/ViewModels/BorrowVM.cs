using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW5.ViewModels
{
    public class BorrowVM
    {
        public int borrowId { get; set; }
        public Nullable<int> studentId { get; set; }
        public Nullable<int> bookId { get; set; }
        public Nullable<System.DateTime> takenDate { get; set; }
        public Nullable<System.DateTime> broughtDate { get; set; }
        public string studentName { get; set; }
        public string studentSurname { get; set; }
        public int borrowNum { get; set; }
        public bool available { get; set; }
        public string bookName { get; set; }


    }
}