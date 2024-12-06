using UnityEngine;
using TMPro;

public class ChestTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign your TextMeshPro component here
    public float totalTimeInSeconds = 3600f; // 1 hour as an example

    void Update()
    {
        if (totalTimeInSeconds > 0)
        {
            totalTimeInSeconds -= Time.deltaTime;
            int hours = Mathf.FloorToInt(totalTimeInSeconds / 3600);
            int minutes = Mathf.FloorToInt((totalTimeInSeconds % 3600) / 60);
            int seconds = Mathf.FloorToInt(totalTimeInSeconds % 60);

            timerText.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }
        else
        {
            timerText.text = "00:00"; 
        }
    }
}
