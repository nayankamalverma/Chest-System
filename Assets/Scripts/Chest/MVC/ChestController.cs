using Assets.Scripts.Event;
using Assets.Scripts.Slot;
using UnityEngine;

namespace Assets.Scripts.Chest
{
    public class ChestController
    {
        private ChestView chestView;
        private ChestModel chestModel;
        private EventService eventService;
        private SlotController slot;

        public ChestController(ChestScriptableObjectScript chestData, Transform parentSlot, EventService eventService, SlotController slot) { 
            chestModel = new ChestModel(chestData);
            this.chestView = GameObject.Instantiate<ChestView>(chestData.chestPrefab, parentSlot);
            this.eventService = eventService;
            this.slot = slot;
        }
    }
}