using shariqFaizan.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shariqFaizan.Controllers
{
    public class ProductController : Controller
    {
        String fn, ext,Img,pic;
        HttpPostedFileBase ImageFile1;
        // GET: Product
        public ActionResult Index()
        {
            ProductDB pd= new ProductDB();
            ModelState.Clear();
            return View(pd.GetProducts());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            ProductDB pd = new ProductDB();
            return View(pd.GetProducts().Find(smodel => smodel.id == id));         
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            ProductDB pd = new ProductDB();

            fn = Path.GetFileNameWithoutExtension(pro.ImageFile.FileName);
            ext = Path.GetExtension(pro.ImageFile.FileName);
            fn = fn + DateTime.Now.ToString("yymmssfff") + ext;
            pro.path = "~/images/" + fn;
            fn = Path.Combine(Server.MapPath("~/images/"), fn);
            pro.ImageFile.SaveAs(fn);

            //ImageFile1.SaveAs(fn);
            pro.picture = fn.ToString();

            try
            {
                if (ModelState.IsValid)
                {
                    if (pd.AddProduct(pro))
                    {
                        ViewBag.Message = "Product Added Successfully";
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductDB pd= new ProductDB();
            //Product thisProduct = pd.GetProducts.Where(p => p.Id == product.Id).FirstOrDefault();
            //Img = pd.GetProducts().Find(smodel => smodel.id == id).path;
            //pic = pd.GetProducts().Find(smodel => smodel.id == id).picture;
            //ImageFile1 = pd.GetProducts().Find(smodel => smodel.id == id).ImageFile;
            return View(pd.GetProducts().Find(smodel => smodel.id == id));
        }

        // POST: student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pro)
        {
            ProductDB pd = new ProductDB();
            Product thisProduct = pd.GetProducts().Where(p => p.id == pro.id).FirstOrDefault();

            if (pro.ImageFile==null)
            {
                pro.path = thisProduct.path;
                pro.picture = thisProduct.picture;
                //pro.ImageFile = ImageFile1;
              

            }
            else
            {
                fn = Path.GetFileNameWithoutExtension(pro.ImageFile.FileName);
                ext = Path.GetExtension(pro.ImageFile.FileName);
                fn = fn + DateTime.Now.ToString("yymmssfff") + ext;
                pro.path = "~/images/" + fn;
                fn = Path.Combine(Server.MapPath("~/images/"), fn);
                pro.ImageFile.SaveAs(fn);

                pro.picture = fn.ToString();
            }
           
            try
            {
                ProductDB pdd = new ProductDB();
                pdd.UpdateProduct(pro);
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
                 ProductDB pd = new ProductDB();
                if (pd.DeleteProduct(id))
                {
                    ViewBag.AlertMsg = "Product Deleted Successfully";
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
