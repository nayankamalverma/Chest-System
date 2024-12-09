using Assets.Scripts.Chest;
using Assets.Scripts.Event;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Slot
{
	public class SlotService
	{
		[SerializeField] List<SlotController> slotControllerList;

		int noOfSlots;
		SlotView slotView;
		RectTransform slotContainer;
		EventService eventService;
		public bool isUnlocking;

		public SlotService(int slotCount, SlotView slotView, RectTransform slotContainer,EventService eventService)
		{
			noOfSlots = slotCount;
			this.slotView = slotView;
			this.slotContainer = slotContainer;
			this.eventService = eventService;
			slotControllerList = new List<SlotController>();
			CreateSlot();
			isUnlocking = false;
		}

		private void CreateSlot()
		{
			float height = (((noOfSlots / 4) + (noOfSlots % 4 != 0 ? 1 : 0)) * 410);
			slotContainer.sizeDelta = new Vector2(slotContainer.sizeDelta.x, height);

			for (int i = 0; i < noOfSlots; i++)
			{
				slotControllerList.Add(new SlotController(slotView, slotContainer,eventService));
			}
		}

		public void SetChest(ChestController chestController)
		{
			SlotController slot = GetEmptySlot();
			slot.SetChestController(chestController);
		}

		public SlotController GetEmptySlot() { 
			foreach(var slot in slotControllerList)
			{
				if(slot.IsSlotEmpty())return slot;
				
			}
			return null;
		}
	}
}