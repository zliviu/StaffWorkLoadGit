using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

using StaffWorkLoad.Models;

namespace StaffWorkLoad.Controllers {
	public class WorkLoadController : Controller {
		private WorkLoadDBContext db = new WorkLoadDBContext();

		//
		// GET: /WorkLoad/

		public ActionResult Index() {

			var prevSunday = DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek);
			var sDate = prevSunday.AddDays(-7).ToString("dd/MM/yyy");
			var eDate = prevSunday.AddDays(7).ToString("dd/MM/yyy");

			//return View(db.WorkLoads.ToList());
			return SearchIndex("", sDate, eDate);
		}

		//
		// GET: /WorkLoad/Details/5

		public ActionResult Details(int id = 0) {
			WorkLoad workload = db.WorkLoads.Find(id);
			if (workload == null) {
				return HttpNotFound();
			}
			return View(workload);
		}

		//
		// GET: /WorkLoad/Create

		public ActionResult Create() {
			ViewBag.PersonID = new SelectList(db.Staff, "PersonID", "FullName");
			return View();
		}

		//
		// POST: /WorkLoad/Create

		[HttpPost]
		public ActionResult Create(WorkLoad workload) {
			if (ModelState.IsValid) {
				db.WorkLoads.Add(workload);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.PersonID = new SelectList(db.Staff, "PersonID", "FullName", workload.PersonID);
			return View(workload);
		}

		//
		// GET: /WorkLoad/Edit/5

		public ActionResult Edit(int id=0) {
			WorkLoad workload = db.WorkLoads.Find(id);
			if (workload == null) {
				return HttpNotFound();
			}
			ViewBag.PersonID = new SelectList(db.Staff, "PersonID", "FullName", workload.PersonID); 
			return View(workload);
		}

		//
		// POST: /WorkLoad/Edit/5

		[HttpPost]
		public ActionResult Edit(WorkLoad workload) {
			if (ModelState.IsValid) {
				db.Entry(workload).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.PersonID = new SelectList(db.Staff, "PersonID", "FullName", workload.PersonID); 
			return View(workload);
		}

		//
		// GET: /WorkLoad/Delete/5

		public ActionResult Delete(int id=0) {
			WorkLoad workload = db.WorkLoads.Find(id);
			if (workload == null) {
				return HttpNotFound();
			}
			return View(workload);
		}

		//
		// POST: /WorkLoad/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id=0) {
			WorkLoad workload = db.WorkLoads.Find(id);
			if (workload == null) {
				return HttpNotFound();
			}
			db.WorkLoads.Remove(workload);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		//
		// GET: /WorkLoad/SearchIndex/1

		public ActionResult SearchIndex(string staffName, string sDate, string eDate) {
			var staffLst = new List<string>();

			var staffQry = from s in db.WorkLoads
										 orderby s.StaffName.FirstName
										 select s.StaffName.FirstName;
			staffLst.AddRange(staffQry.Distinct());
			ViewBag.staffName = new SelectList(staffLst);

			ViewBag.sDate = sDate;	//.Value.ToShortDateString();
			ViewBag.eDate = eDate;	//.Value.ToShortDateString();

			var workloads = from w in db.WorkLoads
											select w;

			if (!String.IsNullOrEmpty(staffName)) {
				workloads = workloads.Where(p => p.StaffName.FirstName == staffName);
			}

			if (!String.IsNullOrEmpty(sDate)) {
				var sdate = DateTime.ParseExact(sDate, "dd/MM/yyyy", null);
				workloads = workloads.Where(x => x.StartDate >= sdate);
			}
			if (!String.IsNullOrEmpty(eDate)) {
				var edate = DateTime.ParseExact(eDate, "dd/MM/yyyy", null);
				workloads = workloads.Where(x => x.EndDate <= edate);
			}

			workloads = workloads.OrderBy(x => x.StartDate).ThenBy(x => x.StaffName.FirstName).ThenBy(x => x.StaffName.LastName);

			return View("Index", workloads);
		}

		//
		// GET: /WorkLoad/GetTimelineData

		public JsonResult GetTimelineData() {

			var workloadEvents = (from w in db.WorkLoads
											orderby w.StartDate, w.StaffName.FirstName, w.StaffName.LastName
											select new {
												w.StaffName.FirstName,
												w.StaffName.LastName,
												w.WorkType,
												w.StartDate,
												w.EndDate,
												w.Notes,
												w.StaffName.LineColour
											})
											.AsEnumerable()
											.Select(wl => new {
												start = wl.StartDate.ToString("r"),
												end = wl.EndDate.AddHours(23).ToString("r"),
												title = wl.FirstName + " - " + wl.WorkType,
												description = wl.Notes,
												color = wl.LineColour
											});

			// in order for the SIMILE timeline to work we need to return the data in an object called 'events'
			var workloads = new { events = workloadEvents };

			//var temp = workloadEvents.ToList();

			return Json(workloads, JsonRequestBehavior.AllowGet);
		}

		protected override void Dispose(bool disposing) {
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}