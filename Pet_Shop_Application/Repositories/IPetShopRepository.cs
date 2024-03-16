using Pet_Shop_Application.Models;

namespace Pet_Shop_Application.Services
{
    public interface IPetShopRepository
    {
        // Animal Methods
        public IEnumerable<Animal>? GetMostRatedAnimals();
        IEnumerable<Animal> GetAnimals();
        IEnumerable<Animal> GetAnimalsByCategoryid(int categoryid);
        void DeleteAnimal(int id);
        void UpdateAnimal(int id, Animal animal);
        void InsertAnimal(Animal animal);
        // Categories Methods
        IEnumerable<Category> GetCategories();
        // Comments Methods
        IEnumerable<Comment> GetComments();
        void InsertComment(Comment comment);
    }
}
