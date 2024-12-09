using Assets.Scripts.ChestStateMachine;
using Assets.Scripts.Event;
using Assets.Scripts.ScriptableObject;
using Assets.Scripts.Slot;
using UnityEngine;

namespace Assets.Scripts.Chest
{
	public class ChestService
	{
		private EventService eventService;
		private ChestSo chestSOList;
		private SlotService slotService;
		private UIService uiService;
		private ChestView chestPrefab;

		private ChestController currentChestController;


		public float commonProbability=100;
		public float rareProbability=50;
		public float epicProbability=30;
		public float legendaryProbability= 10;

		public ChestService(ChestView chetPrefab,ChestSo chestSOList, EventService eventService,SlotService slotService, UIService uIService)
		{
			this.chestPrefab = chetPrefab;
			this.chestSOList = chestSOList;
			this.eventService = eventService;
			this.slotService = slotService;
			this.uiService = uIService;
			AddEventListeners();
		}

		~ChestService()
		{
			RemoveEventListeners();
		}

		private void AddEventListeners()
		{
			eventService.OnGetChest.AddListener(GenerateChest);
			eventService.OnChestClick.AddListener(OnChestClick);
			eventService.OnUnlockButtonClick.AddListener(UnlockChest);
			eventService.OnQuickUnlockButtonClick.AddListener(QuickUnlockChest);
		}
		private void RemoveEventListeners()
		{
			eventService.OnGetChest.RemoveListener(GenerateChest);
		}

		private void GenerateChest()
		{
			ChestScriptableObjectScript chestData = GetRandomChest();
			SlotController slot = slotService.GetEmptySlot();
			if(slot!=null){
				ChestController chestController = new ChestController(chestPrefab,GetRandomChest(), slot.GetTransform,eventService,slot);
				slot.SetChestController(chestController);
			}
			else
			{
				uiService.ShowNotification("Slots full!!!!");
			}
		}

		private ChestScriptableObjectScript GetRandomChest()
		{
			float randomValue = 100 * Random.value;
			ChestType chestType;
			if (randomValue <= legendaryProbability) chestType = ChestType.Legendary;
			else if (randomValue <= epicProbability) chestType = ChestType.Epic;
			else if(randomValue <= rareProbability ) chestType = ChestType.Rare;
			else chestType = ChestType.Common;
			return FindChestSo(chestType);
		}

		private ChestScriptableObjectScript FindChestSo(ChestType chestType) { 
			return chestSOList.ChestSOList.Find(chest=>chest.chestType == chestType);
		}

		private void OnChestClick(ChestController chestController)
		{
            if (chestController == null) { return; }
			currentChestController = chestController;
			switch(chestController.GetChestCurrentState())
			{
				case State.Locked:
					uiService.ShowChestDetail(chestController,slotService.isUnlocking);
					break;

				case State.Unlocking:
                    uiService.ShowChestDetail(chestController, slotService.isUnlocking);
					break;
				case State.Unlocked:
					GenerateChestReward(currentChestController);
					break ;
				 default :

					break;
            }
        }

		private void UnlockChest()
		{
			currentChestController.ChangeChestState(State.Unlocking);
			slotService.isUnlocking = true;
		}
		private void QuickUnlockChest()
		{

			slotService.isUnlocking = true;
		}

        private void GenerateChestReward(ChestController controller)
        {
            throw new System.NotImplementedException();
        }
    }
}