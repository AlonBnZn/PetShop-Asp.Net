using Microsoft.AspNetCore.Mvc;
using Pet_Shop_Application.Models;
using Pet_Shop_Application.Services;

namespace Pet_Shop_Application.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment _webHostEnvironment;
        private IPetShopRepository _repository;
        public HomeController(IPetShopRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var MostRated = _repository.GetMostRatedAnimals();

            if (MostRated != null)
            {
                ViewBag.MostRated = MostRated;
            }
            else
            {
                ViewBag.MostRated = null;
            }
            ViewBag.IsAdmin = true;
            return View();
        }
        public IActionResult Catalog(int categoryid)
        {
            ViewBag.Animals = _repository.GetAnimalsByCategoryid(categoryid);
            ViewBag.Category = "All";
            if (categoryid != 0)
            {
                ViewBag.Category = _repository.GetCategories().Where(c => c.CategoryId == categoryid).FirstOrDefault()!.Name;
            }
            return View(_repository);
        }

        public IActionResult AnimalPage(int id)
        {
            var animal = _repository.GetAnimals().Where(a => a.AnimalId == id).FirstOrDefault();
            if (animal == null)
            {
                throw new ArgumentNullException("Animal Not Found!");
            }
            ViewBag.Animal = animal;
            return View();
        }
        [HttpPost]
        public IActionResult NewComment(int id, string text)
        {
            if (ModelState.IsValid)
                _repository.InsertComment(new Comment { AnimalId = id, CommentText = text });
            return RedirectToAction("AnimalPage", new { id });
        }
        public IActionResult AdminPage(int categoryid)
        {
            var Animals = _repository.GetAnimalsByCategoryid(categoryid);
            ViewBag.Animal = Animals;
            ViewBag.Category = _repository.GetCategories().Where(c => c.CategoryId == categoryid).FirstOrDefault();

            return View(_repository);
        }
        public IActionResult Error()
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        public IActionResult AddNewAnimalPage()
        {
            ViewBag.Categories = _repository.GetCategories();
            return View();
        }
        public IActionResult AddAnimal(Animal newAnimal, IFormFile Photo)
        {
            newAnimal = AddNewPhoto(newAnimal, Photo);
            _repository.InsertAnimal(newAnimal);
            return RedirectToAction(/*nameof(AnimalPage)*/ "AnimalPage", new { id = newAnimal.AnimalId });

        }
        public IActionResult DeleteAnimal(int id = 0)
        {
            _repository.DeleteAnimal(id);
            return RedirectToAction("AdminPage");
        }
        public IActionResult EditAnimalPage(int id)
        {
            ViewBag.Categories = _repository.GetCategories();
            Animal Animal = _repository.GetAnimals().Where(a => a.AnimalId == id).FirstOrDefault()!;
            return View(Animal);
        }
        public IActionResult UpdateAnimal(Animal newAnimal, IFormFile Photo)
        {
            if (Photo != null)
            {
                newAnimal = AddNewPhoto(newAnimal, Photo);
            }
            _repository.UpdateAnimal(newAnimal.AnimalId, newAnimal);
            return RedirectToAction("AnimalPage", new { id = newAnimal.AnimalId });
        }


        private Animal AddNewPhoto(Animal newAnimal, IFormFile Photo)
        {
            var FileName = Guid.NewGuid().ToString() + Photo.FileName;
            var FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "Animals", FileName);
            using (var fileStream = new FileStream(FilePath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            newAnimal.PictureName = FileName;
            return newAnimal;
        }
    }
}
