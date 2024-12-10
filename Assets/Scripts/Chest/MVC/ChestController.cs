using Assets.Scripts.Event;
using Assets.Scripts.Slot;
using Assets.Scripts.ChestStateMachine;
using UnityEngine;

namespace Assets.Scripts.Chest
{
    public class ChestController
    {
        public ChestView chestView { get; private set; }
        public ChestModel chestModel { get; private set;  }
        private EventService eventService;
        private SlotController slot;
        private ChestStateMachine.ChestStateMachine chestStateMachine;

        public ChestController(ChestView chestPrefab, ChestScriptableObjectScript chestData, Transform parentSlot, EventService eventService, SlotController slot) { 
            chestModel = new ChestModel(chestData);
            this.chestView = GameObject.Instantiate<ChestView>(chestPrefab, parentSlot);
            chestView.SetController(this);
            this.eventService = eventService;
            this.slot = slot;
            CreateStateMachine();
            ChangeChestState(State.Locked);
        }

        private void CreateStateMachine() => chestStateMachine = new ChestStateMachine.ChestStateMachine(this,eventService);

        public State GetChestCurrentState()=> chestStateMachine.GetCurrentState();

        public void ChangeChestState(State state) => chestStateMachine.ChangeChestState(state);

        public void GenerateChestReward()
        {
            eventService.OnGenerateRewards.Invoke(GenerateCoin(),GenerateGems());
            slot.EmptySlot();
        }

        public SlotController GetSlotController()=> slot;

        private int GenerateCoin()
        {
            return Random.Range(chestModel.GetMinCoin,chestModel.GetMaxCoin);
        }

        private int GenerateGems()
        {
            return Random.Range(chestModel.GetMinGem, chestModel.GetMaxGem);
        }

        public void RemoveGameObject() => GameObject.Destroy(chestView.gameObject);
    }
}