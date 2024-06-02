using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task18.Model;
using Task18.SaveModels;

namespace Task18.Repository
{
    public class Repository : IRepository
    {
        private ISaver _saver;
        private Dictionary<int, IAnimal> repo = [];
        public IAnimal this[int id]
        {
            get { return repo[id]; }
        }

        public Repository(ISaver saver)
        {
            _saver = saver;
            Initialize();
        }


        public void Initialize()
        {
            repo = [];
            var animals = _saver.LoadAll();
            animals
                .ForEach(animal => repo[animal.Id] = animal);
        }
        public List<IAnimal> GetAll()
        {
            return repo.Values
                .OrderBy(animal => animal.Id)
                .ToList();
        }
        public IAnimal Get(int animalId)
        {
            return this[animalId];
        }
        public void Add(IAnimal animal)
        {
            repo[animal.Id] = animal;
            _saver.Add(animal, repo.Values.ToList());
        }
        public void Update(IAnimal animal)
        {
            repo[animal.Id] = animal;
            _saver.Update(animal, repo.Values.ToList());
        }
        public void Delete(int animalId)
        {
            repo.Remove(animalId);
            _saver.Delete(animalId, repo.Values.ToList());
        }

        public void ClearAll()
        {
            repo = [];
            _saver.SaveAll(repo.Values.ToList());
        }
    }
}
