using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int damage = 25;
        public Mace(string name, int durability) : base(name, durability)
        {
            Damage = damage;
        }
    }
}
