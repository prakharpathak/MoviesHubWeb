using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesHubWeb.DATA;
using MoviesHubWeb.Models;

namespace MoviesHubWeb.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MHB_DBContext _db;

        public MoviesController(MHB_DBContext db)
        {
            _db= db;    
        }
        public IActionResult Index()
        {
            IEnumerable<Movies> ObjMoviesList=  _db.Movies;

            return View(ObjMoviesList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movies obj)
        {
            //Custom Error Example
            if (obj.Name == obj.Rating.ToString())
            {
                ModelState.AddModelError("Name", "Name cannot be as name as Rating");
            }

            //validation then adding to DB
            if (ModelState.IsValid)
            {
                _db.Movies.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Movie "+obj.Name+ " is successfully Added !!!!!!";
                return RedirectToAction("Index");
            }
            else return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();
            }
            else
            {
                var MoviesFromDB = _db.Movies.Find(id);
                //var MoviesFromDBSingle = _db.Movies.SingleOrDefault(u => u.Id==id);
                //var MoviesFromDBFirst = _db.Movies.FirstOrDefault(u => u.Id == id);
                if(MoviesFromDB == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(MoviesFromDB);
                }

            }
            ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movies obj)
        {
            //Custom Error Example
            if (obj.Name == obj.Rating.ToString())
            {
                ModelState.AddModelError("Name", "Name cannot be as name as Ratings");
            }

            //validation then adding to DB
            if (ModelState.IsValid)
            {
                TempData["Success"] = "Movie " + obj.Name + " is successfully Updated !!!!!!";
                _db.Movies.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(obj);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();
            }
            else
            {
                var MoviesFromDB = _db.Movies.Find(id);
                //var MoviesFromDBSingle = _db.Movies.SingleOrDefault(u => u.Id==id);
                //var MoviesFromDBFirst = _db.Movies.FirstOrDefault(u => u.Id == id);
                if (MoviesFromDB == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(MoviesFromDB);
                }

            }
    ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCat(int? id)
        {
            var obj = _db.Movies.Find(id);
            if(obj == null)
            {
                return BadRequest();
            }
            TempData["Success"] = "Movie " + obj.Name + " is successfully Deleted !!!!!!";
            _db.Movies.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
