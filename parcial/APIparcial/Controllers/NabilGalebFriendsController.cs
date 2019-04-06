using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIparcial.Models;

namespace APIparcial.Controllers
{
    public class NabilGalebFriendsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/NabilGalebFriends
        public IQueryable<NabilGalebFriend> GetNabilGalebFriends()
        {
            return db.NabilGalebFriends;
        }

        // GET: api/NabilGalebFriends/5
        [ResponseType(typeof(NabilGalebFriend))]
        public IHttpActionResult GetNabilGalebFriend(int id)
        {
            NabilGalebFriend nabilGalebFriend = db.NabilGalebFriends.Find(id);
            if (nabilGalebFriend == null)
            {
                return NotFound();
            }

            return Ok(nabilGalebFriend);
        }

        // PUT: api/NabilGalebFriends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNabilGalebFriend(int id, NabilGalebFriend nabilGalebFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nabilGalebFriend.FriendID)
            {
                return BadRequest();
            }

            db.Entry(nabilGalebFriend).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NabilGalebFriendExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NabilGalebFriends
        [ResponseType(typeof(NabilGalebFriend))]
        public IHttpActionResult PostNabilGalebFriend(NabilGalebFriend nabilGalebFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NabilGalebFriends.Add(nabilGalebFriend);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nabilGalebFriend.FriendID }, nabilGalebFriend);
        }

        // DELETE: api/NabilGalebFriends/5
        [ResponseType(typeof(NabilGalebFriend))]
        public IHttpActionResult DeleteNabilGalebFriend(int id)
        {
            NabilGalebFriend nabilGalebFriend = db.NabilGalebFriends.Find(id);
            if (nabilGalebFriend == null)
            {
                return NotFound();
            }

            db.NabilGalebFriends.Remove(nabilGalebFriend);
            db.SaveChanges();

            return Ok(nabilGalebFriend);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NabilGalebFriendExists(int id)
        {
            return db.NabilGalebFriends.Count(e => e.FriendID == id) > 0;
        }
    }
}