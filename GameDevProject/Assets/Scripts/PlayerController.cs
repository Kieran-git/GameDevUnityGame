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

    // To Do: Add Movement & Jump speed scaling
    void ShrinkAndGrow()
    {
        // Toggle Shirnk - If not already shrinking and Q is pressed and at the normal size then toggle shrinking
        if (!Shrinking && Input.GetKeyDown(KeyCode.Q) && transform.localScale.x >= NormalSize)
        {
            Shrinking = true;
        }
        // Toggle Grow - If smaller size has been reached toggle growing. 
        if (transform.localScale.x <= SmallerSize)
        {
            Shrinking = false;
        }

        // Shrinking - while player isn't smaller size decrease until they are, shrinking must be true
        if (Shrinking && transform.localScale.x > SmallerSize)
        {
            transform.localScale -= Vector3.one * ShrinkSpeed * Time.deltaTime;
        }

        // Growing - while player isn't normal size increase until they are, shrinking must be false
        if (!Shrinking && transform.localScale.x <= NormalSize)
        {
            transform.localScale += Vector3.one * GrowSpeed * Time.deltaTime;
        }
    }
}
