using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Serialization;

namespace Task18.Model
{
    [XmlInclude(typeof(Amphibian))]
    [XmlInclude(typeof(Bird))]
    [XmlInclude(typeof(Mammal))]
    [XmlInclude(typeof(UserTypeAnimal))]
    public abstract class AbstractAnimal : IAnimal
    {
        private static int maxId = 0;
        public int Id { get; set; }
        public string AnimalType { get; set; }
        public string AnimalName { get; set; }
        public string Overview { get; set; }

        public AbstractAnimal(string animalType)
        {
            Id = ++maxId;
            AnimalType = animalType;
        }
        public void SetMaxId(int newValue)
        { 
            maxId = newValue;
        }

        public abstract IAnimal GetNew();

        public object Clone()
        {
            var copy = this.GetNew();
            var properties = this.GetType().GetProperties().ToList();
            properties.ForEach(p => p.SetValue(copy, p.GetValue(this)));
            return copy;
        }
    }
}
