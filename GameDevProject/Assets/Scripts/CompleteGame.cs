using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameStateManager.GameCompleted = true;
    }
}
