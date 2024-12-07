using Assets.Scripts.Chest;
using UnityEngine;

namespace Assets.Scripts.Slot
{
	public class SlotController
	{
		private SlotView slotView;
		private RectTransform slotContainer;
		private SlotState slotState;
		private ChestController chestController;

		public SlotController(SlotView slotView, RectTransform slotContainer)
		{
			this.slotView = slotView;
			this.slotContainer = slotContainer;
			CreateSlot();
		}

		private void CreateSlot()
		{
            slotView = GameObject.Instantiate(slotView, slotContainer);
            slotView.SetController(this);
            SetSlotState(SlotState.EMPTY);
        }

		public Transform GetTransform => slotView.transform; 

		public void SetChestController(ChestController chestController)
		{
			this.chestController = chestController;
			SetSlotState(SlotState.FILLED);
		}

		public void SetSlotState(SlotState slotState) => this.slotState = slotState;

		public bool IsSlotEmpty() => slotState == SlotState.EMPTY;
		public void OnChestClick()
		{
		}
	}
}