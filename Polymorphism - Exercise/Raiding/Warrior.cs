using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Warrior : BaseHero
    {
        public Warrior(string name, int power) : base(name, power)
        {
            Power = 100;
        }
        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }

    }
}
