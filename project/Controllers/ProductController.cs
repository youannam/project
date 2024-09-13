using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Context;
using project.IServices;
using project.Models;
using project.ViewModel;

namespace project.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ProductController(ApplicationDbContext context, IMapper mapper, IImageService imageService)
        {
            db = context;
            _mapper = mapper;
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var _Product = db.Products.Include(c => c.Category);
            return View(_Product);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Product = db.Products.Include(p => p.Category).FirstOrDefault(Pro => Pro.Id == id);

            if (_Product == null)
            {
                return RedirectToAction("Index");
            }

            var productVM = _mapper.Map<ProductVM>(_Product);

            return View(productVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Categories = new SelectList(db.Categories.ToList(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");
                return View(productVM);
            }

            //Validate Image
            var ImgPath = _imageService.SaveImages(productVM.ImageUrl!);
            if (ImgPath is null)
            {
                ModelState.AddModelError("ImageUrl", "Invalid Photo");
                ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");
                return View(productVM);
            }

            productVM.ImagePath = ImgPath;

            var product = _mapper.Map<Product>(productVM);

            db.Products.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _Product = db.Products.Include(p => p.Category).FirstOrDefault(Pro => Pro.Id == id);
            if (_Product == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");

            var product = _mapper.Map<ProductVM>(_Product);

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(ProductVM productVM, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");
                return View(productVM);
            }

            var product = db.Products.Find(id);
            if (product is null)
                return RedirectToAction("Index");

            //Validate Image
            if (productVM.ImageUrl is not null)
            {
                var ImgPath = _imageService.UpdateImages(productVM.ImageUrl!, product.ImagePath!);
                if (ImgPath is null)
                {
                    ModelState.AddModelError("ImageUrl", "Invalid Photo");
                    ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");
                    return View(productVM);
                }
                product.ImagePath = ImgPath;
            }

            product.CategoryId = productVM.CategoryId;
            product.Description = productVM.Description;
            product.price = productVM.price;
            product.Title = productVM.Title;
            product.Quantity = productVM.Quantity;

            db.Update(product);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var _Product = db.Products.Find(id);
            if (_Product == null)
            {
                return RedirectToAction("Index");
            }

            var isdeletedimage = _imageService.DeleteImage(_Product.ImagePath);
            //to be implemented logic to handle if image is not deleted
           
            db.Products.Remove(_Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
