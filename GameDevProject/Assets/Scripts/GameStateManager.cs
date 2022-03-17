using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour 
{
    public static bool Checkpoints;

    public void ToggleCheckpoints()
    {
        Checkpoints = !Checkpoints;
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Stage");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
