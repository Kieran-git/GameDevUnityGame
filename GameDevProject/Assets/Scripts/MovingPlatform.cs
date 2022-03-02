using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Vector3 StartPosition;
    Vector3 DistanceDifference;
    bool Forward;
    public float PlatformSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        Forward = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the difference between where the object first started and where it has moved to since
        DistanceDifference = transform.position - StartPosition;

        // Toggle between forward or backwards (z axis) in this orientation
        if (DistanceDifference.z >= 5) Forward = false;
        if (DistanceDifference.z <= -5) Forward = true;

        // Add PlatformSpeed to the z axis every frame until the target position is reached then switch to the other
        if (DistanceDifference.z < 5 && Forward)
        {
            transform.position += Vector3.forward * PlatformSpeed;
        }
        if(DistanceDifference.z > -5 && !Forward)
        {
            transform.position += Vector3.back * PlatformSpeed;
        }
    }
}
