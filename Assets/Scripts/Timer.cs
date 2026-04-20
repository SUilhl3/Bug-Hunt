using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float limitedTime;

    bool timerEnded = false;
    bool isRunning = false;

    void Start()
    {
        UpdateTimerUI(); 
    }

    void Update()
    {
        if (!isRunning) return; 

        if (limitedTime > 0)
        {
            limitedTime -= Time.deltaTime;
        }
        else if (!timerEnded)
        {
            limitedTime = 0;
            timerEnded = true;

            GameManager.Instance.LoseGame(); 
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(limitedTime / 60);
        int seconds = Mathf.FloorToInt(limitedTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        isRunning = true;
    }
}