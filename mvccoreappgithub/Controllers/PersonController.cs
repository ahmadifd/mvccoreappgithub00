using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvccoreappgithub.Data;
using Microsoft.EntityFrameworkCore;
using mvccoreappgithub.Models;

namespace mvccoreappgithub.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        ////////////////////////////////////Index
        [HttpGet]
        public virtual ActionResult Index()
        {
            ViewBag.Title = "Index";
            var result = _context.People.ToList();
            return (View(result));
        }
        [HttpPost]
        public virtual ActionResult Index(mvccoreappgithub.Models.Person p)
        {
            return (View(p));
        }

        ////////////////////////////////////InsertIndex
        [HttpGet]
        public virtual ActionResult InsertIndex()
        {
            return (View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult InsertIndex([Bind(include:"ID,JID,Name" )]mvccoreappgithub.Models.Person p)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return (View("InsertIndex", p));

        }

        ////////////////////////////////////EditIndex
        [HttpGet]
        public virtual ActionResult EditIndex(int? Id, int? JId)
        {
            if (!Id.HasValue || !JId.HasValue)
            {
                return BadRequest();
            }
            mvccoreappgithub.Models.Person ep = _context.People.FirstOrDefault(e => e.ID == Id && e.JID == JId);
            if (ep == null)
            {
                return NotFound();
            }
            return (View(ep));
        }
        [HttpPost]
        public virtual ActionResult EditIndex(mvccoreappgithub.Models.Person p)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(p).State = EntityState.Modified;
                //mvccoreappgithub.Models.Person ep = _context.People.FirstOrDefault(e => e.ID == p.ID);
                //ep.Name = p.Name;
                _context.SaveChanges();
                Response.Redirect("/Home/Index", false);
            }
            return (View(p));
        }


        ////////////////////////////////////DeleteIndex
        public virtual ActionResult DeleteIndex(mvccoreappgithub.Models.Person p)
        {

            _context.Entry(p).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        ////////////////////////////////////HtmlIndex
        [HttpGet]
        public virtual ActionResult HtmlIndex()
        {
            return View();
        }
        [HttpPost]
        public virtual ActionResult HtmlIndex(string firstname, string lastname)
        {
            return View();
        }

        ////////////////////////////////////FromBody

        [HttpGet]
        public virtual ActionResult FromBody()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult FromBody(Person p)
        {
            return View();
        }


        ////////////////////////////////////EditIndex1
        [HttpGet]
        public virtual ActionResult EditIndex1(int? Id, int? JId)
        {
            if (!Id.HasValue || !JId.HasValue)
            {
                return BadRequest();
            }
            mvccoreappgithub.Models.Person ep = _context.People.FirstOrDefault(e => e.ID == Id && e.JID == JId);
            if (ep == null)
            {
                return NotFound();
            }
            return (View(ep));
        }
        [HttpPost]
        public virtual ActionResult EditIndex1(mvccoreappgithub.Models.Person p)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(p).State = EntityState.Modified;
                //mvccoreappgithub.Models.Person ep = _context.People.FirstOrDefault(e => e.ID == p.ID);
                //ep.Name = p.Name;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return (View(p));
        }

        ////////////////////////////////////InsertIndex1
        [HttpGet]
        public virtual ActionResult InsertIndex1()
        {
            return (View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult InsertIndex1(mvccoreappgithub.Models.Person p)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return (View("InsertIndex1", p));

        }






        public ActionResult CheckUserName(string UserName)
        {
            var result = _context.People.FirstOrDefault(r => r.UserName == UserName);

            if (result == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);

            }
        }





    }
}