using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private double currentBill = 0;
        private double turnover = 0;
        private DelicacyRepository delicacyMenu;
        private CocktailRepository cocktailMenu;
        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            this.delicacyMenu = new DelicacyRepository();
            this.cocktailMenu = new CocktailRepository();
        }
        public int BoothId {
            get { return boothId; }
            private set
            {
                boothId = value;
            }
                
                }

        public int Capacity 
        {
            get
            { return capacity; }
                
              private  set
            {
                if (value<=0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityLessThanOne));
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => delicacyMenu;

        public IRepository<ICocktail> CocktailMenu => cocktailMenu;

        public double CurrentBill
        {
            get { return currentBill; }
            private set
            {
                UpdateCurrentBill(value);
            }
        }

        public double Turnover
        {
            get { return turnover; }
            private set
            {
                turnover += currentBill;
            }
        }

        public bool IsReserved { get; private set; }

        public void ChangeStatus()
        {
            if (IsReserved)
            {
                IsReserved = false;
            }
            IsReserved = true;
        }

        public void Charge()
        {
            turnover += currentBill;
            currentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            currentBill += amount;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {boothId}");
            sb.AppendLine($"Capacity: {capacity}");
            sb.AppendLine($"Turnover: {turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");
            foreach (var cocktail in cocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail.ToString()}");
            }
            sb.AppendLine($"-Delicacy menu:");
            foreach (var delicacy in delicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy.ToString()}");
            }
            return sb.ToString().Trim();

        }
    }
}
