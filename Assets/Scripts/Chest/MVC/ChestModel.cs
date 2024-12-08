using UnityEngine;

namespace Assets.Scripts.Chest
{
	public class ChestModel
	{
		private ChestScriptableObjectScript chestData;
		private string unlockTime;

		public ChestModel(ChestScriptableObjectScript chestData) 
		{
			this.chestData = chestData;
			UnlockTimeToStr();
		}

        private void UnlockTimeToStr()
        {
            int hours = Mathf.FloorToInt(chestData.unlockTimeInSec / 3600);
            int minutes = Mathf.FloorToInt((chestData.unlockTimeInSec % 3600) / 60);
            int seconds = Mathf.FloorToInt(chestData.unlockTimeInSec % 60);

            unlockTime = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }


        public string GetChestName => chestData.chestName;
		public Sprite GetLockedChestSprite => chestData.chestLockedImage;
		public Sprite GetOpenedChestSprite => chestData.chestOpenedImage;
        public ChestType GetChestType => chestData.chestType;
        public float GetUnlockTime => chestData.unlockTimeInSec;
        public string GetUnlockTimeString => unlockTime;
		public int GetMinCoin=> chestData.minCoins;
		public int GetMaxCoin => chestData.maxCoins;
		public int GetMinGem => chestData.minGems;
		public int GetMaxGem => chestData.maxGems;
	}
}