using Assets.Scripts.Chest;
using Assets.Scripts.Event;
using Assets.Scripts.ScriptableObject;
using Assets.Scripts.Slot;
using UnityEngine;

public class GameService : MonoBehaviour
{
    #region Services
    private EventService EventService;
    [SerializeField]private UIService UIService;
    private SlotService SlotService;
    private ChestService ChestService;

    #endregion

    #region refrences

    //slotservice
    [SerializeField] int noOfSlots = 4;
    [SerializeField] SlotView slotView;
    [SerializeField] RectTransform slotContainer;
    //Chest Service
    [SerializeField] private ChestSo chestSOList;
    //
    #endregion

    private void Awake()
    {
        int slotCount = Mathf.Max(4, noOfSlots);
        EventService = new EventService();
        SlotService = new SlotService(slotCount,slotView,slotContainer,EventService);
        ChestService = new ChestService(chestSOList, EventService, SlotService);
        UIService.GetServices(EventService);
    }

}
