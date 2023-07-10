using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW5.Models;
using HW5.ViewModels;

namespace HW5.Service
{
    public interface iService
    {
     
       
        List<BorrowVM> GetBorrow(int id);
   
        List<StudentVM> GetStudent(int id);

        List<BookVM> GetBook();
    

        void BorrowBook(int bookId, int studentId);
        void ReturnBook(int bookId);
    }
}
