using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.ModelClasses;
using System.Net;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
        BookRentalEntities db = new BookRentalEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["IsAdmin"] != null)
            {
                return RedirectToAction("About", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel userView)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(userView.UserName1) && !string.IsNullOrEmpty(userView.UserPassword1))
                {
                    var user = db.UserTables.FirstOrDefault(User => User.UserName == userView.UserName1 && User.U_Pwd == userView.UserPassword1);
                    var RoleID = (from User in db.UserTables where User.UserName == userView.UserName1 select User.RoleID).SingleOrDefault();
                    if (user != null && RoleID != null)
                    {
                        if (userView.RoleID1 == RoleID)
                        {
                            if (RoleID == 1)
                            {
                                Session["IsAdmin"] = true;
                                Session["UserID"] = user.UserID;
                                Response.Cookies.Add(new HttpCookie("UserName", user.UserName.ToString()));
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                Session["IsAdmin"] = false;
                                Session["UserID"] = user.UserID;
                                Response.Cookies.Add(new HttpCookie("UserName", user.UserName.ToString()));
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            return RedirectToAction("About", "Home");
                        }
                    }
                }
                else return RedirectToAction("About", "Home");
            }
            return View(userView);
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (Session["IsAdmin"] == null)
            {
                UserViewModel userView = new UserViewModel();
                return View();
            }
            else
            {
                return RedirectToAction("About", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel userView)
        {
            if (ModelState.IsValid)
            {
                var UserAccount = new UserTable();
                UserAccount.UserName = userView.UserName1;
                UserAccount.U_Pwd = userView.UserPassword1;

                var UserInfo = new UserInfoTable();
                UserInfo.FirstName = userView.FirstName1;
                UserInfo.LastName = userView.LastName1;
                UserInfo.UserID = UserAccount.UserID;
                UserInfo.U_Email = userView.U_Email1;
                UserInfo.U_PhoneNumber = userView.U_PhoneNumber1;
                UserInfo.U_Address = userView.U_Address1;

                db.UserTables.Add(UserAccount);
                db.UserInfoTables.Add(UserInfo);
                db.SaveChanges();

                return RedirectToAction("About", "Home");

            }
            else
            {
                return RedirectToAction("About", "Home");
            }
        }

        public ActionResult Logout()
        {
            Session["IsAdmin"] = null;
            Session["UserID"] = null;
            return RedirectToAction("Index", "Home");
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

                UserInfoTable User = db.UserInfoTables.Find(id);
                if (User == null)
                {
                    return HttpNotFound();
                }
                return View(User);
            }
            else return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
                UserInfoTable UserInfo = db.UserInfoTables.Find(id);
                UserTable UserAccount = db.UserTables.Find(id);

                db.UserInfoTables.Remove(UserInfo);
                db.UserTables.Remove(UserAccount);

                db.SaveChanges();
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            var UserID = (from User in db.UserInfoTables where User.UserID == id select User.UserID).SingleOrDefault();

            if (Convert.ToInt32(Session["UserID"]) == id || Convert.ToBoolean(Session["IsAdmin"]) == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                UserInfoTable UserInfo = db.UserInfoTables.Find(id);
                if (UserInfo == null)
                {
                    return HttpNotFound();
                }
                return View(UserInfo);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult UserList()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]) == true)
            {
                return View(db.UserInfoTables.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}