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
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Index";
            var result = await _context.People.ToListAsync();
            return (View(result));
        }
        [HttpPost]
        public virtual IActionResult Index(mvccoreappgithub.Models.Person p)
        {
            return (View(p));
        }

        ////////////////////////////////////InsertIndex
        [HttpGet]
        public virtual IActionResult InsertIndex()
        {
            return (View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult InsertIndex([Bind(include: "ID,JID,Name")]mvccoreappgithub.Models.Person p)
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
        public async Task<IActionResult> EditIndex(int? Id, int? JId)
        {
            if (!Id.HasValue || !JId.HasValue)
            {
                return BadRequest();
            }
            mvccoreappgithub.Models.Person ep =await _context.People.FirstOrDefaultAsync(e => e.ID == Id && e.JID == JId);
            if (ep == null)
            {
                return NotFound();
            }
            return (View(ep));
        }
        [HttpPost]
        public virtual IActionResult EditIndex(mvccoreappgithub.Models.Person p)
        {
            if (ModelState.IsValid)
            {
                //_context.Entry(p).State = EntityState.Modified;
                _context.Update(p);
                //mvccoreappgithub.Models.Person ep = _context.People.FirstOrDefault(e => e.ID == p.ID);
                //ep.Name = p.Name;
                _context.SaveChanges();
                Response.Redirect("/Home/Index", false);
            }
            return (View(p));
        }


        ////////////////////////////////////DeleteIndex
        public virtual IActionResult DeleteIndex(mvccoreappgithub.Models.Person p)
        {

            _context.Entry(p).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        ////////////////////////////////////HtmlIndex
        [HttpGet]
        public virtual IActionResult HtmlIndex()
        {
            return View();
        }
        [HttpPost]
        public virtual IActionResult HtmlIndex(string firstname, string lastname)
        {
            return View();
        }

        ////////////////////////////////////FromBody

        [HttpGet]
        public virtual IActionResult FromBody()
        {
            return View();
        }

        [HttpPost]
        public virtual IActionResult FromBody(Person p)
        {
            return View();
        }


        ////////////////////////////////////EditIndex1
        [HttpGet]
        public virtual IActionResult EditIndex1(int? Id, int? JId)
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
        public virtual IActionResult EditIndex1(mvccoreappgithub.Models.Person p)
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
        public virtual IActionResult InsertIndex1()
        {
            return (View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult InsertIndex1(mvccoreappgithub.Models.Person p)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return (View("InsertIndex1", p));

        }

        ////////////////////////////////////EditIndex1
        [HttpGet]
        public virtual IActionResult EditIndex2(int? Id, int? JId)
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
        public virtual IActionResult EditIndex2(mvccoreappgithub.Models.Person p)
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





        public IActionResult CheckUserName(string UserName)
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