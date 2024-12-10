using Assets.Scripts;
using Assets.Scripts.Chest;
using Assets.Scripts.Event;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private Button getChestButton;
    [SerializeField] private GameObject notificationPanel;
    [SerializeField] private TextMeshProUGUI msgText;
    [SerializeField] private ChestDetailUIController chestDetailPanel;
    [SerializeField] private Button closeChestDetailButton;

    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI gemsText;



    private EventService eventService;
    private CoinService coinService;
    private GemService gemService;

    private void Awake()
    {
        getChestButton.onClick.AddListener(OnGetChest);
        closeChestDetailButton.onClick.AddListener(DeactivateChestDetailPanel);
        DeactivateChestDetailPanel();
    }


    public void GetServices(EventService eventService, CoinService coinService,GemService gemService)
    {
        this.eventService = eventService;
        this.gemService = gemService;
        this.coinService = coinService;
        chestDetailPanel.SetService(this,eventService , gemService);
        UpdateCollectibles();
        AddEventListeners();
    }

    private void Update()
    {
        UpdateCollectibles();
    }

    private void AddEventListeners()
    {
        eventService.OnUnlockFinishWithTime.AddListener(DeactivateChestDetailPanel);
        eventService.OnGenerateRewards.AddListener(UpdateCollectibles);
    }
    private void OnGetChest()=> eventService.OnGetChest.Invoke();

    public void ShowNotification(string msg)
    {
        notificationPanel.SetActive(true);
        msgText.text = msg;
        StartCoroutine(NotificationCoroutine());
    }

    private IEnumerator NotificationCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        notificationPanel.SetActive(false);
    }

    public void DeactivateChestDetailPanel()
    {
        chestDetailPanel.gameObject.SetActive(false);
    }

    public void ShowChestDetail(ChestController chestController,bool isUnlockInProgress)
    {
        chestDetailPanel.gameObject.SetActive(true);
        chestDetailPanel.ShowChestDetails(chestController,isUnlockInProgress);
    }

    private void UpdateCollectibles()
    {
        UpdateCoinsText(coinService.GetCoin());
        UpdateGemsText(gemService.GetGems());
    }

    public void UpdateCollectibles(int coins, int gems)
    {
        ShowNotification($"Found {coins} coins and {gems} gems in chest.");
        coinService.SetCoin(coins);
        gemService.SetGems(gems);
    }

    private void UpdateCoinsText(int coins) { coinsText.text = "Coins : " + coins; }
    private void UpdateGemsText(int gems) { gemsText.text = "Gems : " + gems; }

    private void OnDestroy()
    {
        RemoveListeners();
    }

    private void RemoveListeners()
    {
        getChestButton.onClick.RemoveListener(OnGetChest);
        closeChestDetailButton.onClick.RemoveListener(DeactivateChestDetailPanel);
        eventService.OnGenerateRewards.RemoveListener(UpdateCollectibles);

        eventService.OnUnlockFinishWithTime.RemoveListener(DeactivateChestDetailPanel);
    }
}
