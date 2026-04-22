using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] Timer timer;

    [SerializeField] bool isTutorialActive = false;

    [SerializeField] TextMeshProUGUI objectiveText;
    [SerializeField] TextMeshProUGUI timerText;

    void Start()
    {
        if (isTutorialActive)
        {
            ShowTutorial();
        }
        else
        {
            HideTutorial();
        }

    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            ToggleTutorial();
        }
    }

    void ToggleTutorial()
    {
        if (isTutorialActive)
        {
            HideTutorial();

        }
        else
        {
            ShowTutorial();
        }
    }

    void ShowTutorial()
    {
        isTutorialActive = true;

        tutorialPanel.SetActive(true);
        objectiveText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);

        Time.timeScale = 0f;
    }

    void HideTutorial()
    {
        isTutorialActive = false;

        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;

        objectiveText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);

        if (timer != null)
        {
            timer.StartTimer();
        }
    }
}