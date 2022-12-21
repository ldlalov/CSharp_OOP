using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Rogue : BaseHero
    {
        public Rogue(string name, int power) : base(name, power)
        {
            Power = 80;
        }
        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }

}

