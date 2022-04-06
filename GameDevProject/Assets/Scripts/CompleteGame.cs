using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteGame : MonoBehaviour
{
    public InputField NameInput;
    public Button SubmitButton;
    public Text Timer;
    public Text CongratsText;
    public Text Warning;
    int count = 0;

    private void Start()
    {
        NameInput.gameObject.SetActive(false);
        SubmitButton.gameObject.SetActive(false);
        CongratsText.gameObject.SetActive(false);
        Warning.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(GameStateManager.GameCompleted == true)
        {
            NameInput.gameObject.SetActive(true);
            SubmitButton.gameObject.SetActive(true);
            CongratsText.gameObject.SetActive(true);
            Warning.gameObject.SetActive(true);

            if (count == 0) CongratsText.text += Timer.text;
            count++;

            NameInput.Select();
        }
    }

    // Called by button click
    public void SubmitScore()
    {
        if(NameInput.text.Trim().Length > 6)
        {
            NameInput.text = "";
            return;
        }

        string leaderboard = PlayerPrefs.GetString("Leaderboard");
        leaderboard += NameInput.text + " - " + Timer.text + "\n";
        PlayerPrefs.SetString("Leaderboard", leaderboard);

        ReturnToMenu();
    }

    // When the user enters the finish line game object
    private void OnCollisionEnter(Collision collision)
    {
        GameStateManager.GameCompleted = true;
    }

    public void ReturnToMenu()
    {
        // In order to stop 2 audio listeners being in the scene at once
        Destroy(GameStateManager.ListenerObject);

        SceneManager.LoadScene("Main Menu");
    }
}
