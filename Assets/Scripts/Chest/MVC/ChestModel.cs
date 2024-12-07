namespace Assets.Scripts.Chest
{
	public class ChestModel
	{
		private ChestScriptableObjectScript chestData;

		public ChestModel(ChestScriptableObjectScript chestData) 
		{
			this.chestData = chestData;
		}

        public string GetChestName => chestData.chestName;
        public ChestType GetChestType => chestData.chestType;
        public float GetUnlockTime => chestData.unlockTimeInSec;
		public int GetMinCoin=> chestData.minCoins;
		public int GetMaxCoin => chestData.maxCoins;
		public int GetMinGem => chestData.minGems;
		public int GetMaxGem => chestData.maxGems;
	}
}