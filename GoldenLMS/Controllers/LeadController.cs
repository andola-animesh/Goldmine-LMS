using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoldenLMS.Models;
using PagedList;
using PagedList.Mvc;

namespace GoldenLMS.Controllers
{
    //[Authorize]
    
    public class LeadController : Controller
    {
        private GoldenLMSEntities db = new GoldenLMSEntities();

        //
        // GET: /Lead/
        public ActionResult Index()
        {
            IList<LeadUser> lstLead = new List<LeadUser>();
            var query = from lead in db.LeadTbls
                        join user in db.UserTbls
                        on lead.AssignUser equals user.Id
                        select new LeadUser
                        {
                            Id = lead.Id,
                            Title = lead.Title,
                            ContactPerson = lead.ContactPerson,
                            EmailId = lead.EmailId,
                            ContactNo = lead.ContactNo,
                            Name = user.Name,
                            Status = lead.Status,
                            Value = lead.Value

                        };
            lstLead = query.ToList();
            return View(lstLead);

            //return View(db.LeadTbls.ToList());
        }

        public ActionResult StatusIndex(string status, string sortOrder, string CurrentSort, int? page)
        {
            if (Session["UserId"] == null)
            {
				return RedirectToAction("Index", "Home");
            }
                int pageSize = 10;
                int pageIndex = 1;
                pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                ViewBag.CurrentSort = sortOrder;

                sortOrder = String.IsNullOrEmpty(sortOrder) ? "Id" : sortOrder;

                IPagedList<LeadUser> listLead = null;
                IList<LeadUser> lstLead = null;

                lstLead = GetList(status);
                switch (sortOrder)
                {
                    case "Id":
                        if (sortOrder.Equals(CurrentSort))

                            listLead = lstLead.OrderByDescending(m => m.Id).ToPagedList(pageIndex, pageSize);
                        else
                            listLead = lstLead.OrderBy(m => m.Id).ToPagedList(pageIndex, pageSize);
                        break;
                    case "Title":
                        if (sortOrder.Equals(CurrentSort))

                            listLead = lstLead.OrderByDescending(m => m.Title).ToPagedList(pageIndex, pageSize);
                        else
                            listLead = lstLead.OrderBy(m => m.Title).ToPagedList(pageIndex, pageSize);
                        break;
                    case "ContactPerson":
                        if (sortOrder.Equals(CurrentSort))
                            listLead = lstLead.OrderByDescending(m => m.ContactPerson).ToPagedList(pageIndex, pageSize);
                        else
                            listLead = lstLead.OrderBy(m => m.ContactPerson).ToPagedList(pageIndex, pageSize);
                        break;
                    case "EmailId":
                        if (sortOrder.Equals(CurrentSort))
                            listLead = lstLead.OrderByDescending(m => m.EmailId).ToPagedList(pageIndex, pageSize);
                        else
                            listLead = lstLead.OrderBy(m => m.EmailId).ToPagedList(pageIndex, pageSize);
                        break;
                    case "Value":
                        if (sortOrder.Equals(CurrentSort))
                            listLead = lstLead.OrderByDescending(m => m.Value).ToPagedList(pageIndex, pageSize);
                        else
                            listLead = lstLead.OrderBy(m => m.Value).ToPagedList(pageIndex, pageSize);
                        break;
                    case "Name":
                        if (sortOrder.Equals(CurrentSort))
                            listLead = lstLead.OrderByDescending(m => m.Name).ToPagedList(pageIndex, pageSize);
                        else
                            listLead = lstLead.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                        break;
                    case "Default":
                        listLead = lstLead.OrderBy(m => m.Id).ToPagedList(pageIndex, pageSize);
                        break;
                }

                return View(listLead);
          

            //return View(db.LeadTbls.ToList());
        }

        public IList<LeadUser> GetList(string status)
        {
           
            if (status == null || status == "All")
            {
                IList<LeadUser> lstLead = new List<LeadUser>();
                var query = from lead in db.LeadTbls
                            join user in db.UserTbls
                            on lead.AssignUser equals user.Id
                            select new LeadUser
                            {
                                Id = lead.Id,
                                Title = lead.Title,
                                ContactPerson = lead.ContactPerson,
                                EmailId = lead.EmailId,
                                ContactNo = lead.ContactNo,
                                Name = user.Name,
                                Status = lead.Status,
                                Value = lead.Value

                            };

                lstLead = query.ToList();
                return lstLead;
            }
            else
            {
                IList<LeadUser> lstLead = new List<LeadUser>();
                var query = from lead in db.LeadTbls.Where(x => x.Status == status)
                            join user in db.UserTbls
                            on lead.AssignUser equals user.Id
                            select new LeadUser
                            {
                                Id = lead.Id,
                                Title = lead.Title,
                                ContactPerson = lead.ContactPerson,
                                EmailId = lead.EmailId,
                                ContactNo = lead.ContactNo,
                                Name = user.Name,
                                Status = lead.Status,
                                Value = lead.Value

                            };

                lstLead = query.ToList();
                return lstLead;
            }
            
        }

        //
        // GET: /Lead/Details/5
        public ActionResult Details(int id = 0)
        {
            //LeadTbl leadtbl = db.LeadTbls.Find(id);
            if (Session["UserId"] == null)
            {
				return RedirectToAction("Index", "Home");
            }
            LeadUser model = db.LeadTbls.Where(x => x.Id == id).Select(x =>
                                                 new LeadUser
                                                 {
                                                     Id = x.Id,
                                                     Title = x.Title,
                                                     ContactPerson = x.ContactPerson,
                                                     EmailId = x.EmailId,
                                                     ContactNo = x.ContactNo,
                                                     //Name = x.UserName.Name,
                                                     Value = x.Value
                                                 }).SingleOrDefault();

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //
        // GET: /Lead/Create
        public ActionResult Create()
        {
            ViewBag.AssignUser = new SelectList(db.UserTbls, "Id", "Name");
            return View();
        }

        //
        // POST: /Lead/Create
        [HttpPost]
        public ActionResult Create(LeadTbl leadtbl)
        {
            if (Session["UserId"] == null)
            {
				return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                leadtbl.Status = "New";
                leadtbl.CreatedBy = Convert.ToInt32(Session["UserId"]);
                leadtbl.CreatedDate = DateTime.Now;
                db.LeadTbls.Add(leadtbl);
                db.SaveChanges();
                return RedirectToAction("StatusIndex");
            }
            ViewBag.AssignUser = new SelectList(db.UserTbls, "Id", "Name", leadtbl.AssignUser);
            return View(leadtbl);
         
        }

        //
        // GET: /Lead/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (Session["UserId"] == null)
            {
				return RedirectToAction("Index", "Home");
            }

            LeadTbl leadtbl = db.LeadTbls.Find(id);
            if (leadtbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssignUser = new SelectList(db.UserTbls, "Id", "Name", leadtbl.AssignUser);
            return View(leadtbl);
           
        }

        //
        // POST: /Lead/Edit/5
        [HttpPost]
        public ActionResult Edit(LeadTbl leadtbl)
        {
            if (Session["UserId"] == null)
            {
				return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                leadtbl.UpdatedBy = Convert.ToInt32(Session["UserId"]);
                leadtbl.UpdatedDate = DateTime.Now;

                db.Entry(leadtbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("StatusIndex");
            }
            ViewBag.AssignUser = new SelectList(db.UserTbls, "Id", "Name", leadtbl.AssignUser);
            return View(leadtbl);
 
        }

        //
        // GET: /Lead/Delete/5
        public ActionResult Delete(int id = 0)
        {
            //LeadTbl leadtbl = db.LeadTbls.Find(id);
            //if (leadtbl == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(leadtbl);
            if (Session["UserId"] == null)
            {
				return RedirectToAction("Index", "Home");
            }
             IList<LeadUser> lstLead = new List<LeadUser>();
             var query = from lead in db.LeadTbls.Where(x => x.Id == id)
                         join user in db.UserTbls
                         on lead.AssignUser equals user.Id
                         select new LeadUser
                         {
                             Id = lead.Id,
                             Title = lead.Title,
                             ContactPerson = lead.ContactPerson,
                             EmailId = lead.EmailId,
                             ContactNo = lead.ContactNo,
                             Name = user.Name,
                             Value = lead.Value
                         };
            lstLead = query.ToList();
            return View(lstLead);
         }

        //
        // POST: /Lead/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserId"] == null)
            {
				return RedirectToAction("Index", "Home");
            }
            LeadTbl leadtbl = db.LeadTbls.Find(id);
            db.LeadTbls.Remove(leadtbl);
            db.SaveChanges();
            return RedirectToAction("StatusIndex");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}