using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18.Model
{
    public class UserTypeAnimal : AbstractAnimal
    {
        public UserTypeAnimal(string userType) : base(userType) { }

        public UserTypeAnimal() : base("") { }
        public override IAnimal GetNew() => new UserTypeAnimal("");
    }
}
