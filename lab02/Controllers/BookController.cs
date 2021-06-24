using lab02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab02.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        /*public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual-Author name book 1");
            books.Add("HTML5 & CSS Responsive web Design cookbook-Author name book 2");
            books.Add("Professional ASP.NET MVC5-Author name book 3");
            ViewBag.Books = books;
            return View();
        }*/
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1,"HTML5 & CSS3 The complete Manual","Author name book 1","/content/Images/book1cover.png"));
            books.Add(new Book(2,"HTML5 & CSS Responsive web Design cookbook","Author name book 2", "/content/Images/book2cover.png"));
            books.Add(new Book(3,"Professional ASP.NET MVC5","Author name book 3", "/content/Images/book3cover.png"));
            //ViewBag.Books = books;
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author name book 1", "/content/Images/book1cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author name book 2", "/content/Images/book2cover.png"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author name book 3", "/content/Images/book3cover.png"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if (b.Id==id)
                {
                    book = b;
                    break;
                }               
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost,ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id,string title, string author, string image_cover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author name book 1", "/content/Images/book1cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author name book 2", "/content/Images/book2cover.png"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author name book 3", "/content/Images/book3cover.png"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = title;
                    b.Author = author;
                    b.Image_cover = image_cover;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View("ListBookModel",books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("createBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include="Id, Title, Author, ImageCover")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author name book 1", "/content/Images/book1cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author name book 2", "/content/Images/book2cover.png"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author name book 3", "/content/Images/book3cover.png"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (Exception)//RetryLimitExceededException
            {
                ModelState.AddModelError("", "Eror save data");
            }
            return View("ListBookModel", books);
        }
        public ActionResult DeleteBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author name book 1", "/content/Images/book1cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author name book 2", "/content/Images/book2cover.png"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author name book 3", "/content/Images/book3cover.png"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author name book 1", "/content/Images/book1cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author name book 2", "/content/Images/book2cover.png"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author name book 3", "/content/Images/book3cover.png"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    books.Remove(b);
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View("ListBookModel", books);
        }
    }

    }
