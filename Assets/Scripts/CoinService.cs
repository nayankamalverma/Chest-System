using Unity.VisualScripting;

namespace Assets.Scripts
{
	public class CoinService
	{
		int coins = 0;
		public CoinService() 
		{ 
				
		}

		public void  SetCoin(int coins) =>this.coins += coins;
		public int GetCoin() => coins;
	}
}