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


    }
}