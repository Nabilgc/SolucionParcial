using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCparcial.Models;

namespace MVCparcial.Controllers
{
    public class NabilGalebFriendsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: NabilGalebFriends
        public ActionResult Index()
        {
            return View(db.NabilGalebFriends.ToList());
        }

        // GET: NabilGalebFriends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NabilGalebFriend nabilGalebFriend = db.NabilGalebFriends.Find(id);
            if (nabilGalebFriend == null)
            {
                return HttpNotFound();
            }
            return View(nabilGalebFriend);
        }

        // GET: NabilGalebFriends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NabilGalebFriends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendID,NombreCompleto,TipoAmigo,Apodo,Cumpleanos")] NabilGalebFriend nabilGalebFriend)
        {
            if (ModelState.IsValid)
            {
                db.NabilGalebFriends.Add(nabilGalebFriend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nabilGalebFriend);
        }

        // GET: NabilGalebFriends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NabilGalebFriend nabilGalebFriend = db.NabilGalebFriends.Find(id);
            if (nabilGalebFriend == null)
            {
                return HttpNotFound();
            }
            return View(nabilGalebFriend);
        }

        // POST: NabilGalebFriends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendID,NombreCompleto,TipoAmigo,Apodo,Cumpleanos")] NabilGalebFriend nabilGalebFriend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nabilGalebFriend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nabilGalebFriend);
        }

        // GET: NabilGalebFriends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NabilGalebFriend nabilGalebFriend = db.NabilGalebFriends.Find(id);
            if (nabilGalebFriend == null)
            {
                return HttpNotFound();
            }
            return View(nabilGalebFriend);
        }

        // POST: NabilGalebFriends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NabilGalebFriend nabilGalebFriend = db.NabilGalebFriends.Find(id);
            db.NabilGalebFriends.Remove(nabilGalebFriend);
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
