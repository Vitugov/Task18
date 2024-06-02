using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18.Model
{
    public interface IAnimal : ICloneable
    {
        public int Id { get; set; }
        public string AnimalType { get; set; }
        public string AnimalName { get; set; }
        public string Overview {  get; set; }
        public IAnimal GetNew();
    }
}
