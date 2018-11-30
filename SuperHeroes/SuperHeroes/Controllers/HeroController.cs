using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperHeroes.Models;

namespace SuperHeroes.Controllers
{
    public class HeroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Hero
        public ActionResult Index()
        {
            List<SuperHero> superHeroes = new List<SuperHero>();
            superHeroes = db.SuperHeroes.ToList();
            return View(superHeroes);
        }

        // GET: Hero/Details/5
        public ActionResult Details(int id)
        {
            SuperHero superHero = new SuperHero();
            superHero = db.SuperHeroes.Where(s => s.Id == id).Single();
            return View(superHero);
        }

        // GET: Hero/Create
        public ActionResult Create()
        {            
            return View();
        }

        // POST: Hero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SuperHeroName,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] SuperHero superHero)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                db.SuperHeroes.Add(superHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        // GET: Hero/Edit/5
        public ActionResult Edit(int id)
        {
            SuperHero superHero = db.SuperHeroes.Where(s => s.Id == id).Single();
            return View(superHero);
        }

        // POST: Hero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SuperHeroName,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] SuperHero superHero)
        {
            try
            {                               
                SuperHero editedSuperHero = db.SuperHeroes.Where(s => s.Id == superHero.Id).Single();
                editedSuperHero.SuperHeroName = superHero.SuperHeroName;
                editedSuperHero.AlterEgo = superHero.AlterEgo;
                editedSuperHero.PrimaryAbility = superHero.PrimaryAbility;
                editedSuperHero.SecondaryAbility = superHero.SecondaryAbility;
                editedSuperHero.CatchPhrase = superHero.CatchPhrase;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }            
        }

        // GET: Hero/Delete/5
        public ActionResult Delete(int id)
        {
            SuperHero superHero = db.SuperHeroes.Where(s => s.Id == id).Single();
            return View(superHero);
        }

        // POST: Hero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SuperHero superHero)
        {
            try
            {
                // TODO: Add delete logic here
                superHero = db.SuperHeroes.Where(s => s.Id == superHero.Id).Single();
                db.SuperHeroes.Remove(superHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
