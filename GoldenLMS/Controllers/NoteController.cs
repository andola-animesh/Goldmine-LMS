using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoldenLMS.Models;
using System.IO;

namespace GoldenLMS.Controllers
{
    //[Authorize]
    public class NoteController : Controller
    {
        private GoldenLMSEntities db = new GoldenLMSEntities();
        //
        // GET: /Note/

        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            IList<LeadNote> lstNote = new List<LeadNote>();
            var query = from note in db.NoteTbls
                        select new LeadNote
                        {
                            LeadId = note.LeadId,
                            Attachment = note.Attachment,
                            Comment = note.Comment
                        };
            lstNote = query.ToList();
            return View(lstNote);
        }

        public ActionResult FileUpload(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            IList<LeadNote> lstnote = new List<LeadNote>();
            var nquery = from note in db.NoteTbls.Where(x => x.LeadId == id)
                        select new LeadNote
                        {
                            LeadId = note.LeadId,
                            Attachment = note.Attachment,
                            Comment = note.Comment
                        };
            lstnote = nquery.ToList();

            if (lstnote.Count == 0)
            {
                IList<LeadNote> lstlead = new List<LeadNote>();
                var query = from lead in db.LeadTbls.Where(x => x.Id == id)
                            join user in db.UserTbls
                            on lead.AssignUser equals user.Id
                            select new LeadNote
                            {
                                Id = lead.Id,
                                Title = lead.Title,
                                ContactPerson = lead.ContactPerson,
                                EmailId = lead.EmailId,
                                ContactNo = lead.ContactNo,
                                Value = lead.Value,
                                Name = user.Name
                            };
                lstlead = query.ToList();
                return View(lstlead);
            }
            else
            {
                IList<LeadNote> lstLeadNote = new List<LeadNote>();
                var query = from lead in db.LeadTbls.Where(x => x.Id == id)
                            join note in db.NoteTbls.Where(x => x.LeadId == id)
                            on lead.Id equals note.LeadId
                            join user in db.UserTbls
                            on lead.AssignUser equals user.Id
                            select new LeadNote
                            {
                                Id = lead.Id,
                                Title = lead.Title,
                                ContactPerson = lead.ContactPerson,
                                EmailId = lead.EmailId,
                                ContactNo = lead.ContactNo,
                                Value = lead.Value,
                                Name = user.Name,
                                NoteId = note.NoteId,
                                LeadId = note.LeadId,
                                Attachment = note.Attachment,
                                Comment = note.Comment
                            };

                lstLeadNote = query.ToList();

                if (lstLeadNote == null)
                {
                    return HttpNotFound();
                }
                return View(lstLeadNote);
            }

        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase Attachment, NoteTbl notetbl)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var id = Url.RequestContext.RouteData.Values["id"];
            if (ModelState.IsValid)
            {
                if (Attachment == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (Attachment.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 3; //3 MB
                    string[] AllowedFileExtensions = new string[] { ".doc", ".docx", ".xls", ".ppt", ".pptx", ".xlsx", ".jpg", ".gif", ".png", ".pdf" };
                    if (!AllowedFileExtensions.Contains(Attachment.FileName.Substring(Attachment.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }
                    else if (Attachment.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        //TO:DO
                        var fileName = Path.GetFileName(Attachment.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                        Attachment.SaveAs(path);
                        notetbl.Attachment = Attachment.FileName;
                        notetbl.LeadId = Convert.ToInt32(id);
                        notetbl.Comment = notetbl.Comment;
                        notetbl.CreatedBy = Convert.ToInt32(Session["UserId"]);
                        notetbl.CreatedDate = DateTime.Now;

                        db.NoteTbls.Add(notetbl);
                        db.SaveChanges();
                        //ModelState.Clear();
                        //ViewBag.Message = "File uploaded successfully";
                    }
                }
            }
            return RedirectToAction("FileUpload");
        }

        //

        [HttpPost]
        public ContentResult UploadFiles()
        {
           
            var r = new List<LeadNote>();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                string savedFileName = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName);

                r.Add(new LeadNote()
                {
                    Attachment = hpf.FileName,
                   // Length = hpf.ContentLength,
                    //Type = hpf.ContentType
                });
            }
            return Content("{\"name\":\"" + r[0].Name + "\"}", "application/json");
        }

        // GET: /Note/Details/5

        public ActionResult Details(int id = 0)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            NoteTbl notetbl = db.NoteTbls.Find(id);
            if (notetbl == null)
            {
                return HttpNotFound();
            }
            return View(notetbl);
        }

        //
        // GET: /Note/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Note/Create

        [HttpPost]
        public ActionResult Create(NoteTbl notetbl)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                db.NoteTbls.Add(notetbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notetbl);
        }

        //
        // GET: /Note/Edit/5

        public ActionResult Edit(int id,int leadid)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            NoteTbl notetbl = db.NoteTbls.Find(id);
            if (notetbl == null)
            {
                return HttpNotFound();
            }
            return View(notetbl);
        }

        public ActionResult EditNote(int id,int leadid)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            IList<LeadNote> lstlead = new List<LeadNote>();
            var query = from note in db.NoteTbls.Where(x => x.NoteId == id && x.LeadId == leadid)
                               select new LeadNote()
                                {
                                    NoteId = note.NoteId,
                                    LeadId = note.LeadId,
                                    
                                    Attachment = note.Attachment,
                                    Comment = note.Comment
                                };
            lstlead = query.ToList();
            return View(lstlead);
        }

        //
        // POST: /Note/Edit/5

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase Attachment, NoteTbl notetbl)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                if (Attachment == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (Attachment.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 3; //3 MB
                    string[] AllowedFileExtensions = new string[] {".doc",".docx",".xls", ".xlsx",".ppt",".pptx",".jpg", ".gif", ".png", ".pdf" };
                    if (!AllowedFileExtensions.Contains(Attachment.FileName.Substring(Attachment.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }
                    else if (Attachment.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        //TO:DO
                        var fileName = Path.GetFileName(Attachment.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                        Attachment.SaveAs(path);
                        notetbl.Attachment = Attachment.FileName;
                        notetbl.UpdatedBy = Convert.ToInt32(Session["UserId"]);
                        notetbl.UpdatedDate = DateTime.Now;

                        db.Entry(notetbl).State = EntityState.Modified;
                        db.SaveChanges();
                        //ModelState.Clear();
                        //ViewBag.Message = "File uploaded successfully";
                    }
                }
                
            }
            return RedirectToAction("FileUpload", new { id = notetbl.LeadId });
        }

        //
        // GET: /Note/Delete/5

        public ActionResult Delete(int id, int leadid)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            NoteTbl notetbl = db.NoteTbls.Find(id);
            if (notetbl == null)
            {
                return HttpNotFound();
            }
            return View(notetbl);
        }

        //
        // POST: /Note/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            NoteTbl notetbl = db.NoteTbls.Find(id);
            db.NoteTbls.Remove(notetbl);
            db.SaveChanges();
            return RedirectToAction("FileUpload", new { id = notetbl.LeadId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}