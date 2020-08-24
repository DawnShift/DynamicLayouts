using DataStore.DataStore;
using SampleProjects.HelperMethods.Sidebar;
using SampleProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SampleProjects.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        public ActionResult Login(string returnUrl)
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie"); 
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            SideBarDataStore.Dispose();
            if (ModelState.IsValid)
            {
                var user = UserDataStore.User.Where(x => x.Email == model.Email && x.Password == model.Password).SingleOrDefault();
                if (user != null)
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.FirstName), new Claim(ClaimTypes.Email, user.Email), new Claim(ClaimTypes.Sid, user.Id.ToString()) }, "ApplicationCookie");
                    Request.GetOwinContext().Authentication.SignIn(identity);
                    return Redirect(GetRedirectUrl(model.ReturnUrl));
                }
                else
                    ModelState.AddModelError("", "invalid username or password");
            }
            return View();
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }
            return returnUrl;
        }


        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            SideBarDataStore.Dispose();
            return RedirectToAction("Login");
        }
        // GET: Auth
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Auth/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Auth/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Auth/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Auth/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Auth/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Auth/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Auth/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
