namespace Assets.Scripts
{
	public class GemService
	{
		private int gems;
		public GemService() 
		{
			gems = 100;
		}

		public int GetGems() => gems;
		public void SetGems(int gems) => this.gems += gems;
		public void DeductGems(int gems)=> this.gems -= gems;

		public bool GemsAvailable(int gems)
		{
			return this.gems >= gems;
		}
	}
}