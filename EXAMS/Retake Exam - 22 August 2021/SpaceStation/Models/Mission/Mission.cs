using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (planet.Items.Count==0)
                {
                    break;
                }
            string[] items = planet.Items.ToArray();
                if (astronaut.Oxygen > 60)
                {
                    for (int i = 0; i < items.Length; i++)
                    {
                        astronaut.Bag.Items.Add(items[i]);
                        planet.Items.Remove(items[i]);
                        astronaut.Breath();
                        if (astronaut.Oxygen<=0)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
