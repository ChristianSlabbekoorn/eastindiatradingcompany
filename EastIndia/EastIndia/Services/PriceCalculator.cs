using System;
using EastIndia.Models.Dtos;

namespace EastIndia.Services
{
    public class PriceCalculator
    {
        private const int IsWeaponsExtraPercentage = 20;
        private const int IsAnimalExtraPercentage = 25;
        private const int IsRefrigeratedExtraPercentage = 10;
        private const int NovemberToAprilSeasonPrice = 8;
        private const int MayToOctoberSeasonPrice = 5;

        public double CalculatePrice(int numberOfHops, Package package)
        {
            var basePrice = GetPriceBasedOnSeasonAndWeight(package.Date);
            var sumOfExtraPercentages = GetSumOfExtraPercentages(package);
            var fullPrice = basePrice * (1 + (double) sumOfExtraPercentages/100);
            return fullPrice * numberOfHops;
        }

        public int GetSumOfExtraPercentages(Package package)
        {
            var sumOfExtraPercentages = 0;
            if (package.IsWeapons) { sumOfExtraPercentages += IsWeaponsExtraPercentage; }
            if (package.IsAnimals) { sumOfExtraPercentages += IsAnimalExtraPercentage; }
            if (package.IsRefrigerated) { sumOfExtraPercentages += IsRefrigeratedExtraPercentage; }

            return sumOfExtraPercentages;
        }

        public int GetPriceBasedOnSeasonAndWeight(DateTime date)
        {
            var isNovemberAprilSeason = (date.Day >= 1 && date.Month >= 11) 
                                        || (date.Day <= 31 && date.Month <= 4);
            return isNovemberAprilSeason ? NovemberToAprilSeasonPrice : MayToOctoberSeasonPrice;
        }
    }
}