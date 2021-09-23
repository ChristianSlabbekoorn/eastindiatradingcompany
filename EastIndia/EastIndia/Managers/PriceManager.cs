using EastIndia.Helpers;
using EastIndia.Models;
using EastIndia.Models.Dtos;

namespace EastIndia.Managers
{
	public class PriceManager
	{
		public static bool UpdatePrice(PriceUpdate priceUpdate)
		{
			var price = DbHelper.Get<Price>(priceUpdate.ID);
			if (price is null) return false;

			price.PricePerSegment = priceUpdate.Price;
			return DbHelper.Update(price.ID, price);
		}
	}
}