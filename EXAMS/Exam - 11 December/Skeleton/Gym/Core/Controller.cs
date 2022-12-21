using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAthleteType));
            }
            string type = gyms.FirstOrDefault(g => g.Name == gymName).GetType().Name;
            IAthlete athlete;
            if (athleteType == "Boxer" && type == "BoxingGym")
            {
                athlete = new Boxer(athleteName,motivation,numberOfMedals);
                gyms.FirstOrDefault(g => g.Name == gymName).AddAthlete(athlete);
                return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);

            }
            else if (athleteType == "Weightlifter" && type == "WeightliftingGym")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                gyms.FirstOrDefault(g => g.Name == gymName).AddAthlete(athlete);
                return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            else
            {
                return String.Format(OutputMessages.InappropriateGym);
            }
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidEquipmentType));
            }
            IEquipment equip;
            if (equipmentType == "BoxingGloves")
            {
                equip = new BoxingGloves();
            }
            else
            {
                equip = new Kettlebell();
            }
            equipment.Add(equip);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidGymType));
            }
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }
            gyms.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            return $"The total weight of the equipment in the gym {gym.Name} is {gym.EquipmentWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            if (equipment.FindByType(equipmentType) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            gyms.FirstOrDefault(g => g.Name == gymName).AddEquipment(equipment.FindByType(equipmentType));
            equipment.Remove(equipment.FindByType(equipmentType));
            return String.Format(OutputMessages.EntityAddedToGym, equipmentType,gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            return $"Exercise athletes: {gyms.FirstOrDefault(g => g.Name == gymName).Athletes.Count}.";
        }
    }
}
