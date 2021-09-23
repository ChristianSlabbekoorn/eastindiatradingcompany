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

        [DataTestMethod]
        [DataRow("2021-10-31", 5)]
        [DataRow("2021-11-1", 8)]
        [DataRow("2021-2-15", 8)]
        [DataRow("2021-4-30", 8)]
        [DataRow("2021-5-1", 5)]
        [DataRow("2021-8-25", 5)]
        public void GetPriceBasedOnSeasonAndWeight_VariousDates_ReturnsCorrectPrice(string date, int expectedPrice)
        {
            var datetime = DateTime.Parse(date);
            var price = _priceCalculator.GetPriceBasedOnSeasonAndWeight(datetime);

            Assert.AreEqual(price, expectedPrice);
        }

        [TestMethod]
        public void CalculatePrice_ExtraPercentage_CorrectPriceReturned()
        {
            var datetime = DateTime.Parse("2021-5-31");
            var price = _priceCalculator.CalculatePrice(10, new Package
            {
                IsRefrigerated = true,
                Date = datetime
            });
            
            Assert.AreEqual(55, price);
        }

        [TestMethod]
        public void CalculatePrice_NoExtraPercentagPriceReturned()
        {
            var datetime = DateTime.Parse("2021-5-5");
            var price = _priceCalculator.CalculatePrice(10, new Package
            {
                IsRefrigerated = false,
                Date = datetime
            });

            Assert.AreEqual(50, price);
        }
    }
}
