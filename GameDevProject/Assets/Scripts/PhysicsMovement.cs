using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float JumpForce;
    public float MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var v = rb.velocity;
        
        if (Input.GetKey(KeyCode.W)) v.z = +MovementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) v.z = -MovementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) v.x = +MovementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) v.x = -MovementSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)) v += JumpForce * Vector3.up;

        rb.velocity = v;
    }
}
