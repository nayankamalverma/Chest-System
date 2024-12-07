using Assets.Scripts.Event;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private Button GetChestButton;


    private EventService eventService;

    private void Awake()
    {
        GetChestButton.onClick.AddListener(OnGetChest);

    }

    public void GetServices(EventService eventService)
    {
        this.eventService = eventService;
    }

    private void OnGetChest()=> eventService.OnGetChest.Invoke();
}
