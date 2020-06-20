using shariqFaizan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shariqFaizan.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoryDB dbhandle = new CategoryDB();
            ModelState.Clear();
            return View(dbhandle.GetCategory());
            
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryDB sdb = new CategoryDB();
                    if (sdb.AddCategory(smodel))
                    {
                        ViewBag.Message = "Category Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            CategoryDB sdb = new CategoryDB();
            return View(sdb.GetCategory().Find(smodel => smodel.ct_id == id));
            
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category smodel)
        {
            try
            {
                CategoryDB sdb = new CategoryDB();
                sdb.UpdateCategory(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CategoryDB sdb = new CategoryDB();
                if (sdb.DeleteCategory(id))
                {
                    ViewBag.AlertMsg = "Category Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        

    }
}
