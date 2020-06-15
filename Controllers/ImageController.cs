using ImageUploadEF.Models;
using ImageUploadEF.Models.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUploadEF.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult New()
        {
             
            return View();
        }
        [HttpPost]
        public ActionResult New(Images image)
        {
            DatabaseContex db = new DatabaseContex();
            if (image.FileBase != null && image.FileBase.ContentLength > 0)
            {
                var fileName = Path.GetFileName(image.Name+"."+image.FileBase.FileName.Split('.')[1]);
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                image.FileBase.SaveAs(path);
                image.ImageFileName = fileName;
            }
            db.Images.Add(image);
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                ViewBag.Result = "Created image";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Registration failed";
                ViewBag.Status = "danger";
            }
            return RedirectToAction("Index","Home");
        }

        public ActionResult Update(int? imageId)
        {
            Images image = null;
            if(imageId != null)
            {
                DatabaseContex db = new DatabaseContex();
                image = db.Images.Where(x => x.ID == imageId).FirstOrDefault();
            }
            return View(image);
        }

        [HttpPost]
        public ActionResult Update(Images model, int? imageId)
        {
            DatabaseContex db = new DatabaseContex();
            Images image = db.Images.Where(x => x.ID == imageId).FirstOrDefault();
            if (image != null)
            {
                if (model.FileBase != null && model.FileBase.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(model.Name + "." + model.FileBase.FileName.Split('.')[1]);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    model.FileBase.SaveAs(path);
                    model.ImageFileName = fileName;

                    image.Name = model.Name;
                    image.ImageFileName = model.ImageFileName;
                    int sonuc = db.SaveChanges();
                    if (sonuc > 0)
                    {
                        ViewBag.Result = "Updated image";
                        ViewBag.Status = "success";
                    }
                    else
                    {
                        ViewBag.Result = "Registration failed";
                        ViewBag.Status = "danger";
                    }
                }
            }
            return RedirectToAction("Index","Home");
        }
        public ActionResult Delete(int? imageId)
        {
            Images image = null;
            if (imageId != null)
            {
                DatabaseContex db = new DatabaseContex();
                image = db.Images.Where(x => x.ID == imageId).FirstOrDefault();
            }
            return View(image);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteOk(int? imageId)
        {
            if (imageId != null)
            {
                DatabaseContex db = new DatabaseContex();
                Images image = db.Images.Where(x => x.ID == imageId).FirstOrDefault();
                db.Images.Remove(image);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}