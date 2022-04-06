using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // PlayerMovement
    private Rigidbody rb;
    float JumpForce;
    public float MovementSpeed;
    bool CanJump;

    // ShrinkAndGrow
    public float MinJump, MaxJump;

    public float MinSize, MaxSize;

    public float MinGravity, MaxGravity;

    public float ShrinkSpeed, GrowSpeed;

    public float MinImg, MaxImg;

    bool Shrinking;
    
    // UI
    public RawImage PlayerSizeImg;
    
    public Text Paused;

    // Audio
    public List<AudioClip> JumpSounds;

    // Animation
    Animator animator;
    int isRunningHash;

    public void OnCollisionEnter(Collision collision)
    {
        // Play collide sound
    }
    private void Start()
    {
        GameStateManager.GameCompleted = false;
        GameStateManager.GamePaused = false;

        Paused.gameObject.SetActive(false);

        // Animation
        animator = GetComponent<Animator>();

        // Performance thing
        isRunningHash = Animator.StringToHash("isRunning");

        JumpForce = MinJump;
        Shrinking = false;
        rb = GetComponent<Rigidbody>();
    }

    // Every physics update handle physics movement
    void FixedUpdate()
    {
        if (!GameStateManager.GameCompleted && !GameStateManager.GamePaused)
        {
            var v = rb.velocity;

            if (Input.GetKey(KeyCode.W)) v.z = Time.deltaTime * +MovementSpeed;
            if (Input.GetKey(KeyCode.S)) v.z = Time.deltaTime * -MovementSpeed;
            if (Input.GetKey(KeyCode.D)) v.x = Time.deltaTime * +MovementSpeed;
            if (Input.GetKey(KeyCode.A)) v.x = Time.deltaTime * -MovementSpeed;

            rb.velocity = v;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameStateManager.GameCompleted && !GameStateManager.GamePaused)
        {
            HandleRotation();

            HandleAnimation();
        
            Jump();
        
            ShrinkAndGrow();
        }

        if(!GameStateManager.GameCompleted) PauseGame();
        if(GameStateManager.Checkpoints) CheckPoints();
    }

    void HandleRotation()
    {
        // Don't try and look if the velocity is an insignificant amount
        if (rb.velocity.magnitude > .01)
        {
            // https://forum.unity.com/threads/face-forward-based-on-rigid-body-velocity.82493/s
            //transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
            Vector3 temp = rb.velocity;
            temp.y = 0f;
            transform.LookAt(transform.position + temp);
        }
    }

    void HandleAnimation()
    {
        bool isRunning = animator.GetBool(isRunningHash);

        bool movePressed = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (!isRunning && movePressed)
        {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && !movePressed)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    void Jump()
    {
        var v = rb.velocity;
        CanJump = Physics.Raycast(transform.position, Vector3.down, 1f);

        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            v += JumpForce * Vector3.up;
            AudioSource.PlayClipAtPoint(JumpSounds[Random.Range(0, 3)], transform.position);
        }

        rb.velocity = v;
    }

    void ShrinkAndGrow()
    {
        float currentScale = transform.localScale.x - 1;

        float jumpScale = Mathf.Lerp(MaxJump, MinJump, currentScale);
        float gravityScale = Mathf.Lerp(MinGravity, MaxGravity, currentScale);
        float ImageSize = Mathf.Lerp(MinImg, MaxImg, currentScale);

        // https://forum.unity.com/threads/how-to-change-the-size-of-a-ui-image-from-code-trying-to-make-a-simple-healthbar-from-this.265024/
        PlayerSizeImg.rectTransform.sizeDelta = new Vector2(ImageSize, ImageSize);

        JumpForce = jumpScale;
        Physics.gravity = new Vector3(0f, gravityScale, 0f);
        //Debug.Log("JumpScale: " + jumpScale);
        //Debug.Log("GravityScale: " + gravityScale);

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

    void CheckPoints()
    {
        // Currently dev checkpoints so can be acessed at any time ( in future set to also check if the area has been reached before allowing use)

        // Key1 - cp1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = new Vector3(20f, 16f, 14f);
        }
        // Key2 - cp2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.position = new Vector3(-5f, 22f, 0.5f);
        }
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameStateManager.GamePaused = !GameStateManager.GamePaused;
        }
        if (GameStateManager.GamePaused) Paused.gameObject.SetActive(true);
        else Paused.gameObject.SetActive(false);
        
    }
}
