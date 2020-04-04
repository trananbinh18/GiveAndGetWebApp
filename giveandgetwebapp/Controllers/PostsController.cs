using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using giveandgetwebapp.Filter;
using giveandgetwebapp.Models;

namespace giveandgetwebapp.Controllers
{
    [CheckSession]
    public class PostsController : Controller
    {
        private cap22t6Entities db = new cap22t6Entities();

        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Catalog).Include(p => p.Image1).Include(p => p.Image4).Include(p => p.Image5).Include(p => p.User).Include(p => p.User1);
            return View(posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.CatalogId = new SelectList(db.Catalogs, "Id", "Name");
            ViewBag.Image = new SelectList(db.Images, "Id", "Id");
            ViewBag.Image2 = new SelectList(db.Images, "Id", "Id");
            ViewBag.Image3 = new SelectList(db.Images, "Id", "Id");
            ViewBag.Actor = new SelectList(db.Users, "Id", "StudentId");
            ViewBag.Receiver = new SelectList(db.Users, "Id", "StudentId");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CatalogId,Actor,Receiver,Image,Image2,Image3,Title,Contents,CreateDate,ExpireDate,GiveType,Status,ReceiverCount,ExpireType")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatalogId = new SelectList(db.Catalogs, "Id", "Name", post.CatalogId);
            ViewBag.Image = new SelectList(db.Images, "Id", "Id", post.Image);
            ViewBag.Image2 = new SelectList(db.Images, "Id", "Id", post.Image2);
            ViewBag.Image3 = new SelectList(db.Images, "Id", "Id", post.Image3);
            ViewBag.Actor = new SelectList(db.Users, "Id", "StudentId", post.Actor);
            ViewBag.Receiver = new SelectList(db.Users, "Id", "StudentId", post.Receiver);
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatalogId = new SelectList(db.Catalogs, "Id", "Name", post.CatalogId);
            ViewBag.Image = new SelectList(db.Images, "Id", "Id", post.Image);
            ViewBag.Image2 = new SelectList(db.Images, "Id", "Id", post.Image2);
            ViewBag.Image3 = new SelectList(db.Images, "Id", "Id", post.Image3);
            ViewBag.Actor = new SelectList(db.Users, "Id", "StudentId", post.Actor);
            ViewBag.Receiver = new SelectList(db.Users, "Id", "StudentId", post.Receiver);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CatalogId,Actor,Receiver,Image,Image2,Image3,Title,Contents,CreateDate,ExpireDate,GiveType,Status,ReceiverCount,ExpireType")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatalogId = new SelectList(db.Catalogs, "Id", "Name", post.CatalogId);
            ViewBag.Image = new SelectList(db.Images, "Id", "Id", post.Image);
            ViewBag.Image2 = new SelectList(db.Images, "Id", "Id", post.Image2);
            ViewBag.Image3 = new SelectList(db.Images, "Id", "Id", post.Image3);
            ViewBag.Actor = new SelectList(db.Users, "Id", "StudentId", post.Actor);
            ViewBag.Receiver = new SelectList(db.Users, "Id", "StudentId", post.Receiver);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
