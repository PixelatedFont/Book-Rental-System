using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinalProject.Models;
using WebFinalProject.ViewModels;
using System.Net;

namespace WebFinalProject.Controllers
{
    public class PublisherController : Controller
    {
        // GET: Publisher
        BookRentalEntities db = new BookRentalEntities();

        public ActionResult Index()
        {
            return View(db.PublisherTables.ToList());
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
        public ActionResult Create(PublisherViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                PublisherTable publisher = new PublisherTable();
                publisher.PublisherName = viewModel.PublisherName1;
                publisher.P_Address = viewModel.PublichserAddress1;
                publisher.P_Email = viewModel.PublisherEmail1;
                publisher.P_PhoneNumber = viewModel.PublisherPhoneNumber1;

                db.PublisherTables.Add(publisher);
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

                PublisherTable publisher = db.PublisherTables.Find(id);
                if (publisher == null)
                {
                    return HttpNotFound();
                }
                return View(publisher);
            }
            else return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            PublisherTable publisher = db.PublisherTables.Find(id);

            db.PublisherTables.Remove(publisher);
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

                PublisherTable publisher = db.PublisherTables.Find(id);
                if (publisher == null)
                {
                    return HttpNotFound();
                }
                return View(publisher);
            }
            else return RedirectToAction("Index", "Home");

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                PublisherTable publisher = db.PublisherTables.Find(id);

                if (TryUpdateModel(publisher, "", new string[] { "PublisherName", "P_Email", "P_PhoneNumber", "P_Address"}))
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

                PublisherTable publisher = db.PublisherTables.Find(id);
                if (publisher == null)
                {
                    return HttpNotFound();
                }
                return View(publisher);
            }
            else return RedirectToAction("Index", "Home");
        }

        
    }   
}