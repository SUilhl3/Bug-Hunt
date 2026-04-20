using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] Timer timer;

    bool isTutorialActive = true;

    void Start()
    {
        ShowTutorial(); // start with tutorial open
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
        Time.timeScale = 0f;
    }

    void HideTutorial()
    {
        isTutorialActive = false;

        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;

        // Start timer only the FIRST time
        if (timer != null)
        {
            timer.StartTimer();
        }
    }
}