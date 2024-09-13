using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Context;
using project.Models;
using project.ViewModel;

namespace project.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper _mapper;

        public CategoryController(ApplicationDbContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var _Categories = db.Categories.ToList();

            return View(_Categories);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Category = db.Categories.Find(id);

            if (_Category == null)
            {
                return RedirectToAction("Index");
            }

            return View(_Category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryVM categoryVm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                return View(categoryVm);
            }

            var category = _mapper.Map<Category>(categoryVm);

            db.Categories.Add(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _Category = db.Categories.Find(id);
            if (_Category == null)
            {
                return RedirectToAction("Index");
            }

            var categoryvm = _mapper.Map<CategoryVM>(_Category);

            return View(categoryvm);
        }

        [HttpPost]
        public IActionResult Edit(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                return View(categoryVM);
            }

            var category = _mapper.Map<Category>(categoryVM);

            db.Categories.Update(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var _Category = db.Categories.Find(id);

            if (_Category is not null)
            {
                db.Categories.Remove(_Category);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult CheckUnique(string name, int? categoryId)
        {
            bool isUnique;

            if (categoryId.HasValue)
            {
                // Edit scenario: Check if the name is unique except for the current category
                isUnique = !db.Categories
                               .Any(c => c.Name == name && c.CategoryId != categoryId.Value);
            }
            else
            {
                // Create scenario: Check if the name is unique
                isUnique = !db.Categories
                               .Any(c => c.Name == name);
            }

            return Json(isUnique);
        }
    }
}
