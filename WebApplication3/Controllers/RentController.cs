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
    public class RentController : Controller
    {
        // GET: Rent
        BookRentalEntities db = new BookRentalEntities();
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]) == true)
            {
                return View(db.RentDetailTables.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult UserRentList(int? id)
        {
            if (Session["UserID"] != null)
            {
                var UserRentDetail = (from User in db.RentDetailTables where User.UserID == id select User).ToList();
                return View(UserRentDetail);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Rent(int? id)
        {
            if (Session["UserID"] != null)
            {
             
                BookTable book = db.BookTables.Find(id);
                if (book.BookStatus == false)
                {
                    RentViewModel viewModel = new RentViewModel();
                    viewModel.UserID1 = Convert.ToInt32(Session["UserID"]);
                    BookDetailTable bookDetail = db.BookDetailTables.Find(id);
                    viewModel.BookDetailTable = bookDetail;
                    viewModel.BookTable = book;
                    viewModel.RentDate1 = DateTime.Now;
                    viewModel.DueDate1 = DateTime.Now.AddDays(7);
                    viewModel.BookID1 = book.BookID;
                    viewModel.Deposit1 = 100000 + 3000 * 7;
                    viewModel.Cost1 = 3000;


                    return View(viewModel);
                }
                else { return RedirectToAction("Index", "Home"); }
            }

            else { return RedirectToAction("Index", "Home"); }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rent(int id, RentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                BookDetailTable book = db.BookDetailTables.Find(id);
                BookTable book1 = db.BookTables.Find(id);
                RentDetailTable rentDetail = new RentDetailTable();
                rentDetail.BookID = book1.BookID;
                rentDetail.UserID = Convert.ToInt32(Session["UserID"]);
                rentDetail.ISBN = book1.ISBN;
                rentDetail.RentDate = DateTime.Now;
                rentDetail.DueDate = DateTime.Now.AddDays(7);
                rentDetail.Deposit = 100000;
                rentDetail.Cost = 3000;
                rentDetail.Paid = 7 * rentDetail.Cost;
                rentDetail.Note = viewModel.Note1;

                RentTable rent = new RentTable();
                rent.BookID = rentDetail.BookID;
                rent.ISBN = rentDetail.ISBN;
                rent.UserID = Convert.ToInt32(Session["UserID"]);
                rent.RentDate = rentDetail.RentDate;
                rent.DueDate = rentDetail.DueDate;

                book1.BookStatus = true;

                db.RentDetailTables.Add(rentDetail);
                db.RentTables.Add(rent);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");                              
            }
            else return RedirectToAction("About", "Home");
        }

        [HttpGet]
        public ActionResult RentDetail(int? id)
        {
            if (Session["UserID"] != null)
            {
                RentDetailTable rentDetail = db.RentDetailTables.Find(id);
                return View(rentDetail);
            }

            else { return RedirectToAction("Index", "Home"); }
        }

        [HttpGet]
        public ActionResult EditRent(int? id)
        {
            if (Convert.ToBoolean(Session["IsAdmin"]) == true)
            {
                RentViewModel viewModel = new RentViewModel();
                viewModel.UserID1 = Convert.ToInt32(Session["UserID"]);
                BookDetailTable bookDetail = db.BookDetailTables.Find(id);
                BookTable book = db.BookTables.Find(id);
                RentDetailTable rentDetail = db.RentDetailTables.Find(id);
                RentTable rent = db.RentTables.Find(id);

                viewModel.RentTable = rent;
                viewModel.RentDetailTable = rentDetail;
                viewModel.BookDetailTable = bookDetail;
                viewModel.BookTable = book;
                return View(viewModel);
            }
            else return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRent(int id, RentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                RentDetailTable rentDetail = db.RentDetailTables.Find(id);
                RentTable rent = db.RentTables.Find(id);

                rentDetail.BookID = viewModel.BookID1;
                rentDetail.UserID = viewModel.UserID1;
                rentDetail.ISBN = viewModel.ISBN1;
                rentDetail.RentDate = viewModel.RentDate1;
                rentDetail.DueDate = viewModel.DueDate1;
                rentDetail.ReturnDate = viewModel.ReturnDate1;
                rentDetail.Deposit = viewModel.Deposit1;
                rentDetail.Cost = viewModel.Cost1;
                rentDetail.Paid = viewModel.Paid1;
                rentDetail.Note = viewModel.Note1;

                rent.BookID = viewModel.BookID1;
                rent.ISBN = viewModel.ISBN1;
                rent.UserID = viewModel.UserID1;
                rent.RentDate = viewModel.RentDate1;
                rent.DueDate = viewModel.DueDate1;

                db.Entry(rentDetail).State = System.Data.Entity.EntityState.Modified;
                db.Entry(rent).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            else return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult RentRemove(int? id)
        {
            if (Convert.ToBoolean(Session["IsAdmin"]) == true)
            {
                RentDetailTable rentDetail = db.RentDetailTables.Find(id);
                return View(rentDetail);
            }
            else return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult RentRemove(int id)
        {
            if (ModelState.IsValid)
            {
                var rentDetail = db.RentDetailTables.Find(id);
                var rent = db.RentTables.Find(id);

                db.RentDetailTables.Remove(rentDetail);
                db.RentTables.Remove(rent);

                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("Index", "Home");
        }
    }
}