using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        if (Input.GetKeyDown(KeyCode.C))
        {
            mr.material.color = Random.ColorHSV();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
           /* mr.material.Lerp(Material., 2f)*/
        }
    }
}
