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
            
        }
        else
        {
            timerText.text = "00:00"; 
        }
    }
}
