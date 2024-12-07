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


        public float commonProbability=100;
        public float rareProbability=50;
        public float epicProbability=30;
        public float legendaryProbability=10;

        public ChestService(ChestSo chestSOList, EventService eventService) { 
            this.chestSOList = chestSOList;
            this.eventService = eventService;
        }

        private void GenerateChest()
        {
            ChestScriptableObjectScript chestData = GetRandomChest();
            ChestController chestController = new ChestController(GetRandomChest(), slotService.GetEmptySlot().GetTransform);
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
    }
}