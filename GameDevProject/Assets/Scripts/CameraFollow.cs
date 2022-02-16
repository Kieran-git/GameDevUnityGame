using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 DistanceFromTarget;
    public float FollowSpeed;
    public float FollowStopDistance;

    Transform TargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 distToPlayer = Player.position - transform.position;
        
        if (Mathf.Abs(distToPlayer.magnitude - DistanceFromTarget.magnitude) < FollowStopDistance) return;

        distToPlayer += DistanceFromTarget;
        distToPlayer.Normalize();

        transform.position += distToPlayer * FollowSpeed * Time.deltaTime;
        */

        transform.position = Vector3.Lerp(transform.position, Player.position + DistanceFromTarget, FollowSpeed * Time.deltaTime);
    }
}
