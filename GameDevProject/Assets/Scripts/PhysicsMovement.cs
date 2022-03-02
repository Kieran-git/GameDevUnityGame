using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float JumpForce;
    public float MovementSpeed;
    bool CanJump;

    /*private void OnCollisionStay(Collision collision)
    {
        CanJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        CanJump = false;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var v = rb.velocity;
     
        // Not frame independant??
        if (Input.GetKey(KeyCode.W)) v.z = Time.deltaTime * +MovementSpeed;
        if (Input.GetKey(KeyCode.S)) v.z = Time.deltaTime * -MovementSpeed;
        if (Input.GetKey(KeyCode.D)) v.x = Time.deltaTime * +MovementSpeed;
        if (Input.GetKey(KeyCode.A)) v.x = Time.deltaTime * -MovementSpeed;

        if (Input.GetKeyDown(KeyCode.Space)/* && CanJump*/) v += JumpForce * Vector3.up;

        rb.velocity = v;
    }
}
