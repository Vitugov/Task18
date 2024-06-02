using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task18.Model;

namespace Task18.SaveModels
{
    public class JsonSaver : ISaver
    {
        private readonly string _filePath = "animals.json";
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };
        public JsonSaver()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Dispose();
            }
        }
        public void Add(IAnimal animal, List<IAnimal> animalList) => SaveAll(animalList);

        public void Delete(int animalId, List<IAnimal> animalList) => SaveAll(animalList);
        
        public void Update(IAnimal animal, List<IAnimal> animalList) => SaveAll(animalList);

        public List<IAnimal> LoadAll()
        {
            string json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<IAnimal>>(json, _settings) ?? new List<IAnimal>();
        }

        public void SaveAll(List<IAnimal> animalList)
        {
            string json = JsonConvert.SerializeObject(animalList, Formatting.Indented, _settings);
            File.WriteAllText(_filePath, json);
        }
    }
}
