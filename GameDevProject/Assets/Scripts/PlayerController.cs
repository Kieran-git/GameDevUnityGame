using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float JumpForce;
    public float MovementSpeed;
    bool CanJump;

    public float NormalSize;
    public float SmallerSize;
    public float ShrinkSpeed;
    public float GrowSpeed;
    bool Shrinking;

    private void OnCollisionStay(Collision collision)
    {
        CanJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        CanJump = false;
    }
    private void Start()
    {
        Shrinking = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        ShrinkAndGrow();
    }

    void PlayerMovement()
    {
        var v = rb.velocity;

        // Not frame independant??
        if (Input.GetKey(KeyCode.W)) v.z = Time.deltaTime * +MovementSpeed;
        if (Input.GetKey(KeyCode.S)) v.z = Time.deltaTime * -MovementSpeed;
        if (Input.GetKey(KeyCode.D)) v.x = Time.deltaTime * +MovementSpeed;
        if (Input.GetKey(KeyCode.A)) v.x = Time.deltaTime * -MovementSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && CanJump) v += JumpForce * Vector3.up;

        rb.velocity = v;
    }

    void ShrinkAndGrow()
    {
        // If not already shrinking and Q is pressed toggle shrinking,
        // otherwise if smaller size has been reached toggle growing
        if (!Shrinking && Input.GetKeyDown(KeyCode.Q)) Shrinking = true;
        if (transform.localScale.x <= SmallerSize) Shrinking = false;

        // Shrinking - while player isn't smaller size decrease until they are
        if (Shrinking && transform.localScale.x > SmallerSize)
        {
            transform.localScale -= Vector3.one * ShrinkSpeed * Time.deltaTime;
        }

        // Growing - while player isn't normal size increase until they are
        if (!Shrinking && transform.localScale.x <= NormalSize)
        {
            transform.localScale += Vector3.one * GrowSpeed * Time.deltaTime;
        }
    }
}
