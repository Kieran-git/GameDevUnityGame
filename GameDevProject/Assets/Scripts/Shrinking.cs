using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x > 0f)
        {
            transform.localScale -= new Vector3(1f, 1f, 1f) * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
