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
        transform.position = Vector3.Lerp(transform.position, Player.position + DistanceFromTarget, FollowSpeed * Time.deltaTime);
    }
}
