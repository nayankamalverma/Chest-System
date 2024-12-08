using Assets.Scripts.Event;
using Assets.Scripts.Slot;
using Assets.Scripts.ChestStateMachine;
using UnityEngine;

namespace Assets.Scripts.Chest
{
    public class ChestController
    {
        private ChestView chestView;
        private ChestModel chestModel;
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
            chestStateMachine.ChangeChestState(State.Locked);
        }

        private void CreateStateMachine() => chestStateMachine = new ChestStateMachine.ChestStateMachine(this);

        public ChestModel GetChestModel => chestModel;
        public State GetChestCurrentState=> chestStateMachine.GetCurrentState();
    }
}