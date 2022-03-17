using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // PlayerMovement
    private Rigidbody rb;
    float JumpForce;
    public float MovementSpeed;
    bool CanJump;

    // ShrinkAndGrow

    public float MinJump;
    public float MaxJump;

    public float MinSize;
    public float MaxSize;

    public float MinGravity;
    public float MaxGravity;

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
        // Check if audio listener component is present if not change to main menu where its initalised
        if(FindObjectOfType<AudioListener>() == null) SceneManager.LoadScene("Main Menu");

        JumpForce = MinJump;
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

        CheckPoints();
    }
    void CheckPoints()
    {
        // Currently dev checkpoints so can be acessed at any time ( in future set to also check if the area has been reached before allowing use)

        // Key1 - cp1
        if (Input.GetKeyDown(KeyCode.Alpha1) && GameStateManager.Checkpoints)
        {
            transform.position = new Vector3(20f, 16f, 14f);
        }
        // Key2 - cp2
        if (Input.GetKeyDown(KeyCode.Alpha2) && GameStateManager.Checkpoints)
        {
            transform.position = new Vector3(-5f, 22f, 0.5f);
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

    void ShrinkAndGrow()
    {
        // Take minimum and divide by range to get to a 0 to 1 scale
        float jumpScale = (MinJump - MinJump) / (MaxJump - MinJump);
        float gravityScale = (MinGravity - MinGravity) / (MaxGravity - MinGravity);

        // Altered values from two player forms
        if (transform.localScale.x >= MaxSize)
        {
            JumpForce = MinJump;
            Physics.gravity = new Vector3(0f, MaxGravity, 0f);
        }
        if (transform.localScale.x < MaxSize)
        {
            JumpForce = MaxJump;
            Physics.gravity = new Vector3(0f, MinGravity, 0f);
        }

        // Toggle Shrink - If not already shrinking and Q is pressed and at the normal size then toggle shrinking
        if (!Shrinking && Input.GetKeyDown(KeyCode.Q) && transform.localScale.x >= MaxSize)
        {
            Shrinking = true;
        }
        // Toggle Grow - If smaller size has been reached toggle growing. 
        if (transform.localScale.x <= MinSize)
        {
            Shrinking = false;
        }

        // Shrinking - while player isn't smaller size decrease until they are, shrinking must be true
        if (Shrinking && transform.localScale.x > MinSize)
        {
            transform.localScale -= Vector3.one * ShrinkSpeed * Time.deltaTime;
        }
        // Growing - while player isn't normal size increase until they are, shrinking must be false
        if (!Shrinking && transform.localScale.x <= MaxSize)
        {
            transform.localScale += Vector3.one * GrowSpeed * Time.deltaTime;
        }
    }
}
