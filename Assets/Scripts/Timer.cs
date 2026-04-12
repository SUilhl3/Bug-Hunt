using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float limitedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (limitedTime > 0)
        {
            limitedTime -= Time.deltaTime;
        }
        else
        {
            limitedTime = 0;
        }
        
        int minutes = Mathf.FloorToInt(limitedTime / 60);
        int seconds = Mathf.FloorToInt(limitedTime % 60);
        timerText.text = string.Format("{00:00} : {1:00}", minutes, seconds);
    }
}
