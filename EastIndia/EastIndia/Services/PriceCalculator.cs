using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EastIndia.Models.Dtos;

namespace EastIndia.Services
{
    public class PriceCalculator
    {
        public int CalculatePrice(int numberOfHops, Package package)
        {
            var basePrice = GetPriceBasedOnSeasonAndWeight(package.Date);
            var sumOfExtraPercentages = GetSumOfExtraPercentages(package);
            var fullPrice = basePrice * (1 + sumOfExtraPercentages);
            return fullPrice * numberOfHops;
        }

        public int GetSumOfExtraPercentages(Package package)
        {
            var sumOfExtraPercentages = 0;
            if (package.IsWeapons) { sumOfExtraPercentages += 20; }
            if (package.IsAnimals) { sumOfExtraPercentages += 25; }
            if (package.IsRefrigerated) { sumOfExtraPercentages += 10; }

            return sumOfExtraPercentages;
        }

        public int GetPriceBasedOnSeasonAndWeight(DateTime date)
        {
            var isNovemberAprilSeason = (date.Day >= 1 && date.Month >= 11) && (date.Day <= 31 && date.Month <= 4);
            return isNovemberAprilSeason ? 8 : 5;
        }
    }
}