using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    Vector3 TargetPosition;
    public float FollowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToPlayer = Player.position - transform.position;

        dirToPlayer += new Vector3(0f, 4f, -9f);
        dirToPlayer.Normalize();

        transform.position += dirToPlayer * FollowSpeed * Time.deltaTime;

        
/*
        TargetPosition += transform.position - Player.position;

        transform.position = Vector3.Lerp(transform.position, TargetPosition, FollowSpeed * Time.deltaTime);
    */
    }
}
