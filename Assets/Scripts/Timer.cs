using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float limitedTime;

    bool timerEnded = false;

    void Update()
    {
        if (limitedTime > 0)
        {
            limitedTime -= Time.deltaTime;
        }
        else if (!timerEnded)
        {
            limitedTime = 0;
            timerEnded = true;

            GameManager.Instance.LoseGame(); // trigger lose
        }

        int minutes = Mathf.FloorToInt(limitedTime / 60);
        int seconds = Mathf.FloorToInt(limitedTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}