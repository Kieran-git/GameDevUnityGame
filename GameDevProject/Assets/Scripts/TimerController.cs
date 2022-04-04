using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text TimerText;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // https://social.msdn.microsoft.com/Forums/en-US/685780a0-e997-47e1-8979-dca94b5708d0/setting-decimal-limited-to-2-digits?forum=csharpgeneral
    void Update()
    {
        if (GameStateManager.GameCompleted == false)
        {
            float timeElapsed = Time.time - startTime;

            // Casting to int to get rid of some decimals
            string minutes = ((int)timeElapsed / 60).ToString();
            // To get only 2dp
            string seconds = (timeElapsed % 60).ToString("f2");

            TimerText.text = minutes + ":" + seconds;
        }
    }
}
