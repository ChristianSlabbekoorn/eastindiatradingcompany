using EastIndia.Helpers;
using EastIndia.Models;
using EastIndia.Models.Dtos;

namespace EastIndia.Managers
{
	public class PriceManager
	{
		private readonly IDbHelper _dbHelper;
		
		public PriceManager(IDbHelper dbHelper)
		{
			_dbHelper = dbHelper;
		}

		public bool UpdatePrice(PriceUpdate priceUpdate)
		{
			var price = _dbHelper.Get<Price>(priceUpdate.ID);
			if (price is null) return false;

			price.PricePerSegment = priceUpdate.Price;
			return _dbHelper.Update(price.ID, price);
		}
	}
}