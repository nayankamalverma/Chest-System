using UnityEngine;

namespace Assets.Scripts.Chest
{
	public class ChestModel
	{
		private ChestScriptableObjectScript chestData;
		private string unlockTime;
		private float unlockTimeSec;

		public ChestModel(ChestScriptableObjectScript chestData) 
		{
			this.chestData = chestData;
			unlockTimeSec = chestData.unlockTimeInSec;
			UnlockTimeToStr();
		}

        private void UnlockTimeToStr()
        {
            int hours = Mathf.FloorToInt(unlockTimeSec/ 3600);
            int minutes = Mathf.FloorToInt((unlockTimeSec % 3600) / 60);
            int seconds = Mathf.FloorToInt(unlockTimeSec % 60);

            unlockTime = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }


        public string GetChestName => chestData.chestName;
		public Sprite GetLockedChestSprite => chestData.chestLockedImage;
		public Sprite GetOpenedChestSprite => chestData.chestOpenedImage;
        public ChestType GetChestType => chestData.chestType;
        public float GetUnlockTime => unlockTimeSec;
		public void SetUnlockTime(float time)
		{
			unlockTimeSec = time;
			UnlockTimeToStr();
		}
        public string GetUnlockTimeString => unlockTime;
		public int GetMinCoin=> chestData.minCoins;
		public int GetMaxCoin => chestData.maxCoins;
		public int GetMinGem => chestData.minGems;
		public int GetMaxGem => chestData.maxGems;
	}
}