using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float MovementSpeed;
    Vector3 TargetPosition;

    private void Start()
    {
        TargetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            TargetPosition += Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            TargetPosition += Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            TargetPosition += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TargetPosition += Vector3.right;
        }

        transform.position = Vector3.Lerp(transform.position, TargetPosition, MovementSpeed * Time.deltaTime);

    }
}
