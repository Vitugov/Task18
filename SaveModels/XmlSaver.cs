using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Task18.Model;

namespace Task18.SaveModels
{
    internal class XmlSaver : ISaver
    {
        private readonly string _filePath = "animals.xml";

        public XmlSaver()
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
            XmlSerializer serializer = new XmlSerializer(typeof(List<AbstractAnimal>));
            using (FileStream fs = new FileStream(_filePath, FileMode.Open))
            {
                try
                {
                    return ((List<AbstractAnimal>)serializer.Deserialize(fs))
                        .Cast<IAnimal>()
                        .ToList();
                }
                catch
                {
                    return new List<IAnimal>();
                }
            }
        }

        public void SaveAll(List<IAnimal> animalList)
        {
            var collection = animalList.Cast<AbstractAnimal>().ToList();
            XmlSerializer serializer = new XmlSerializer(typeof(List<AbstractAnimal>));

            using (FileStream fs = new FileStream(_filePath, FileMode.Create))
            {
                serializer.Serialize(fs, collection);
            }
        }
    }
}
