using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task18.Model;

namespace Task18.SaveModels
{
    public interface ISaver
    {
        void SaveAll(List<IAnimal> animalList);
        List<IAnimal> LoadAll();
        void Add(IAnimal animal, List<IAnimal> animalList);
        void Update(IAnimal animal, List<IAnimal> animalList);
        void Delete(int animalId, List<IAnimal> animalList);
    }
}
