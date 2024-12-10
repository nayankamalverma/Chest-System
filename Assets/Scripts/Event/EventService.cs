using Assets.Scripts.Chest;

namespace Assets.Scripts.Event
{
	public class EventService
	{
		public EventController OnGetChest;
		public EventController<ChestController> OnChestClick;
		public EventController OnUnlockButtonClick;
		public EventController OnQuickUnlockButtonClick;
		public EventController<int, int> OnGenerateRewards;

        public EventService()
		{
			OnGetChest = new EventController();	
			OnChestClick = new EventController<ChestController>();
			OnUnlockButtonClick = new EventController();
			OnQuickUnlockButtonClick = new EventController();
		}
	}
}