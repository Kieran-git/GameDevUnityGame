using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    public float SmallerSize;
    public float NormalSize;
    public float ShrinkSpeed;
    public float GrowSpeed;
    bool Shrinking;

    // Start is called before the first frame update
    void Start()
    {
        NormalSize = transform.localScale.x;
        Shrinking = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If not already shrinking and Q is pressed toggle shrinking,
        // otherwise if smaller size has been reached toggle growing
        if (!Shrinking && Input.GetKeyDown(KeyCode.Q)) Shrinking = true;
        if (transform.localScale.x <= SmallerSize) Shrinking = false;

        // Shrinking - while player isn't smaller size decrease until they are
        if (Shrinking && transform.localScale.x > SmallerSize)
        {
            transform.localScale -= Vector3.one * ShrinkSpeed * Time.deltaTime;
        }

        // Growing - while player isn't normal size increase until they are
        if(!Shrinking && transform.localScale.x <= NormalSize)
        {
            transform.localScale += Vector3.one * GrowSpeed * Time.deltaTime;
        }
    }
}
