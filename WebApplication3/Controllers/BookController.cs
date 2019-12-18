using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.ViewModels;
using System.Net;

namespace WebApplication3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        BookRentalEntities db = new BookRentalEntities();

        public ActionResult Index()
        {
            return View(db.BookTables.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]) == true)
            {
                BookViewModel userView = new BookViewModel();
                return View();
            }
            else
            {
                return RedirectToAction("About", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                BookTable book = new BookTable();
                book.ISBN = viewModel.ISBN1;

                BookDetailTable bookDetail = new BookDetailTable();
                bookDetail.ISBN = viewModel.ISBN1;
                bookDetail.Title = viewModel.Title1;
                bookDetail.Summary = viewModel.Summary1;
                if (viewModel.AuthorID1 == Convert.ToInt32(db.AuthorTables.Find(viewModel.AuthorID1).AuthorID))
                {
                    bookDetail.AuthorID = viewModel.AuthorID1;
                }

                if (viewModel.PublisherID1 == Convert.ToInt32(db.PublisherTables.Find(viewModel.PublisherID1).PublisherID))
                {
                    bookDetail.PublisherID = viewModel.PublisherID1;
                }

                db.BookTables.Add(book);
                db.BookDetailTables.Add(bookDetail);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("About", "Home");

            }
        }

        [HttpGet]
        public ActionResult Remove(int? id)
        {
            if (Convert.ToBoolean(Session["IsAdmin"]) == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                BookTable book = db.BookTables.Find(id);
                if (book == null)
                {
                    return HttpNotFound();
                }
                return View(book);
            }
            else return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            BookTable book = db.BookTables.Find(id);
            BookDetailTable bookDetail = db.BookDetailTables.Find(id);

            db.BookTables.Remove(book);
            db.BookDetailTables.Remove(bookDetail);

            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (Convert.ToBoolean(Session["IsAdmin"]) == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                BookTable book = db.BookTables.Find(id);

                if (book == null)
                {
                    return HttpNotFound();
                }
                return View(book);
            }
            else return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                BookTable book = db.BookTables.Find(id);

                if (TryUpdateModel(book, "", new string[] { "ISBN" }))
                {
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditDetail(int? id)
        {
            if (Convert.ToBoolean(Session["IsAdmin"]) == true)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                BookDetailTable bookDetail = db.BookDetailTables.Find(id);

                if (bookDetail == null)
                {
                    return HttpNotFound();
                }
                return View(bookDetail);
            }
            else return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetail(int id)
        {
            if (ModelState.IsValid)
            {
                BookDetailTable bookDetail = db.BookDetailTables.Find(id);

                if (TryUpdateModel(bookDetail, "", new string[] { "ISBN", "Title", "Summary", "AuthorID", "PublisherID" }))
                {
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (Session["UserID"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                BookDetailTable bookDetail = db.BookDetailTables.Find(id);
                if (bookDetail == null)
                {
                    return HttpNotFound();
                }
                return View(bookDetail);
            }
            else return RedirectToAction("Index", "Home");
        }
    }
}