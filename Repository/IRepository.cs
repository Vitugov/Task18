using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task18.Model;
using Task18.SaveModels;

namespace Task18.Repository
{
    public interface IRepository
    {
        public void Initialize();

        public List<IAnimal> GetAll();

        public IAnimal Get(int animalId);

        public void Add(IAnimal animal);

        public void Update(IAnimal animal);

        public void Delete(int animalId);

        public void ClearAll();

    }
}
