﻿using DataStore.DataStore;
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
            => View(new LoginViewModel { ReturnUrl = returnUrl });


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = UserDataStore.User.Where(x => x.Email == model.Email && x.Password == model.Password).SingleOrDefault();
        //        if (user != null)
        //        { 
        //           var identity = new ClaimsIdentity { }
        //             Request.GetOwinContext().Authentication.SignIn();
        //          wib
        //        }
        //    }
        //}

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
