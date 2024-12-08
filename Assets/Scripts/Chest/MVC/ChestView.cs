using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Chest
{
	public class ChestView : MonoBehaviour
	{
		[SerializeField] private Image chestImage;
		[SerializeField] private TextMeshProUGUI chestName;
		[SerializeField] private TextMeshProUGUI chestStatus;
		[SerializeField] private TextMeshProUGUI timerText;

		private ChestController chestController;
        private float totalTimeInSeconds;

        

        private void Update()
        {
        }

        public void SetController(ChestController chestController)
		{
			this.chestController = chestController;
            totalTimeInSeconds = chestController.GetChestModel.GetUnlockTime;
            SetTimeToUnlock();
            SetChestImage(chestController.GetChestModel.GetLockedChestSprite);
            SetChestName(chestController.GetChestModel.GetChestName);
            SetChestStatus(chestController.GetChestCurrentState.ToString());
		}

        public void SetChestImage(Sprite chestSprite) => this.chestImage.sprite = chestSprite;
        public void SetChestName(string chestName) => this.chestName.text = chestName;
        public void SetChestStatus(string status) => chestStatus.text = status;

        public void SetTimeToUnlock()
        {
            timerText.text = chestController.GetChestModel.GetUnlockTimeString;
        }
        public void SetTimeToUnlock(float timeInSeconds)
        {
            int hours = Mathf.FloorToInt(timeInSeconds / 3600);
            int minutes = Mathf.FloorToInt((timeInSeconds % 3600) / 60);
            int seconds = Mathf.FloorToInt(timeInSeconds % 60);

            timerText.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }
    }
}