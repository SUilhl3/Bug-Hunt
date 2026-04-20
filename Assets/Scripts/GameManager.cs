using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] int totalBugs;
    int bugsRemaining;

    [SerializeField] TextMeshProUGUI objectiveText;
    [SerializeField] TextMeshProUGUI resultText;

    [SerializeField] Timer timer; 

    bool gameEnded = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    { 
        bugsRemaining = totalBugs;
        UpdateObjectiveText();
        resultText.text = "";
    }
    
    void UpdateObjectiveText()
    {
        objectiveText.text = "Find " + bugsRemaining + " bugs and place them in the crate in front of the cabin before the time runs out";
    }

    public void BugCollected()
    {
        if (gameEnded) return;

        bugsRemaining--;
        UpdateObjectiveText();

        if (bugsRemaining <= 0)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        gameEnded = true;
        resultText.text = "YOU WIN!";
        Time.timeScale = 0f;
    }

    public void LoseGame()
    {
        if (gameEnded) return;

        gameEnded = true;
        resultText.text = "YOU LOSE!";
        Time.timeScale = 0f;
    }
}