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
    public class AuthorController : Controller
    {
        // GET: Author
        // GET: Publisher
        BookRentalEntities db = new BookRentalEntities();

        public ActionResult Index()
        {
            return View(db.AuthorTables.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]) == true)
            {
                AuthorViewModel userView = new AuthorViewModel();
                return View();
            }
            else
            {
                return RedirectToAction("About", "Home");
            }
        }

        [HttpPost]
        public ActionResult Create(AuthorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AuthorTable author = new AuthorTable();
                author.AuthorName = viewModel.AuthorName1;


                db.AuthorTables.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("About", "Home");
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

                AuthorTable author = db.AuthorTables.Find(id);
                if (author == null)
                {
                    return HttpNotFound();
                }
                return View(author);
            }
            else return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            AuthorTable author = db.AuthorTables.Find(id);

            db.AuthorTables.Remove(author);
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

                AuthorTable author = db.AuthorTables.Find(id);
                if (author == null)
                {
                    return HttpNotFound();
                }
                return View(author);
            }
            else return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                AuthorTable author = db.AuthorTables.Find(id);

                if (TryUpdateModel(author, "", new string[] { "AuthorName"}))
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

                AuthorTable author = db.AuthorTables.Find(id);
                if (author == null)
                {
                    return HttpNotFound();
                }
                return View(author);
            }
            else return RedirectToAction("Index", "Home");
        }


    }
}