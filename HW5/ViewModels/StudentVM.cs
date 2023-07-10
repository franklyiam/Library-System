using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW5.ViewModels
{
    public class StudentVM
    {
        public int studentId { get; set; }
        public int bookId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public Nullable<System.DateTime> birthdate { get; set; }
        public string gender { get; set; }
        public string @class { get; set; }
        public Nullable<int> point { get; set; }
        public bool bookOut { get; set; }
        public int? bookedStudent { get; set; }
        public List<ClassVM> classes { get; set; }
    }
}