using Assets.Scripts.Chest;

namespace Assets.Scripts.Event
{
	public class EventService
	{
		public EventController OnGetChest;
		public EventController<ChestController> OnChestClick;

		public EventService()
		{
			OnGetChest = new EventController();	
			OnChestClick = new EventController<ChestController>();
		}
	}
}