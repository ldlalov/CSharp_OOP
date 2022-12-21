using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository boots;
        public Controller()
        {
            boots = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int id = boots.Models.Count + 1;
            IBooth booth = new Booth(id, capacity);
            boots.AddModel(booth);
            return String.Format(OutputMessages.NewBoothAdded,id,capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            Booth booth = (Booth)boots.Models.FirstOrDefault(x => x.BoothId == boothId);
            if (cocktailTypeName != "Hibernation" && cocktailTypeName != "MulledWine")
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            if (size != "Small" && size != "Middle" & size != "Large")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }
            if (booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == cocktailName && x.Size == size) != null)
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }
            ICocktail cocktail;
            if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            booth.CocktailMenu.AddModel(cocktail);
            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            Booth booth = (Booth)boots.Models.FirstOrDefault(x => x.BoothId == boothId);
            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            if (booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == delicacyName) != null)
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            IDelicacy delicacy;
            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }
            booth.DelicacyMenu.AddModel(delicacy);
            return String.Format(OutputMessages.NewDelicacyAdded,delicacyTypeName, delicacyName);

        }

        public string BoothReport(int boothId)
        {
            return boots.Models.FirstOrDefault(b => b.BoothId == boothId).ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = boots.Models.FirstOrDefault(b => b.BoothId == boothId);
            double bill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {bill:f2} lv");
            sb.Append($"Booth {boothId} is now available!");
            return sb.ToString();
        }

        public string ReserveBooth(int countOfPeople)
        {
            int id = 0;
            foreach (var booth in boots.Models.OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId))
            {
                if (!booth.IsReserved && booth.Capacity>= countOfPeople)
                {
                    booth.ChangeStatus();
                    id = booth.BoothId;
                    return String.Format(OutputMessages.BoothReservedSuccessfully, id, countOfPeople);
                }
            }
            return String.Format(OutputMessages.NoAvailableBooth,countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = boots.Models.FirstOrDefault(b => b.BoothId == boothId);
            string[] buy = order.Split("/");
            string type = buy[0];
            string name = buy[1];
            int qty = int.Parse(buy[2]);
            if (type != "MulledWine" && type != "Hibernation" && type != "Gingerbread" && type != "Stolen")
            {
                return String.Format(OutputMessages.NotRecognizedType, type);
            }
            if (booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == name) == null && booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == name) == null)
            {
                return String.Format(OutputMessages.NotRecognizedItemName, type, name);
            }
            if (type== "MulledWine" || type == "Hibernation")
            {
                string size = buy[3];
                if (booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == name && x.Size == size) == null)
                {
                    return String.Format(OutputMessages.CocktailStillNotAdded, size,name);
                } 
            }
            double price = 0;
            if (type == "Gingerbread")
            {
                IDelicacy good = new Gingerbread(name);
                price = good.Price;
            }
            else if (type == "Stolen")
            {
                IDelicacy good = new Stolen(name);
                price = good.Price;

            }
            else if (type == "MulledWine")
            {
                string size = buy[3];
                ICocktail good = new MulledWine(name, size);
                price = good.Price;
            }
            else
            {
                string size = buy[3];
                ICocktail good = new MulledWine(name, size);
                price = good.Price;
            }
            double sum = qty * price;
            boots.Models.FirstOrDefault(x => x.BoothId == boothId).UpdateCurrentBill(sum);
            return String.Format(OutputMessages.SuccessfullyOrdered,boothId,qty,name);
        }
    }
}
