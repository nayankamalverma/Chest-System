using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Slot
{
    public class SlotView : MonoBehaviour, IPointerClickHandler
    {
        SlotController slotController;

        public void SetController(SlotController slotController)
        {
            this.slotController = slotController;
        }
        public SlotController GetChestSlotController() => slotController;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (slotController.IsSlotEmpty()) { Debug.Log("empty"); return; }
            slotController.OnChestClick(); //if slot has chest
        }
    }
}
