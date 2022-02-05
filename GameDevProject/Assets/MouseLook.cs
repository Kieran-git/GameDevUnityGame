using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Vector2 Sensitivity;
    [SerializeField] private float MaxVertAngle;
    
    private Vector2 Rotation; // The current rotation so far

    // Can't go higher or lower than the set "maximum vertical angle" hence the -
    private float ClampVertAngle(float angle)
    {
        return Mathf.Clamp(angle, -MaxVertAngle, MaxVertAngle);
    }

    // Update is called once per frame
    void Update()
    {
        // Get where the mouse is 
        Vector2 mousePos = new Vector2
        {
            x = Input.GetAxis("Mouse X"),
            y = Input.GetAxis("Mouse Y")
        };

        // Multiply by sensitivity for the velocity of the turn
        Vector2 velocity = mousePos * Sensitivity;

        // Making it frame independant and then adding this on to the rotation
        Rotation += velocity * Time.deltaTime;

        // This means you can't flip your character all the way over
        Rotation.y = ClampVertAngle(Rotation.y);

        // The rotation is the desired position that the player moved there mouse to so this is where we access its x and y
        // This happens every update so it will look smooth despite just setting the new position
        transform.localEulerAngles = new Vector3(Rotation.y, Rotation.x, 0);

    }
}
