using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour 
{
    public static bool Checkpoints;
    public static bool GameCompleted;
    public Text LeaderboardContents;
    public static GameObject ListenerObject;

    private void Start()
    {
        LeaderboardContents.text = PlayerPrefs.GetString("Leaderboard");
    }
    public void ToggleCheckpoints()
    {
        Checkpoints = !Checkpoints;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Stage");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
