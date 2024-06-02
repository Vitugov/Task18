using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task18.Model;

namespace Task18.Repository
{
    public class Initialization
    {
        public void Init(IRepository repository)
        {
            var animalFactory = new AnimalFactory();
            
            var sparrow = animalFactory.CreateAnimal("Bird");
            sparrow.AnimalName = "Sparrow";
            sparrow.Overview = "Little bird";

            var frog = animalFactory.CreateAnimal("Amphibian");
            frog.AnimalName = "Frog";
            frog.Overview = "Queen of the swamps";

            var cow = animalFactory.CreateAnimal("Mammal");
            cow.AnimalName = "Cow";
            cow.Overview = "The one that gives milk";

            var crocodile = animalFactory.CreateAnimal("Reptile");
            crocodile.AnimalName = "Crocodile";
            crocodile.Overview = "The most dangerous large predators for humans";

            repository.ClearAll();
            repository.Add(sparrow);
            repository.Add(frog);
            repository.Add(cow);
            repository.Add(crocodile);
        }
    }
}
