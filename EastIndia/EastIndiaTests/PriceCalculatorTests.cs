using EastIndia.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EastIndia.Models.Dtos;

namespace EastIndiaTests
{
    [TestClass]
    public class PriceCalculatorTests
    {
        private readonly PriceCalculator _priceCalculator = new PriceCalculator();
        
        [TestMethod]
        public void GetSumOfExtraPercentages_WeaponsAndAnimals_ReturnsSumOfExtraPercentages()
        {
            var package = new Package
            {
                IsWeapons = true,
                IsAnimals = true
            };

            var sumOfPercentages = _priceCalculator.GetSumOfExtraPercentages(package);
            
            Assert.AreEqual(sumOfPercentages, 45);
        }

        [TestMethod]
        public void GetSumOfExtraPercentages_NoSpecialConditions_ReturnsZero()
        {
            var package = new Package { };

            var sumOfPercentages = _priceCalculator.GetSumOfExtraPercentages(package);

            Assert.AreEqual(sumOfPercentages, 0);
        }

        //[DataTestMethod]
        //[DataRow("2021-10-31", 5)]
        //[DataRow("2021-11-1", 8)]
        //[DataRow("2021-4-30", 8)]
        //[DataRow("2021-4-30", 8)]
        //public void GetPriceBasedOnSeasonAndWeight_VariousDates_ReturnsCorrectPrice(string date, int expectedPrice)
        //{
        //    var datetime = DateTime.Parse(date);
        //    var price = _priceCalculator.GetPriceBasedOnSeasonAndWeight(datetime);

        //    Assert.AreEqual(price, expectedPrice);
        //}
    }
}
