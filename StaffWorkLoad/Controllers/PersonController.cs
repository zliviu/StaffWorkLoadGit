using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StaffWorkLoad.Models;

namespace StaffWorkLoad.Controllers {
	public class PersonController : Controller {
		private WorkLoadDBContext db = new WorkLoadDBContext();

		//
		// GET: /Person/

		public ViewResult Index() {
			return View(db.Staff.ToList());
		}

		//
		// GET: /Person/Details/5

		public ActionResult Details(int id = 0) {
			Person person = db.Staff.Find(id);
			if (person == null) {
				return HttpNotFound();
			}
			return View(person);
		}

		//
		// GET: /Person/Create

		public ActionResult Create() {
			loadColors();
			return View();
		}

		//
		// POST: /Person/Create

		[HttpPost]
		public ActionResult Create(Person person) {
			if (ModelState.IsValid) {
				db.Staff.Add(person);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(person);
		}

		//
		// GET: /Person/Edit/5

		public ActionResult Edit(int id = 0) {
			Person person = db.Staff.Find(id);
			if (person == null) {
				return HttpNotFound();
			}

			loadColors();
			return View(person);
		}

		//
		// POST: /Person/Edit/5

		[HttpPost]
		public ActionResult Edit(Person person) {
			if (ModelState.IsValid) {
				db.Entry(person).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(person);
		}

		//
		// GET: /Person/Delete/5

		public ActionResult Delete(int id = 0) {
			Person person = db.Staff.Find(id);
			if (person == null) {
				return HttpNotFound();
			}
			return View(person);
		}

		//
		// POST: /Person/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id = 0) {
			Person person = db.Staff.Find(id);
			if (person == null) {
				return HttpNotFound();
			}
			db.Staff.Remove(person);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		private void loadColors() {

			var knownColours = new List<string>();
			foreach (var color in Enum.GetNames(typeof(System.Drawing.KnownColor))) {

				var colorValue = System.Drawing.ColorTranslator.FromHtml(color);
				if (colorValue.IsNamedColor && !colorValue.IsSystemColor && colorValue.A > 0) 
					knownColours.Add(color);
			}

			ViewBag.LineColour = new SelectList(knownColours);
		}

		protected override void Dispose(bool disposing) {
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}