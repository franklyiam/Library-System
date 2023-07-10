using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HW5.Models;
using HW5.ViewModels;

namespace HW5.Service
{
    public class Service : iService
    {
        private readonly LibraryEntities db = new LibraryEntities();

        public void BorrowBook(int bookId, int studentId)
        {
            var bb = new borrow
            {

                bookId = bookId,
                studentId = studentId,
                takenDate = DateTime.Now,
                broughtDate = null
            };


            db.borrows.Add(bb);
            db.SaveChanges();
        }


        public void ReturnBook(int bookId)
        {
            var bb = db.borrows.Where(x => x.bookId == bookId && x.broughtDate == null).FirstOrDefault();
            bb.broughtDate = DateTime.Now;
            db.SaveChanges();
        }


        public List<BookVM> GetBook()
        {
            return db.books.Include(t => t.type).Include(a => a.author).Select(x => new BookVM
            {

                bookId = x.bookId,
                authorId = x.authorId,
                name = x.name,
                pagecount = x.pagecount,
                point = x.point,
                typeId = x.typeId,
                typeName = x.type.name,
                authorName = x.author.surname,
                available = db.borrows.Where(y => y.bookId == x.bookId && y.broughtDate == null).Count() == 0,
                types = db.types.Select(l => new TypeVM { typeId = l.typeId, name = l.name }).ToList(),
                authors = db.authors.Select(a => new AuthorVM { authorId = a.authorId, name = a.surname}).ToList()

            }).ToList();
        }

    
        public List<BorrowVM> GetBorrow( int id)
        {
            return db.borrows.Select(x => new BorrowVM
            {

                bookId = x.bookId,
                borrowId = x.borrowId,
                broughtDate = x.broughtDate,
                studentId = x.studentId,
                takenDate = x.takenDate,
                available = db.borrows.Where(y => y.bookId == x.bookId && y.broughtDate == null).Count() == 0,
                bookName = x.book.name,
                studentName = x.student.name,
                studentSurname = x.student.surname,
                borrowNum = db.borrows.Where(b => b.bookId == id).Count(),
              
            }).Where(b => b.bookId == id).OrderByDescending(o => o.takenDate).ToList();
        }

        public List<StudentVM> GetStudent(int id)
        {
            return db.students.Select(x => new StudentVM
            {
                studentId = x.studentId,
                birthdate = x.birthdate,
                bookId = id,
                gender = x.gender,
                name = x.name,
                surname = x.surname,
                point = x.point,
                @class = x.@class,
                bookOut = db.borrows.Where(y => y.bookId == id && y.broughtDate == null).Count() != 0,
                bookedStudent = db.borrows.Where(y => y.bookId == id && y.broughtDate == null).Select(s => s.studentId).FirstOrDefault(),
                classes = db.students.Select(c => new ClassVM { className = c.@class }).ToList()


            }).ToList();
        }


    }
}