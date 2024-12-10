using Assets.Scripts;
using Assets.Scripts.Chest;
using Assets.Scripts.ChestStateMachine;
using Assets.Scripts.Event;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ChestDetailUIController : MonoBehaviour
{
    [SerializeField] private Image chestImage;
    [SerializeField] private TextMeshProUGUI chestName;
    [SerializeField] private TextMeshProUGUI chestRarity;
    [SerializeField] private TextMeshProUGUI unlockTime;
    [SerializeField] private Button unlockButton;
    [SerializeField] private Button openNowButton;
    [SerializeField] private TextMeshProUGUI gemText;

    private UIService uIService;
    private EventService eventService;
    private ChestController chestController;
    private GemService gemService;
    private int gemRequiredToOpen;

    private void Awake()
    {
        unlockButton.onClick.AddListener(OnUnlockButtonClick);
        openNowButton.onClick.AddListener(OnOpenNowButtonClicked);
    }
    private void Update()
    {
        if (chestController.GetChestCurrentState() == State.Unlocking) {
            gemRequiredToOpen = (int)math.ceil(chestController.chestModel.GetUnlockTime / 30);
            unlockTime.text = chestController.chestModel.GetUnlockTimeString; 
            gemText.text = gemRequiredToOpen + " gems";
        }
    }

    public void SetService(UIService uIService ,EventService eventService, GemService gemService)
    {
        this.uIService = uIService;
        this.eventService = eventService;
        this.gemService = gemService;
    }


    public void ShowChestDetails(ChestController chestController,bool isUnlockInProgress)
    {
        this.chestController = chestController;
        gemRequiredToOpen = (int)math.ceil(chestController.chestModel.GetUnlockTime / 30);
        if (chestController.GetChestCurrentState() == State.Unlocked)
        {
            unlockButton.interactable = false;
        }
        else if((chestController.GetChestCurrentState()==State.Locked && isUnlockInProgress) || chestController.GetChestCurrentState() == State.Unlocking)
        {
            unlockButton.interactable=false;
        }
        else
        {
            unlockButton.interactable =true;
        }

        if (GemsAvailable(chestController)) openNowButton.interactable = true;
        else openNowButton.interactable = false;
        chestImage.sprite = chestController.chestModel.GetLockedChestSprite;
        chestName.text = chestController.chestModel.GetChestName;
        chestRarity.text = chestController.chestModel.GetChestType.ToString();
        unlockTime.text = chestController.chestModel.GetUnlockTimeString;
        gemText.text = gemRequiredToOpen+ " gems";

    }

    private bool GemsAvailable(ChestController chestController)
    {
        int x = (int)math.ceil(chestController.chestModel.GetUnlockTime / 30);
        return gemService.GetGems() >= gemRequiredToOpen ;
    }

    private void OnUnlockButtonClick()
    {
        eventService.OnUnlockButtonClick.Invoke();
        uIService.DeactivateChestDetailPanel();
    }

    private void OnOpenNowButtonClicked()
    {
        gemService.DeductGems(gemRequiredToOpen);
        eventService.OnQuickUnlockButtonClick.Invoke();
        uIService.DeactivateChestDetailPanel();
    }

    private void OnDestroy()
    {
        unlockButton.onClick.RemoveListener(OnUnlockButtonClick);
        openNowButton.onClick.RemoveListener(OnOpenNowButtonClicked);
    }

    
}
