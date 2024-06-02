using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18.Model
{
    public class Bird : AbstractAnimal
    {
        public Bird() : base("Bird") { }
        public override IAnimal GetNew() => new Bird();
    }
}
