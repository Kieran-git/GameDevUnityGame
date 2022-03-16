using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour 
{
    public static bool Checkpoints;

    public void ToggleCheckpoints()
    {
        Checkpoints = !Checkpoints;
    }
}
