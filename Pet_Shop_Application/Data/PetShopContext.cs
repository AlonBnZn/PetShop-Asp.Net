using Microsoft.EntityFrameworkCore;
using Pet_Shop_Application.Models;

namespace Pet_Shop_Application.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
        {

        }


        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new Animal { AnimalId = 1, Age = 2, Name = "dog", Description = "A dog is a domestic mammal of the family Canidae and the order Carnivora. Its scientific name is Canis lupus familiaris. Dogs are a subspecies of the gray wolf, and they are also related to foxes and jackals. Dogs are one of the two most ubiquitous and most popular domestic animals in the world.", PictureName = "Mammal-Dog-bernese.jpg", CategoryId = 1 },
                new Animal { AnimalId = 2, Age = 4, Name = "cat", Description = "Like all felids, domestic cats are characterized by supple low-slung bodies, finely molded heads, long tails that aid in balance, and specialized teeth and claws that adapt them admirably to a life of active hunting.", PictureName = "Mammal-Cat.jpg", CategoryId = 1 },
                new Animal { AnimalId = 3, Age = 1, Name = "Koi", Description = "Koi fish are colorful, ornamental versions of the common carp. Modern Japanese koi are believed to date back to early 19th-century Japan where wild, colorful carp were caught, kept and bred by rice farmers. The word “koi” comes from the Japanese word for “carp.”\r\n", PictureName = "Fish-Koi.jpg", CategoryId = 4 },
                new Animal { AnimalId = 4, Age = 9, Name = "Eagle", Description = "Eagles are generally larger and more powerful than hawks and may resemble a vulture in build and flight characteristics, but they have a fully feathered (often crested) head and strong feet equipped with great curved talons. Most species subsist mainly on live prey, which they generally capture on the ground.\r\n", PictureName = "Bird-Eagle.jpg", CategoryId = 2 },
                new Animal { AnimalId = 5, Age = 20, Name = "Chameleon", Description = "Chameleons are well known to most people, easily recognizable by their body shape, independently moving eyes, paw-like hands and feet, and ability to change color rapidly. Most researchers identify two subfamilies of chameleons, containing 4-6 genera, and more than 150 species.\r\n", PictureName = "Reptil-Chameleon.jpg", CategoryId = 3 }

            );
            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, Name = "Mammal" },
                new { CategoryId = 2, Name = "Bird" },
                new { CategoryId = 3, Name = "Reptil" },
                new { CategoryId = 4, Name = "Aquatic" }
            );
            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, CommentText = "Cute!!!", AnimalId = 1 },
                new { CommentId = 2, CommentText = "Scary!!!", AnimalId = 4 },
                new { CommentId = 3, CommentText = "Funny!!!", AnimalId = 2 },
                new { CommentId = 4, CommentText = "Best Friend!!!", AnimalId = 1 },
                new { CommentId = 5, CommentText = "Big!!!", AnimalId = 4 }

           );
        }
    }
}
