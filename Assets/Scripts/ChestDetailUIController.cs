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

    private void Awake()
    {
        unlockButton.onClick.AddListener(OnUnlockButtonClick);
        openNowButton.onClick.AddListener(OnOpenNowButtonClicked);
    }

    public void SetService(UIService uIService ,EventService eventService)
    {
        this.uIService = uIService;
        this.eventService = eventService;
        AddEventListeners();
    }

    private void AddEventListeners()
    {
    }
    
    private void RemoveEventListeners()
    {
    }

    public void ShowChestDetails(ChestController chestController,bool isUnlockInProgress)
    {
        if (chestController.GetChestCurrentState() == State.Unlocked)
        {
            unlockButton.interactable = false;
            openNowButton.interactable=false;
        }
        else if((chestController.GetChestCurrentState()==State.Locked && isUnlockInProgress) || chestController.GetChestCurrentState() == State.Unlocking)
        {
            unlockButton.interactable = false;
            openNowButton.interactable=true;
        }
        else
        {
            unlockButton.interactable =true;
            openNowButton.interactable = true;
        }
        chestImage.sprite = chestController.chestModel.GetLockedChestSprite;
        chestName.text = chestController.chestModel.GetChestName;
        chestRarity.text = chestController.chestModel.GetChestType.ToString();
        unlockTime.text = chestController.chestModel.GetUnlockTimeString;
        gemText.text = math.ceil(chestController.chestModel.GetUnlockTime/30) + " gems";

    }

    private void OnUnlockButtonClick()
    {
        eventService.OnUnlockButtonClick.Invoke();
        uIService.DeactivateChestDetailPanel();
    }

    private void OnOpenNowButtonClicked()
    {
        eventService.OnQuickUnlockButtonClick.Invoke();
        uIService.DeactivateChestDetailPanel();
    }

    private void OnDestroy()
    {
        RemoveEventListeners();
        unlockButton.onClick.RemoveListener(OnUnlockButtonClick);
        openNowButton.onClick.RemoveListener(OnOpenNowButtonClicked);
    }

    
}
