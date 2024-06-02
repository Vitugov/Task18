using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18.Model
{
    public class Amphibian : AbstractAnimal
    {
        public Amphibian() : base("Amphibian") { }
        public override IAnimal GetNew() => new Amphibian();
    }
}
