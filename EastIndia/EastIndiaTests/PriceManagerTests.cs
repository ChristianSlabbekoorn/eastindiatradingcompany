using Moq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EastIndia.Models;
using EastIndia.Helpers;
using EastIndia.Managers;
using EastIndia.Models.Dtos;

namespace EastIndiaTests
{
	[TestClass]
	public class PriceManagerTests
	{
		private readonly Mock<IDbHelper> mockDbHelper = new Mock<IDbHelper>();
		private readonly Guid _badId = Guid.Parse("0e61f17d-1914-45ff-bf60-546fc87e4474");
		private readonly Guid _goodId = Guid.Parse("edb2079c-1b45-4e9f-8dd3-462cf41a2912");
		private readonly decimal _updatedPricePerSegment = 21.37M;

		[TestMethod]
		[DataRow("0e61f17d-1914-45ff-bf60-546fc87e4474", false)]
		[DataRow("edb2079c-1b45-4e9f-8dd3-462cf41a2912", true)]
		public void ChangePrice(string priceIdString, bool expectedResult)
		{
			//Arrange
			SetUpMock();
			var manager = new PriceManager(mockDbHelper.Object);
			var price = new PriceUpdate
			{
				ID = Guid.Parse(priceIdString),
				Price = _updatedPricePerSegment
			};

			//Act
			var actualResult = manager.UpdatePrice(price);

			//Assert
			Assert.AreEqual(expectedResult, actualResult);
		}

		private void SetUpMock()
		{
			var price = new Price{ ID = _goodId };
			var updatedPrice = new Price
			{
				ID = _goodId,
				PricePerSegment = _updatedPricePerSegment
			};
			Price nullPrice = null;

			mockDbHelper.Setup(x => x.Get<Price>(_badId))
				.Returns(nullPrice);

			mockDbHelper.Setup(x => x.Get<Price>(_goodId))
				.Returns(price);

			mockDbHelper.Setup(x => x.Update(_goodId, price))
				.Returns(true);
		}
	}
}
