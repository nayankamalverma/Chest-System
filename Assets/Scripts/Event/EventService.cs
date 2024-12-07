namespace Assets.Scripts.Event
{
	public class EventService
	{
		public EventController OnGetChest;

		public EventService()
		{
			OnGetChest = new EventController();	
		}
	}
}