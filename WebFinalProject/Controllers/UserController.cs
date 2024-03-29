﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinalProject.Models;
using WebFinalProject.ViewModels;
using System.Net;

namespace WebFinalProject.Controllers
{
    public class UserController : Controller
    {
        BookRentalEntities db = new BookRentalEntities();
        // GET: User
        public ActionResult UserControlPanel()
        {
            if (Session["UserID"] != null && Convert.ToBoolean(Session["IsAdmin"]) == false)
            {
                return View("UserControlPanel");

            }
            else return RedirectToAction("Index", "Home");
        }

        public ActionResult AdminControlPanel()
        {
            if (Session["UserID"] != null && Convert.ToBoolean(Session["IsAdmin"]) == true)
            {
                return View("AdminControlPanel");

            }
            else return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["IsAdmin"] != null)
            {
                return RedirectToAction("Index", "Home");
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
                    ModelState.IsValidField("UserName1");
                    ModelState.IsValidField("Password1");

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
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else return RedirectToAction("Index", "Home");
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
                return RedirectToAction("Index", "Home");
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
                UserAccount.RoleID = 2;

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

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View(userView);
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

        [HttpGet]
        public ActionResult Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                UserInfoTable UserInfo = db.UserInfoTables.Find(id);
                if (TryUpdateModel(UserInfo,"", new string[] {"FirstName","LastName", "U_Email", "U_PhoneNumber", "U_Address"}))
                {
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ChangePassword(int? id)
        {
            var UserID = (from User in db.UserTables where User.UserID == id select User.UserID).SingleOrDefault();

            if (Convert.ToInt32(Session["UserID"]) == id || Convert.ToBoolean(Session["IsAdmin"]) == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                UserTable UserInfo = db.UserTables.Find(id);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(int id)
        {
            if (ModelState.IsValid)
            {
                UserTable UserInfo = db.UserTables.Find(id);
                if (TryUpdateModel(UserInfo, "", new string[] { "U_Pwd" }))
                {
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
    //Implement Password Change
}