using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PlayerMovement
    private Rigidbody rb;
    float JumpForce;
    public float MovementSpeed;
    bool CanJump;

    // ShrinkAndGrow
    public Vector3 NormalGravity;
    public Vector3 IncreasedGravity;

    public float NormalJump;
    public float IncreasedJump;

    public float NormalSize;
    public float SmallerSize;

    public float ShrinkSpeed;
    public float GrowSpeed;

    bool Shrinking;

    // Audio
    public List<AudioClip> JumpSounds;

    public void OnCollisionEnter(Collision collision)
    {
        // Play collide sound
    }
    private void Start()
    {
        JumpForce = NormalJump;
        Shrinking = false;
        rb = GetComponent<Rigidbody>();
    }
    
    // Every physics update
    private void FixedUpdate()
    {
        var v = rb.velocity;

        // Not frame independant??
        if (Input.GetKey(KeyCode.W)) v.z = Time.deltaTime * +MovementSpeed;
        if (Input.GetKey(KeyCode.S)) v.z = Time.deltaTime * -MovementSpeed;
        if (Input.GetKey(KeyCode.D)) v.x = Time.deltaTime * +MovementSpeed;
        if (Input.GetKey(KeyCode.A)) v.x = Time.deltaTime * -MovementSpeed;

        rb.velocity = v;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        ShrinkAndGrow();

        DevCheckPoint();
    }

    void DevCheckPoint()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.position = new Vector3(20f, 16f, 14f);
        }
    }

    void Jump()
    {
        var v = rb.velocity;
        CanJump = Physics.Raycast(transform.position, Vector3.down, 1.5f);

        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            v += JumpForce * Vector3.up;
            AudioSource.PlayClipAtPoint(JumpSounds[Random.Range(0, 3)], transform.position);
        }

        rb.velocity = v;
    }

    // To Do: Add Movement & Jump speed scaling
    void ShrinkAndGrow()
    {
        // Altered values from two player forms
        if (transform.localScale.x >= NormalSize)
        {
            JumpForce = NormalJump;
            Physics.gravity = NormalGravity;
        }
        if (transform.localScale.x < NormalSize)
        {
            JumpForce = IncreasedJump;
            Physics.gravity = IncreasedGravity;
        }

        // Toggle Shrink - If not already shrinking and Q is pressed and at the normal size then toggle shrinking
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
