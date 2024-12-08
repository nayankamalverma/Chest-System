using Assets.Scripts.Chest;
using Assets.Scripts.ChestStateMachine;
using Assets.Scripts.Event;
using TMPro;
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

    public void ShowChestDetails(ChestController chestController)
    {
        if (chestController.GetChestCurrentState == State.Unlocked)
        {
            chestImage.sprite = chestController.GetChestModel.GetOpenedChestSprite;
            unlockButton.gameObject.SetActive(false);
            openNowButton.gameObject.SetActive(false);
        }
        else chestImage.sprite = chestController.GetChestModel.GetLockedChestSprite;

        chestName.text = chestController.GetChestModel.GetChestName;
        chestRarity.text = chestController.GetChestModel.GetChestType.ToString();
        unlockTime.text = chestController.GetChestModel.GetUnlockTimeString;

    }

    private void OnUnlockButtonClick()
    {
        Debug.Log("unlocking");
        uIService.DeactivateChestDetailPanel();
    }

    private void OnOpenNowButtonClicked()
    {
        Debug.Log("quick unlock");
        uIService.DeactivateChestDetailPanel();
    }

    private void OnDestroy()
    {
        RemoveEventListeners();
        unlockButton.onClick.RemoveListener(OnUnlockButtonClick);
        openNowButton.onClick.RemoveListener(OnOpenNowButtonClicked);
    }

    
}
