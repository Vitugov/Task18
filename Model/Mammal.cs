using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18.Model
{
    public class Mammal : AbstractAnimal
    {
        public Mammal() : base("Mammal") { }
        public override IAnimal GetNew() => new Mammal();
    }
}
