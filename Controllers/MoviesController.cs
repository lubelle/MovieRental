﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //return View(movie);
            //return Content("Hello");
            //return HttpNotFound();
            //return new EmptyResult();
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        //ViewResult View()
        //PartialViewResult PartialView()
        //ContentResult   Content()
        //RedirectResult  Redirect()
        //RedirectToRouteResult   RedirectToAction() 
        //JsonResult  Json() 
        //FileResult  File() 
        //HttpNotFoundResult  HttpNotFound()
        //

        // Ctrl+Shift+B
        // Alt+Tab
        // Ctrl+R

        // Parameter Sources
        // in the url: /movies/edit/1
        // in the query string: /movies/edit?id=1
        // in the form data: id=1

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

    }
}