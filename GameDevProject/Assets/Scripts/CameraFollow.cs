using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 DistanceFromTarget;
    public float FollowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distToPlayer = Player.position - transform.position;

        distToPlayer += DistanceFromTarget;
        distToPlayer.Normalize();

        // Trying to stop camera shake
        if (distToPlayer == DistanceFromTarget * 1.1f) return;
        transform.position += distToPlayer * FollowSpeed * Time.deltaTime;

    }
}
