using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18.Model
{
    internal class AnimalFactory
    {
        private List<IAnimal> registeredAnimalsTypes = [];

        public AnimalFactory()
        {
            RegisterType(new Amphibian());
            RegisterType(new Bird());
            RegisterType(new Mammal());
        }

        private void RegisterType(IAnimal animal) => registeredAnimalsTypes.Add(animal);

        public IAnimal CreateAnimal(string animalType)
        {
            var animal = registeredAnimalsTypes
                .Where(animal => animal.AnimalType == animalType)
                .FirstOrDefault();
            return animal != null ? animal.GetNew() : new UserTypeAnimal(animalType);
        }

        public List<string> GetTypes()
        {
            return registeredAnimalsTypes
                .Select(t => t.AnimalType)
                .ToList();
        }
    }
}
