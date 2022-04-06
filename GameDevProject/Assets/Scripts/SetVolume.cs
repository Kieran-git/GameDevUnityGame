using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    // https://www.youtube.com/watch?v=xNHSGMKtlv4
    public void SetLevel(float sliderVal)
    {
        mixer.SetFloat("Volume", Mathf.Log10(sliderVal * 20)-25);
    }
}
