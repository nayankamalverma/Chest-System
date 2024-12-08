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

    private void Awake()
    {
        getChestButton.onClick.AddListener(OnGetChest);
        closeChestDetailButton.onClick.AddListener(DeactivateChestDetailPanel);
        DeactivateChestDetailPanel();
    }


    public void GetServices(EventService eventService)
    {
        this.eventService = eventService;
        chestDetailPanel.SetService(this,eventService);
        AddEventListeners();
    }

    private void AddEventListeners()
    {
        eventService.OnChestClick.AddListener(ShowChestDetail);
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

    public void ShowChestDetail(ChestController chestController)
    {
        chestDetailPanel.gameObject.SetActive(true);
        chestDetailPanel.ShowChestDetails(chestController);
    }

    private void UpdateCoinsText(int coins) { coinsText.text = coins.ToString(); }
    private void UpdateGemsText(int gems) { gemsText.text = gems.ToString(); }

    private void OnDestroy()
    {
        RemoveListeners();
    }

    private void RemoveListeners()
    {
        eventService.OnChestClick.RemoveListener(ShowChestDetail);
        getChestButton.onClick.RemoveListener(OnGetChest);
        closeChestDetailButton.onClick.RemoveListener(DeactivateChestDetailPanel);

    }
}
