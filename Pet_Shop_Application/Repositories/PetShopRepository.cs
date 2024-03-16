using Pet_Shop_Application.Data;
using Pet_Shop_Application.Models;

namespace Pet_Shop_Application.Services
{
    public class PetShopRepository : IPetShopRepository
    {
        private PetShopContext _context;

        public PetShopRepository(PetShopContext context)
        {
            _context = context;
        }
        public IEnumerable<Animal>? GetMostRatedAnimals()
        {
            if (_context.Comments.Count() > 0)
            {
                var orderedAnimal = _context.Animals.OrderByDescending(a => a.Comments!.Count).Take(2);

                return orderedAnimal;
            }
            return null;
        }
        public void DeleteAnimal(int id)
        {
            var removeAnimal = _context.Animals!.Where((a) => a.AnimalId == id).Single();
            if (removeAnimal == null)
            {
                throw new ArgumentNullException("Id not Found");
            }
            removeAnimal.Comments!.ToList().ForEach((c) => { removeAnimal.Comments!.Remove(c); });
            _context.Animals!.Remove(removeAnimal);
            _context.SaveChanges();
        }
        public IEnumerable<Animal> GetAnimals()
        {
            return _context.Animals!;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories!;
        }
        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments!;
        }

        public void InsertAnimal(Animal animal)
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();

        }
        public void InsertComment(Comment comment)
        {
            _context.Comments!.Add(comment);
            _context.SaveChanges();

        }
        public void UpdateAnimal(int id, Animal animal)
        {
            Animal UpdateAnimal = _context.Animals!.Where(a => a.AnimalId == id).FirstOrDefault()!;
            UpdateAnimal!.Age = animal.Age;
            UpdateAnimal.Name = animal.Name;
            UpdateAnimal.Description = animal.Description;
            UpdateAnimal.CategoryId = animal.CategoryId;
            if (animal.PictureName != null)
            {
                UpdateAnimal.PictureName = animal.PictureName;

            }
            _context.SaveChanges();
        }
        public IEnumerable<Animal> GetAnimalsByCategoryid(int categoryid)
        {
            IEnumerable<Animal>? Animals = _context.Animals;
            if (categoryid != 0)
            {
                Category currectCategory = _context.Categories.Where(c => c.CategoryId == categoryid).Single();
                Animals = Animals.Where((a) => a.CategoryId == currectCategory.CategoryId);
            }
            return Animals;
        }
    }
}
