using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Chest
{
    public class ChestView : MonoBehaviour
    {
        [SerializeField] private Image chestImage;
        [SerializeField] private TextMeshProUGUI chestName;
        [SerializeField] private TextMeshProUGUI chestStatus;
        [SerializeField] private TextMeshProUGUI timeText;
    }
}